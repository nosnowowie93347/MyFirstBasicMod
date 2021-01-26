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
		public static bool downedAbomination;
		public static bool downedOverseer = false;
		public static bool downedPuritySpirit;

		public override TagCompound Save() {
			var downed = new List<string>();
			if (downedAbomination) {
				downed.Add("abomination");
			}

			if (downedPuritySpirit) {
				downed.Add("puritySpirit");
			}
			if (downedOverseer) {
				downed.Add("overseer");
			}


			return new TagCompound {
				["downed"] = downed
			};
		}

		public override void Load(TagCompound tag) {
			var downed = tag.GetList<string>("downed");
			downedAbomination = downed.Contains("abomination");
			downedPuritySpirit = downed.Contains("puritySpirit");
			downedOverseer = downed.Contains("overseer");
		}

		public override void LoadLegacy(BinaryReader reader) {
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0) {
				BitsByte flags = reader.ReadByte();
				downedAbomination = flags[0];
				downedPuritySpirit = flags[1];
				downedOverseer = flags[2];
			}
			else {
				mod.Logger.WarnFormat("MyFirstBasicMod: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer) {
			var flags = new BitsByte();
			flags[0] = downedAbomination;
			flags[1] = downedPuritySpirit;
			flags[2] = downedOverseer;
			writer.Write(flags);

			
		}

		public override void NetReceive(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			downedAbomination = flags[0];
			downedPuritySpirit = flags[1];
			downedOverseer = flags[2];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Mod Ores", MyFirstBasicModOres));
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
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 6), TileType<PinksOre>());
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(4, 7), TileType<GlowingOre>());
				

				
			}
		}

		public override void PostWorldGen() {
			int num = NPC.NewNPC((Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, ModContent.NPCType<NPCs.ExamplePerson>(), 0, 0f, 0f, 0f, 0f, 255);
			Main.npc[num].homeTileX = Main.spawnTileX + 5;
			Main.npc[num].homeTileY = Main.spawnTileY;
			Main.npc[num].direction = 1;
			Main.npc[num].homeless = true;
		}
	}
}