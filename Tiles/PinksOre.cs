using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Tiles
{
	public class PinksOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
            Main.tileOreFinderPriority[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            TileObjectData.newTile.LavaDeath = false;

            LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Pink's Ore");
			AddMapEntry(new Color(255, 200, 200), name);

			DustType = 84;
			HitSound = SoundID.Tink;
            MineResist = 4f;
            MinPick = 200;
        }
	}
}