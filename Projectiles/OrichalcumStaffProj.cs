using MyFirstBasicMod.Dusts;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Projectiles
{
    public class TrueAmethystProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TrueAmethystProjectile");
        }

        public override void SetDefaults()
        {
            Projectile.hostile = false;
            Projectile.magic = true;
            Projectile.penetrate = 5;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.timeLeft = 20;
            Projectile.friendly = true;
            aiType = 7;
            Projectile.alpha = 255;
            Projectile.light = 0.5f;
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustType<Sparkle>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 8; ++i) {
                Vector2 targetDir = ((((float)Math.PI * 2) / 8) * i).ToRotationVector2();
                targetDir.Normalize();
                targetDir *= 4;
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, targetDir.X, targetDir.Y, ModContent.ProjectileType<OrichHoming>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
            }
        }
    }
}