using MyFirstBasicMod.Items;
using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using MyFirstBasicMod.NPCs;
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
		public PlayerEffect setbonus = null;
		public int manaHeartCounter;
		public float percentDamage;
		public float defenseEffect = -1f;
		public bool badHeal;
		public int healHurt;
		public bool infinity;
        public const int maxPinkLifeFruits = 20;
        public int pinkLifeFruits;

        public int constantDamage { get; internal set; }
        public override void ResetEffects () {
                  player.statLifeMax2 += pinkLifeFruits * 5;
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = mod.GetPacket();
			packet.Write(pinkLifeFruits);
			packet.Send(toWho, fromWho);
		}
        public override TagCompound Save() {
			// Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
			return new TagCompound {
				{"pinkLifeFruits", pinkLifeFruits},


			};
			//note that C# 6.0 supports indexer initializers
			//return new TagCompound {
			//	["score"] = score
			//};
		}

		public override void Load(TagCompound tag) {
			
			pinkLifeFruits = tag.GetInt("pinkLifeFruits");
			}

		
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
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                return;
            }
            
            if (questFish == ItemType<PinksFish>() && Main.rand.NextBool())
            {
                caughtType = ItemType<PinksFish>();
            }
        }
        public override void GetFishingLevel(Item fishingRod, Item bait, ref int fishingLevel)
		{
		}
	}
}
