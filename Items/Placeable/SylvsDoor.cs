using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Placeable
{
	public class SylvsDoor : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sylv's Door");
			// Tooltip.SetDefault("Sylv's very own door.\nMade by Sylv.");
		}

		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 28;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = TileType<Tiles.SylvsDoorClosed>();
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.SylvsBlock>(10)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}