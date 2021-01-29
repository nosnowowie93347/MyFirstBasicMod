using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
    public class PinksChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded chest.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
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
            Item.createTile = ModContent.TileType<Tiles.PinksChest>();
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(10)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }

    public class ExampleChestKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3; //Biome keys usually take 1 Item to research instead.
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GoldenKey);
            Item.width = 14;
            Item.height = 20;
            Item.maxStack = 99;
        }
    }
}