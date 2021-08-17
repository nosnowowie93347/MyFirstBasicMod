using MyFirstBasicMod.Items;
using MyFirstBasicMod.Tiles;
using MyFirstBasicMod.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod
{
	public class PinksWorld : ModWorld
	{
        public static bool downedPinkzor;
        public static bool downedSlimePrince = false;

        public override void Initialize()
        {
            downedPinkzor = false;
            downedSlimePrince = false;
           PinkTheTraveller.spawnTime = double.MaxValue;
        }

        public override TagCompound Save() {
			var downed = new List<string>();
			
            if (downedPinkzor)
            {
                downed.Add("pinkzor");
            }

            if (downedSlimePrince)
            {
                downed.Add("slimePrince");
            }

			return new TagCompound {
				["downed"] = downed,
                ["traveler"] = PinkTheTraveller.Save()
            };
		}

		public override void Load(TagCompound tag) {
			var downed = tag.GetList<string>("downed");
            downedPinkzor = downed.Contains("pinkzor");
            downedSlimePrince = downed.Contains("slimePrince");
            PinkTheTraveller.Load(tag.GetCompound("traveler"));
        }

		public override void LoadLegacy(BinaryReader reader) {
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0) {
				BitsByte flags = reader.ReadByte();
                downedPinkzor = flags[3];
                downedSlimePrince = flags[4];
			}
			else {
				mod.Logger.WarnFormat("MyFirstBasicMod: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer) {
			var flags = new BitsByte();
            flags[3] = downedPinkzor;
            flags[4] = downedSlimePrince;
			writer.Write(flags);

			
		}

		public override void NetReceive(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
            downedPinkzor = flags[3];
            downedSlimePrince = flags[4];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Mod Ores", MyFirstBasicModOres));
			}
            int TrapsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Traps"));
            if (TrapsIndex != -1)
            {
                tasks.Insert(TrapsIndex + 1, new PassLegacy("Mod Traps", MyFirstBasicModTraps));
            }
        }
        private void MyFirstBasicModTraps(GenerationProgress progress)
        {
            progress.Message = "Mod Traps";

            // Computers are fast, so WorldGen code sometimes looks stupid.
            // Here, we want to place a bunch of tiles in the world, so we just repeat until success. It might be useful to keep track of attempts and check for attempts > maxattempts so you don't have infinite loops. 
            // The WorldGen.PlaceTile method returns a bool, but it is useless. Instead, we check the tile after calling it and if it is the desired tile, we know we succeeded.
            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                bool placeSuccessful = false;
                Tile tile;
                int tileToPlace = ModContent.TileType<Tiles.ExampleCutTileTile>();
                while (!placeSuccessful)
                {
                    int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int y = WorldGen.genRand.Next(0, Main.maxTilesY);
                    WorldGen.PlaceTile(x, y, tileToPlace);
                    tile = Main.tile[x, y];
                    placeSuccessful = tile.active() && tile.type == tileToPlace;
                }
            }
        }

        private void MyFirstBasicModOres(GenerationProgress progress) {
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "My First Basic Mod Ores";

			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 10), WorldGen.genRand.Next(8, 12), TileType<GlowingOre>());
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 10), WorldGen.genRand.Next(5, 8), TileType<PinksOre>());
                
				

				
			}
		}

		public override void PostWorldGen() {
			int num = NPC.NewNPC((Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, ModContent.NPCType<NPCs.Pinkalicious21902>(), 0, 0f, 0f, 0f, 0f, 255);
			Main.npc[num].homeTileX = Main.spawnTileX + 5;
			Main.npc[num].homeTileY = Main.spawnTileY;
			Main.npc[num].direction = 1;
			Main.npc[num].homeless = true;
		}
        public override void PreUpdate()
        {
            // Update everything about spawning the traveling merchant from the methods we have in the Traveling Merchant's class
            PinkTheTraveller.UpdateTravelingMerchant();
        }
    }
}