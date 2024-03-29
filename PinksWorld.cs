using MyFirstBasicMod.Items;
using MyFirstBasicMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace MyFirstBasicMod
{
    public class PinksWorld : ModSystem
    {
        public static bool downedDusking = false;

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedDusking) {
                downed.Add("dusking");
            }
            tag.Add("downed", downed);
        }
        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedDusking = downed.Contains("dusking");
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte bosses1 = new BitsByte(downedDusking);
            writer.Write(bosses1);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte bosses1 = reader.ReadByte();
            downedDusking = bosses1[4];
        }


        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {

            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {

                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Mod Ores", MyFirstBasicModOres));
            }
        }

        private void MyFirstBasicModOres(GenerationProgress progress, GameConfiguration configuration)
        {
            // progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
            progress.Message = "My First Basic Mod Ores";

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                // The inside of this for loop corresponds to one single splotch of our Ore.
                // First, we randomly choose any coordinate in the world by choosing a random x and y value.
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 6), TileType<PinksOre>());
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 7), WorldGen.genRand.Next(6, 8), TileType<GlowingOre>());


            }
        }
    }
}
