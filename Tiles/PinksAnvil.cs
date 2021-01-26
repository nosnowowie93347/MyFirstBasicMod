using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Tiles
{
	public class PinksAnvil : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new[] { 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Pink's Anvil");
			AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = true;
			adjTiles = new int[] { TileID.MythrilAnvil };
			drop = ItemType<Items.Placeable.PinksAnvil>();
		}


		// public override void KillMultiTile(int i, int j, int frameX, int frameY)
		// {
		// 	Item.NewItem(i * 16, j * 16, 14, 24, ItemType<Items.Placeable.PinksAnvil>());
		// }
	}
}