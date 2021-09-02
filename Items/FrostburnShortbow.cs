using MyFirstBasicMod.Projectiles;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class FrostburnShortbow : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Frostburn Shortbow");
			Tooltip.SetDefault("Very frosty");
		}

		public override void SetDefaults() {
			item.damage = 32;
			item.ranged = true;
            item.crit = 10;
			item.width = 34;
			item.height = 55;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 1.3f;
			item.value = 993;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<FrostburnShortbowProj>();
			item.shootSpeed = 22f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBow);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		// Replace fire arrows with frost arrows
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.FireArrow)
            {
                type = ProjectileID.FrostArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

      
    }
}