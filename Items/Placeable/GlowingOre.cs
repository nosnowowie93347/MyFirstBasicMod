using MyFirstBasicMod.Tiles;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 110;
        }


		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 12;

			Item.maxStack = 999;
			Item.rare = ItemRarityID.Pink;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<Tiles.GlowingOre>();
		}
	}
}