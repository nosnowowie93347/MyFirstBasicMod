using MyFirstBasicMod.Items;
using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class PinksPlayer : ModPlayer
	{

		public bool manaHeart;
		public int manaHeartCounter;

        public int constantDamage { get; internal set; }

        public override void OnConsumeMana(Item item, int manaConsumed) {
			if (manaHeart) {
				manaHeartCounter += manaConsumed;
				if (manaHeartCounter >= 200) { 					
					if (Main.netMode != NetmodeID.Server) {
						Main.PlaySound(SoundID.Item4, player.position);
						player.statLife += 20;
						if (Main.myPlayer == player.whoAmI) {
							player.HealEffect(20, true);
						}
						if (player.statLife > player.statLifeMax2) {
							player.statLife = player.statLifeMax2;
						}
					}
					manaHeartCounter -= 200;
				}
			}
		}

		public override void GetFishingLevel(Item fishingRod, Item bait, ref int fishingLevel)
		{
		}
	}
}