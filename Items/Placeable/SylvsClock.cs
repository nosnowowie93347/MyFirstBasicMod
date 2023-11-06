using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
    public class SylvsClock : ModItem
    {
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("A clock to tell the time.");
        }

        public override void SetDefaults() {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 500;
            Item.createTile = ModContent.TileType<Tiles.SylvsClock>();
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.GrandfatherClock, 1)
                .AddIngredient<SylvsBlock>(10)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}