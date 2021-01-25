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
			Item.width = 12;
			Item.height = 30;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = TileType<Tiles.SylvsChair>();
		}


	}
}