using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Tiles
{
    public class SylvsBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sylv's Block");
            ItemDrop = ItemType<Items.Placeable.SylvsBlock>();         
            AddMapEntry(new Color(200, 200, 200));
            HitSound = SoundID.Tink;
        }
      
    }
}