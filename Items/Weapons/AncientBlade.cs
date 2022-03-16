using Microsoft.Xna.Framework;
using MyFirstBasicMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
	public class AncientBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blade of the Ancients");
			Tooltip.SetDefault("Melee hits on enemies may emit a special projectile\nInflicts Shadowflame");
		}

		public override void SetDefaults()
		{
			item.damage = 52;
			item.useTime = 18;
			item.useAnimation = 18;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 25700;
			item.rare = ItemRarityID.Pink;
			item.crit = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}


		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.ShadowbeamStaff);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 180, true);
			if (Main.rand.Next(4) == 0) {
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<ShadowEmber>(), damage, knockback, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 1f, 0f, ModContent.ProjectileType<ShadowEmber>(), damage, knockback, player.whoAmI, 0f, 0f);
				Projectile.NewProjectile(target.Center.X, target.Center.Y, -2f, 0f, ModContent.ProjectileType<ShadowEmber>(), damage, knockback, player.whoAmI, 0f, 0f);
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}