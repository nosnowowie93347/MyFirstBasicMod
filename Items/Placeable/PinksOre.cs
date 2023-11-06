using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace MyFirstBasicMod.Items.Placeable
{
	public class PinksOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pink's Ore");
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.PinksOre>();
			Item.width = 12;
			Item.height = 12;
			Item.value = 3000;
		}
	}
}