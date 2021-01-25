using MyFirstBasicMod.Items;
using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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


        public int constantDamage { get; internal set; }
        public override void ResetEffects () {
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = Mod.GetPacket();
			packet.Send(toWho, fromWho);
		}
        public override TagCompound Save() {
			// Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
			return new TagCompound {


			};
			//note that C# 6.0 supports indexer initializers
			//return new TagCompound {
			//	["score"] = score
			//};
		}

		public override void Load(TagCompound tag) {
			
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
