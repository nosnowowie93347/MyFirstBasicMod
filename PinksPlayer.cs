using MyFirstBasicMod.Items;
using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using MyFirstBasicMod.NPCs;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Localization;
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

        public override void ModifyMaxStats(out StatModifier health, out StatModifier mana) {
			health = StatModifier.Default;
			health.Base = pinkLifeFruits * PinksLifeFruit.LifePerFruit;
			mana = StatModifier.Default;
			// Alternatively:  health = StatModifier.Default with { Base = exampleLifeFruits * ExampleLifeFruit.LifePerFruit };
			
		}

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)Player.whoAmI);
			packet.Write((byte)pinkLifeFruits);
			packet.Send(toWho, fromWho);
		}

		public void ReceivePlayerSync(BinaryReader reader) {
			pinkLifeFruits = reader.ReadByte();
		}

		public override void CopyClientState(ModPlayer targetCopy) {
			PinksPlayer clone = (PinksPlayer)targetCopy;
			clone.pinkLifeFruits = pinkLifeFruits;
		}

		public override void SendClientChanges(ModPlayer clientPlayer) {
			PinksPlayer clone = (PinksPlayer)clientPlayer;

			if (pinkLifeFruits != clone.pinkLifeFruits) {
				SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
			}
		}

        public override void SaveData(TagCompound tag) {
			tag["pinkLifeFruits"] = pinkLifeFruits;
		}

		public override void LoadData(TagCompound tag) {
			pinkLifeFruits = tag.GetInt("pinkLifeFruits");
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
