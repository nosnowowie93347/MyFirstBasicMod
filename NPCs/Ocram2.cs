using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MyFirstBasicMod.Items.Weapons;
using MyFirstBasicMod.Items;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.NPCs
{
    public class Ocram2 : ModNPC
    {
        int timer = 0;
        int moveSpeed = 0;
        int moveSpeedY = 0;
        float HomeY = 150f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocram 2.0");
        }

        public override void SetDefaults()
        {
            npc.width = 344;
            npc.height = 298;
            npc.damage = 140;
            npc.defense = 89;
            npc.lifeMax = 34500;
            npc.knockBackResist = 0.5f;
            npc.lavaImmune = true;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            music = MusicID.Boss2;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath5;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.3f);
            npc.defense = (int)(npc.defense * 1.4f);
        }
        private int Counter;
        public override bool PreAI()
        {
            Counter++;
            if (Counter > 1000 && !NPC.AnyNPCs(143))
            {
                int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, 143, npc.whoAmI);
                Counter = 0;
            }
            npc.netUpdate = true;
            npc.TargetClosest(true);
            npc.TargetClosest(false);
            npc.velocity.Y = -100;
            if (npc.ai[0] == 0)
            {
                npc.spriteDirection = npc.direction;
                Player player = Main.player[npc.target];
                if (npc.Center.X >= player.Center.X && moveSpeed >= -53) // flies to players x position
                    moveSpeed--;
                else if (npc.Center.X <= player.Center.X && moveSpeed <= 53)
                    moveSpeed++;

                npc.velocity.X = moveSpeed * 0.1f;

                if (npc.Center.Y >= player.Center.Y - HomeY && moveSpeedY >= -30) //Flies to players Y position
                {
                    moveSpeedY--;
                    HomeY = 150f;
                }
                else if (npc.Center.Y <= player.Center.Y - HomeY && moveSpeedY <= 30)
                    moveSpeedY++;

                npc.velocity.Y = moveSpeedY * 0.1f;
                if (Main.rand.Next(220) == 6)
                    HomeY = -35f;
            }
            npc.velocity.Y = moveSpeedY * 0.1f;

            timer++;
            if (timer == 200 || timer == 250)
            {
                Vector2 direction = Main.player[npc.target].Center - npc.Center;
                direction.Normalize();
                direction.X *= 5f;
                direction.Y *= 5f;

                int amountOfProjectiles = Main.rand.Next(5, 6);
                for (int i = 0; i < amountOfProjectiles; ++i)
                {
                    float A = (float)Main.rand.Next(-150, 150) * 0.03f;
                    float B = (float)Main.rand.Next(-150, 150) * 0.03f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, ProjectileID.FrostBlastHostile, 29, 1, Main.myPlayer, 0, 0);
                }
            }
            
            else if (timer >= 500)
            {
                timer = 0;
            }
            return true;
        }

        public override void NPCLoot()
        {
            int[] lootTable = {
                ModContent.ItemType<ElliesGun>(),
                ItemID.SnowmanCannon,
                ModContent.ItemType<Items.TwilightsBow>()
            };
            int loot = Main.rand.Next(lootTable.Length);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, lootTable[loot]);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EpicSoul>(), Main.rand.Next(15, 23));
            for (int i = 0; i < 15; ++i)
            {
                if (Main.rand.Next(8) == 0)
                {
                    int newDust = Dust.NewDust(npc.position, npc.width, npc.height, 76, 0f, 0f, 100, default(Color), 2.5f);
                    Main.dust[newDust].noGravity = true;
                    Main.dust[newDust].velocity *= 5f;
                }
            }
        }

        

        public override void AI()
        {
            int dust = Dust.NewDust(npc.position, npc.width, npc.height - 40, DustID.Snow);
            Main.dust[dust].noGravity = true;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
        }
    }
}