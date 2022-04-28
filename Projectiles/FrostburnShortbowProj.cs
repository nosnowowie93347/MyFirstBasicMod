using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Projectiles
{
    public class FrostburnShortbowProj : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.FrostArrow;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostburn Shortbow");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The  length of position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {

            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 3;
            Projectile.light = 0.6f;
            Projectile.friendly = true;
            Pprojectile.hostile = false;
            Projectile.width = 1;
            Projectile.height = 1;

        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(ModContent.BuffType<Buffs.ColdFire>(), 240);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.ColdFire>(), 240);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.ColdFire>(), 240);
        }
    }
}