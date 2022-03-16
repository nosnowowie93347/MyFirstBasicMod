using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Tiles
{
	public class SteelOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; 
			Main.tileValue[Type] = 210; // Metal Detector value
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 455; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Steel Ore");
			AddMapEntry(new Color(113, 121, 126), name);

			dustType = DustID.Platinum;
			drop = ItemType<Items.Placeable.SteelOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			//mineResist = 4f;
			minPick = 180;
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1.2f;
			g = 0.3f;
			b = 1.0f;
		}
	}
}