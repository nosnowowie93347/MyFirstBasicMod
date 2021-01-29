using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace MyFirstBasicMod.Projectiles
{
    public class GlowStingSpear : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seraph Blade");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Trident);

            aiType = ProjectileID.Trident;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 187, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            int dust2 = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 206, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 0f;
            Main.dust[dust2].velocity *= 0f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}