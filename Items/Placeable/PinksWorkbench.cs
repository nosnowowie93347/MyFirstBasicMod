using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Placeable
{
	public class PinksWorkbench : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This is a modded workbench.");
            DisplayName.SetDefault("Pink's Work Bench");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 950;
			item.createTile = TileType<Tiles.PinksWorkbench>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(ItemType<SylvsBlock>(), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}