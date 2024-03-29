﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using MyFirstBasicMod.BossBars;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs
{
  
    public class KingOfTheNightMinion : ModNPC
    {
        
        public int ParentIndex
        {
            get => (int)NPC.ai[0] - 1;
            set => NPC.ai[0] = value + 1;
        }

        public bool HasParent => ParentIndex > -1;

        public float PositionOffset
        {
            get => NPC.ai[1];
            set => NPC.ai[1] = value;
        }

        public const float RotationTimerMax = 360;
        public ref float RotationTimer => ref NPC.ai[2];

        // Helper method to determine the body type
        public static int BodyType()
        {
            return ModContent.NPCType<KingOfTheNight>();
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 1;

            // By default enemies gain health and attack if hardmode is reached. this NPC should not be affected by that
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;

            NPCID.Sets.CantTakeLunchMoney[Type] = true;

            // Specify the debuffs it is immune to. Most NPCs are immune to Confused.
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;

        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 7;
            NPC.defense = 0;
            NPC.lifeMax = 50;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.8f;
            NPC.alpha = 255; // This makes it transparent upon spawning, we have to manually fade it in in AI()
            NPC.netAlways = true;

            NPC.aiStyle = -1;
        }



        public override Color? GetAlpha(Color drawColor)
        {
            if (NPC.IsABestiaryIconDummy)
            {
                // This is required because we have NPC.alpha = 255, in the bestiary it would look transparent
                return NPC.GetBestiaryEntryColor();
            }
            return Color.White * NPC.Opacity;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
            return true;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                // If this NPC dies, spawn some visuals

                int dustType = 59; // Some blue dust, read the dust guide on the wiki for how to find the perfect dust

                for (int i = 0; i < 20; i++)
                {
                    Vector2 velocity = NPC.velocity + new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
                    Dust dust = Dust.NewDustPerfect(NPC.Center, dustType, velocity, 26, Color.White, Main.rand.NextFloat(1.5f, 2.4f));

                    dust.noLight = true;
                    dust.noGravity = true;
                    dust.fadeIn = Main.rand.NextFloat(0.3f, 0.8f);
                }
            }
        }

        public override void AI()
        {
            if (Despawn())
            {
                return;
            }

            FadeIn();

            MoveInFormation();
        }

        private bool Despawn()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient &&
                (!HasParent || !Main.npc[ParentIndex].active || Main.npc[ParentIndex].type != BodyType()))
            {

                // => invalid, kill itself without dropping any items
                NPC.active = false;
                NPC.life = 0;
                NetMessage.SendData(MessageID.SyncNPC, number: NPC.whoAmI);
                return true;
            }
            return false;
        }

        private void FadeIn()
        {
            if (NPC.alpha > 0)
            {
                NPC.alpha -= 10;
                if (NPC.alpha < 0)
                {
                    NPC.alpha = 0;
                }
            }
        }

        private void MoveInFormation()
        {
            NPC parentNPC = Main.npc[ParentIndex];

            
            float rad = (float)PositionOffset * MathHelper.TwoPi;

            // Add some slight uniform rotation to make the eyes move, giving a chance to touch the player and thus helping melee players
            RotationTimer += 0.5f;
            if (RotationTimer > RotationTimerMax)
            {
                RotationTimer = 0;
            }

            float continuousRotation = MathHelper.ToRadians(RotationTimer);
            rad += continuousRotation;
            if (rad > MathHelper.TwoPi)
            {
                rad -= MathHelper.TwoPi;
            }
            else if (rad < 0)
            {
                rad += MathHelper.TwoPi;
            }

            float distanceFromBody = parentNPC.width + NPC.width;

            // offset is now a vector that will determine the position of the NPC based on its index
            Vector2 offset = Vector2.One.RotatedBy(rad) * distanceFromBody;

            Vector2 destination = parentNPC.Center + offset;
            Vector2 toDestination = destination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.Zero);

            float speed = 8f;
            float inertia = 20;

            Vector2 moveTo = toDestinationNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
        }
    }
}