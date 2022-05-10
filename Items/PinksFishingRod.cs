using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using MyFirstBasicMod.Projectiles;
using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class PinksFishingRod : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pink's Fishing Rod");
			Tooltip.SetDefault("Fires multiple lines at once. Can fish in lava.\n" +
				"The fishing line never snaps.");

			// Allows the pole to fish in lava
			ItemID.Sets.CanFishInLava[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			
			Item.CloneDefaults(ItemID.WoodFishingPole);

			Item.fishingPole = 60; // Sets the poles fishing power
			Item.shootSpeed = 12f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			Item.shoot = ModContent.ProjectileType<PinksBobber>();
		}

		public override void HoldItem(Player player) {
			player.accFishingLine = true;
		}

		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int bobberAmount = Main.rand.Next(3, 6); // 3 to 5 bobbers
			float spreadAmount = 75f; // how much the different bobbers are spread out.

			for (int index = 0; index < bobberAmount; ++index) {
				Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);

				// Generate new bobbers
				Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.WoodFishingPole)
				.AddIngredient<Items.Placeable.PinksBar>(5)
				.AddTile<Tiles.Furniture.ExampleWorkbench>()
				.Register();
		}
	}
}