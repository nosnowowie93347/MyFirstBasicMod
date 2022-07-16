using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
    public class SylvsClock : ModItem
    {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("A clock to tell the time.");
        }

        public override void SetDefaults() {
            item.width = 26;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 500;
            item.createTile = ModContent.TileType<Tiles.SylvsClock>();
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