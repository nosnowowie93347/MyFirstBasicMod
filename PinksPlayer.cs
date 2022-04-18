using MyFirstBasicMod.Items;
using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using MyFirstBasicMod.NPCs;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.Audio;
using Terraria;
using Terraria.DataStructures;
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
		public const int maxPinkLifeFruits = 20;
        public int pinkLifeFruits;

        public int constantDamage { get; internal set; }
        public override void ResetEffects () {
        	player.statLifeMax2 += pinkLifeFruits * 5;

        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)Player.whoAmI);
			packet.Write(pinkLifeFruits);
			packet.Send(toWho, fromWho);
		}
        public override void SaveData(TagCompound tag) {
			tag["pinkLifeFruits"] = pinkLifeFruits;
		}

		public override void LoadData(TagCompound tag) {
			pinkLifeFruits = (int) tag["pinkLifeFruits"];
		}
        public override void OnConsumeMana(Item item, int manaConsumed) {
			if (manaHeart) {
				manaHeartCounter += manaConsumed;
				if (manaHeartCounter >= 200) { 					
					if (Main.netMode != NetmodeID.Server) {
						SoundEngine.PlaySound(SoundID.Item4, Player.position);
						Player.statLife += 20;
						if (Main.myPlayer == Player.whoAmI) {
							Player.HealEffect(20, true);
						}
						if (Player.statLife > Player.statLifeMax2) {
							Player.statLife = Player.statLifeMax2;
						}
					}
					manaHeartCounter -= 200;
				}
			}
		}


	}
}
