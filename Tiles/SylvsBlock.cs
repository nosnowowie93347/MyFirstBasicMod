 using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using MyFirstBasicMod.Dusts;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Tiles
{
    public class SylvsBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sylv's Block");
            dustType = ModContent.DustType<Sparkle>();
            drop = ItemType<Items.Placeable.SylvsBlock>();         
            AddMapEntry(new Color(200, 200, 200));
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }
    }
}