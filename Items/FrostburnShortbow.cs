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
			Item.damage = 52;
			Item.DamageType = DamageClass.Ranged;
            Item.crit = 10;
			Item.width = 34;
			Item.height = 55;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1.3f;
			Item.value = 993;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<FrostburnShortbowProj>();
			Item.shootSpeed = 22f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes() {
			{
            CreateRecipe()
                .AddIngredient(ItemID.FrostCore, 10)
                .AddIngredient(ItemID.MoltenFury)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
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