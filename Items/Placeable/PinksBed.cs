using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
	public class PinksBed : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pink's Bed");
			Tooltip.SetDefault("Sweet dreams.");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 2000;
			item.createTile = ModContent.TileType<Tiles.PinksBed>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bed);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 4);
			recipe.AddTile(ModContent.TileType<Tiles.PinksWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}