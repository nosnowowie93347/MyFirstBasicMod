using Terraria.ID;
using MyFirstBasicMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Placeable
{
	public class SylvsChair : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sylv's Chair");
			Tooltip.SetDefault("This chair was made by Sylv.\nDo not underestimate its power.");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.SylvsChair>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenChair);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.SylvsBlock>(), 20);
			recipe.AddTile(TileType<Tiles.PinksWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}