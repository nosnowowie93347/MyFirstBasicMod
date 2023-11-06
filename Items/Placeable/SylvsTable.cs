using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Drawing;
using Terraria.ObjectData;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
	public class SylvsTable : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.SylvsTable>());
			Item.width = 38;
			Item.height = 24;
			Item.value = 150;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.WoodenTable)
				.AddIngredient<SylvsBlock>(10)
				.Register();
		}
	}
}