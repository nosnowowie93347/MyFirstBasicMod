using Microsoft.Xna.Framework;
using MyFirstBasicMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Tiles
{
	public class GlowingOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSpelunker[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlendAll[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;  //true for block to emit light
			Main.tileLighted[Type] = true;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Glowing Ore");
			AddMapEntry(new Color(204, 0, 102), name);
			HitSound = SoundID.Tink;
			MinPick = 180;

		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.2f;
			g = 0.4f;
			b = 1.4f;
		}
	}
}