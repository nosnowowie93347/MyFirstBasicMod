using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using MyFirstBasicMod.Items.Weapons;
using MyFirstBasicMod.Items;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.CameraModifiers;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.NPCs
{
    public class Ocram2 : ModNPC
    {
        int timer = 0;
        int moveSpeed = 0;
        int moveSpeedY = 0;
        float HomeY = 150f;

        public override void SetStaticDefaults() {
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            // Specify the debuffs it is immune to. Most NPCs are immune to Confused.
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            // This boss also becomes immune to OnFire and all buffs that inherit OnFire immunity during the second half of the fight. See the ApplySecondStageBuffImmunities method.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers() {
                CustomTexturePath = "ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview",
                PortraitScale = 0.6f, // Portrait refers to the full picture when clicking on the icon in the bestiary
                PortraitPositionYOverride = 0f,
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        public override void SetDefaults()
        {
            NPC.width = 344;
            NPC.height = 298;
            NPC.damage = 140;
            NPC.defense = 89;
            NPC.lifeMax = 34500;
            NPC.knockBackResist = 0.5f;
            NPC.lavaImmune = true;
            NPC.boss = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            Music = MusicID.Boss2;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath5;
        }

        private int Counter;
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(), // Plain black background
                new FlavorTextBestiaryInfoElement("Example Minion Boss that spawns minions on spawn, summoned with a spawn item. Showcases boss minion handling, multiplayer considerations, and custom boss bar.")
            });
        }
        // public override bool PreAI()
        // {
            // Counter++;
            
            // NPC.netUpdate = true;
            // NPC.TargetClosest(true);
            // NPC.TargetClosest(false);
            // NPC.velocity.Y = -100;
            // if (NPC.ai[0] == 0)
            // {
            //     NPC.spriteDirection = NPC.direction;
            //     Player player = Main.player[NPC.target];
            //     if (NPC.Center.X >= player.Center.X && moveSpeed >= -53) // flies to players x position
            //         moveSpeed--;
            //     else if (NPC.Center.X <= player.Center.X && moveSpeed <= 53)
            //         moveSpeed++;

            //     NPC.velocity.X = moveSpeed * 0.1f;

            //     if (NPC.Center.Y >= player.Center.Y - HomeY && moveSpeedY >= -30) //Flies to players Y position
            //     {
            //         moveSpeedY--;
            //         HomeY = 150f;
            //     }
            //     else if (NPC.Center.Y <= player.Center.Y - HomeY && moveSpeedY <= 30)
            //         moveSpeedY++;

            //     NPC.velocity.Y = moveSpeedY * 0.1f;
            //     if (Main.rand.Next(220) == 6)
            //         HomeY = -35f;
            // }
            // NPC.velocity.Y = moveSpeedY * 0.1f;

            // timer++;
            // if (timer == 200 || timer == 250)
            // {
            //     Player player = Main.player[NPC.target];
            //     var entitySource = NPC.GetSource_FromAI();
            //     float kitingOffsetX = Utils.Clamp(player.velocity.X * 16, -100, 100);
            //     Vector2 position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-100, 100), Main.rand.Next(50, 100));

            //     int type = ProjectileID.FrostBlastHostile;
            //     int damage = NPC.damage / 2;
            //     Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
            //     direction.Normalize();
            //     direction.X *= 5f;
            //     direction.Y *= 5f;

            //     int amountOfProjectiles = Main.rand.Next(5, 6);
            //     for (int i = 0; i < amountOfProjectiles; ++i)
            //     {
            //         float A = (float)Main.rand.Next(-150, 150) * 0.03f;
            //         float B = (float)Main.rand.Next(-150, 150) * 0.03f;
            //         Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);
            //     }
            // }
            
            // else if (timer >= 500)
            // {
            //     timer = 0;
            // }
            // return true;
        // }

        public override void ModifyNPCLoot(NPCLoot npcLoot) {
            // Do NOT misuse the ModifyNPCLoot and OnKill hooks: the former is only used for registering drops, the latter for everything else

            // // Add the treasure bag using ItemDropRule.BossBag (automatically checks for expert mode)
            // npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<MinionBossBag>()));

            // // Trophies are spawned with 1/10 chance
            // npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeable.Furniture.MinionBossTrophy>(), 10));

            // // ItemDropRule.MasterModeCommonDrop for the relic
            // npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeable.Furniture.MinionBossRelic>()));

            // // ItemDropRule.MasterModeDropOnAllPlayers for the pet
            // npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<MinionBossPetItem>(), 4));

            // All our drops here are based on "not expert", meaning we use .OnSuccess() to add them into the rule, which then gets added
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            // Notice we use notExpertRule.OnSuccess instead of npcLoot.Add so it only applies in normal mode
            // // Boss masks are spawned with 1/7 chance
            // notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MinionBossMask>(), 7));

            // This part is not required for a boss and is just showcasing some advanced stuff you can do with drop rules to control how items spawn
            // We make 12-15 ExampleItems spawn randomly in all directions, like the lunar pillar fragments. Hereby we need the DropOneByOne rule,
            // which requires these parameters to be defined
            int itemType = ModContent.ItemType<Items.EpicSoul>();
            var parameters = new DropOneByOne.Parameters() {
                ChanceNumerator = 1,
                ChanceDenominator = 1,
                MinimumStackPerChunkBase = 1,
                MaximumStackPerChunkBase = 1,
                MinimumItemDropsCount = 4,
                MaximumItemDropsCount = 11,
            };

            notExpertRule.OnSuccess(new DropOneByOne(itemType, parameters));

            // Finally add the leading rule
            npcLoot.Add(notExpertRule);
        }

        

        public override void AI()
        {
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active) {
                NPC.TargetClosest();
            }

            Player player = Main.player[NPC.target];

            if (player.dead) {
                // If the targeted player is dead, flee
                NPC.velocity.Y -= 0.04f;
                // This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
                NPC.EncourageDespawn(10);
                return;
            }
            Counter++;
            
            NPC.netUpdate = true;
            NPC.TargetClosest(true);
            NPC.TargetClosest(false);
            NPC.velocity.Y = -100;
            if (NPC.ai[0] == 0)
            {
                NPC.spriteDirection = NPC.direction;
                if (NPC.Center.X >= player.Center.X && moveSpeed >= -53) // flies to players x position
                    moveSpeed--;
                else if (NPC.Center.X <= player.Center.X && moveSpeed <= 53)
                    moveSpeed++;

                NPC.velocity.X = moveSpeed * 0.1f;

                if (NPC.Center.Y >= player.Center.Y - HomeY && moveSpeedY >= -30) //Flies to players Y position
                {
                    moveSpeedY--;
                    HomeY = 150f;
                }
                else if (NPC.Center.Y <= player.Center.Y - HomeY && moveSpeedY <= 30)
                    moveSpeedY++;

                NPC.velocity.Y = moveSpeedY * 0.1f;
                if (Main.rand.Next(220) == 6)
                    HomeY = -35f;
            }
            NPC.velocity.Y = moveSpeedY * 0.1f;

            timer++;
            if (timer == 200 || timer == 250)
            {
                var entitySource = NPC.GetSource_FromAI();
                float kitingOffsetX = Utils.Clamp(player.velocity.X * 16, -100, 100);
                Vector2 position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-100, 100), Main.rand.Next(50, 100));

                int type = ProjectileID.FrostBlastHostile;
                int damage = NPC.damage / 2;
                Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
                direction.Normalize();
                direction.X *= 5f;
                direction.Y *= 5f;

                int amountOfProjectiles = Main.rand.Next(5, 6);
                for (int i = 0; i < amountOfProjectiles; ++i)
                {
                    float A = (float)Main.rand.Next(-150, 150) * 0.03f;
                    float B = (float)Main.rand.Next(-150, 150) * 0.03f;
                    Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);
                }
            }
            
            else if (timer >= 500)
            {
                timer = 0;
            }
            

            int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height - 40, DustID.Snow);
            Main.dust[dust].noGravity = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
        }
    }
}