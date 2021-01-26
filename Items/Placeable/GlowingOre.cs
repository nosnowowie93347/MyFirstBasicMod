using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
	public class GlowingOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Ore");
			Tooltip.SetDefault("'Glowing metal'");
		}


		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 12;

			item.maxStack = 999;
			item.rare = ItemRarityID.Pink;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 10;
			item.useAnimation = 15;

			item.useTurn = true;
			item.autoReuse = true;
			item.consumable = true;

			item.createTile = ModContent.TileType<Tiles.GlowingOre>();
		}
	}
}