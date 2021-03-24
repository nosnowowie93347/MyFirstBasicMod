﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Projectiles
{
    public class SpiritShardFriendly : ModProjectile
    {
        int target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Essence");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;       //projectile width
            projectile.height = 20;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.melee = true;         // 
            projectile.tileCollide = false;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 2;      //how many npc will penetrate
            projectile.timeLeft = 180;   //how many time projectile projectile has before disepire // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
            projectile.alpha = 255;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            bool flag25 = false;
            int jim = 1;
            for (int index1 = 0; index1 < 200; index1++)
            {
                if (Main.npc[index1].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[index1].Center, 1, 1))
                {
                    float num23 = Main.npc[index1].position.X + (float)(Main.npc[index1].width / 2);
                    float num24 = Main.npc[index1].position.Y + (float)(Main.npc[index1].height / 2);
                    float num25 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num23) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num24);
                    if (num25 < 300f)
                    {
                        flag25 = true;
                        jim = index1;
                    }

                }
            }

            if (flag25)
            {
                float num1 = 4f;
                Vector2 vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num2 = Main.npc[jim].Center.X - vector2.X;
                float num3 = Main.npc[jim].Center.Y - vector2.Y;
                float num4 = (float)Math.Sqrt((double)num2 * (double)num2 + (double)num3 * (double)num3);
                float num5 = num1 / num4;
                float num6 = num2 * num5;
                float num7 = num3 * num5;
                int num8 = 30;
                projectile.velocity.X = (projectile.velocity.X * (float)(num8 - 1) + num6) / (float)num8;
                projectile.velocity.Y = (projectile.velocity.Y * (float)(num8 - 1) + num7) / (float)num8;
            }

            for (int index1 = 0; index1 < 3; ++index1)
            {
                float num1 = projectile.velocity.X * 0.2f * (float)index1;
                float num2 = (float)-((double)projectile.velocity.Y * 0.200000002980232) * (float)index1;
                int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 206, 0.0f, 0.0f, 100, new Color(255, 20, 147), 1.3f);
                Main.dust[index2].noGravity = true;
                Main.dust[index2].velocity *= 0.0f;
                Main.dust[index2].scale = 1.6f;
                Main.dust[index2].position.X -= num1;
                Main.dust[index2].position.Y -= num2;
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
            ProjectileExtras.Explode(projectile.whoAmI, 120, 120,
                delegate {
                    for (int i = 0; i < 20; i++)
                    {
                        int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 206, 0f, -2f, 0, new Color(255, 20, 147), 2f);
                        Main.dust[num].noGravity = true;
                        Main.dust[num].position.X += Main.rand.Next(-50, 51) * .05f - 1.5f;
                        Main.dust[num].position.Y += Main.rand.Next(-50, 51) * .05f - 1.5f;
                        if (Main.dust[num].position != projectile.Center)
                            Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 6f;
                    }
                });
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

    }
}