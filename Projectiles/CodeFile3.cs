using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Projectiles
{
    public abstract class OreSpreadSolution : BaseSolution
    {
        public ushort oreID = 1;
        public bool[] replacingTiles = TileID.Sets.Conversion.Stone;
        public override void SetDefaults()
        {
            base.SetDefaults();
            maxTime = 64;
            dustType = ModContent.DustType<Dusts.Sparkle>();
        }

        public override void Convert(int i, int j, int size = 4)
        {
            for (int k = i - size; k <= i + size; k++)
            {
                for (int l = j - size; l <= j + size; l++)
                {
                    if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size))
                    {
                        if (replacingTiles[Main.tile[k, l].type])
                        {
                            Main.tile[k, l].type = oreID;
                            WorldGen.SquareTileFrame(k, l, true);
                            NetMessage.SendTileSquare(-1, k, l, 1);
                        }
                    }
                }
            }
        }
    }
}
