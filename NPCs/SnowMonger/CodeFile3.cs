﻿
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.SnowMonger
{
    public class SnowBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowball");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 34;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.tileCollide = true;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Snow);
            }
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);

            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 6, -2, ProjectileID.FrostBlastHostile, projectile.damage, projectile.knockBack, Main.myPlayer);
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -6, -2, ProjectileID.FrostBlastHostile, projectile.damage, projectile.knockBack, Main.myPlayer);
        }

        public override void AI()
        {
            projectile.rotation += 0.3f;


            for (int i = 1; i <= 3; i++)
            {
                if (Main.rand.Next(4) == 0)
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Snow);
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
                target.AddBuff(BuffID.Frostburn, 180, true);
        }
    }
}