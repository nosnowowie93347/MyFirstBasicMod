using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace MyFirstBasicMod.Items.Placeable
{
	public class PinksWorkbench : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("This is a modded workbench.");
            // DisplayName.SetDefault("Pink's Work Bench");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
        }

		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.PinksWorkbench>();
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.SylvsBlock>(10)
                .AddIngredient(ItemID.WorkBench, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}