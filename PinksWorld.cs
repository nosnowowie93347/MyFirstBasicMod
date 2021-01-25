using MyFirstBasicMod.Items;
using MyFirstBasicMod.Tiles;
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
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace MyFirstBasicMod
{
	public class PinksWorld : ModSystem
	{

		
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Mod Ores", MyFirstBasicModOres));
			}
		}

        private void MyFirstBasicModOres(GenerationProgress progress, GameConfiguration configuration)
        {
            
				
			}
		}
	}
