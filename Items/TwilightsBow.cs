using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;

namespace MyFirstBasicMod.Items
{
	public class TwilightsBow : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Behold! It's Twilight's Bow!");
			// DisplayName.SetDefault("Twilight's Bow");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults() {
			Item.damage = 150;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 65;
			Item.useTime = 14;
			Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 99999;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 31f;
			Item.useAmmo = AmmoID.Arrow;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(20)
                .AddIngredient(ItemID.MoltenFury)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }




		// Also, when I do this, how do I prevent shooting through tiles?
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 8; // The humber of projectiles that this gun will shoot.

			for (int i = 0; i < NumProjectiles; i++)
			{
				// Rotate the velocity randomly by 30 degrees at max.
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

				// Decrease velocity randomly for nicer visuals.
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile
		}



	}
}
