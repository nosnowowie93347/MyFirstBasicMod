using MyFirstBasicMod.Items;
using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using MyFirstBasicMod.NPCs;
using MyFirstBasicMod.NPCs.PuritySpirit;
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
		public bool purityMinion;
		public bool examplePet;
		public PlayerEffect setbonus = null;
		public int manaHeartCounter;
		public float percentDamage;
		public float defenseEffect = -1f;
		public int reviveTime;
		public bool badHeal;
		public int healHurt;
		public int heroLives;
		public bool infinity;
        public const int maxExampleLifeFruits = 10;
        public int exampleLifeFruits;

        public int constantDamage { get; internal set; }
        public override void ResetEffects () {
                  player.statLifeMax2 += exampleLifeFruits * 2;
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = mod.GetPacket();
			packet.Write(exampleLifeFruits);
			packet.Send(toWho, fromWho);
		}
        public override TagCompound Save() {
			// Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
			return new TagCompound {
				{"exampleLifeFruits", exampleLifeFruits},


			};
			//note that C# 6.0 supports indexer initializers
			//return new TagCompound {
			//	["score"] = score
			//};
		}

		public override void Load(TagCompound tag) {
			
			exampleLifeFruits = tag.GetInt("exampleLifeFruits");
			}

		private void PuritySpiritTeleport(NPC npc) {
			int halfWidth = PuritySpirit.arenaWidth / 2;
			int halfHeight = PuritySpirit.arenaHeight / 2;
			Vector2 newPosition = player.position;
			if (player.position.X <= npc.Center.X - halfWidth) {
				newPosition.X = npc.Center.X + halfWidth - player.width - 1;
				while (Collision.SolidCollision(newPosition, player.width, player.height)) {
					newPosition.X -= 16f;
				}
			}
			else if (player.position.X + player.width >= npc.Center.X + halfWidth) {
				newPosition.X = npc.Center.X - halfWidth + 1;
				while (Collision.SolidCollision(newPosition, player.width, player.height)) {
					newPosition.X += 16f;
				}
			}
			else if (player.position.Y <= npc.Center.Y - halfHeight) {
				newPosition.Y = npc.Center.Y + halfHeight - player.height - 1;
				while (Collision.SolidCollision(newPosition, player.width, player.height)) {
					newPosition.Y -= 16f;
				}
			}
			else if (player.position.Y + player.height >= npc.Center.Y + halfHeight) {
				newPosition.Y = npc.Center.Y - halfHeight + 1;
				while (Collision.SolidCollision(newPosition, player.width, player.height)) {
					newPosition.Y += 16f;
				}
			}
			if (newPosition != player.position) {
				player.Teleport(newPosition, 1, 0);
				NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, player.whoAmI, newPosition.X, newPosition.Y, 1, 0, 0);
			}
		}
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
			if (heroLives > 0) {
				heroLives--;
				if (Main.netMode == NetmodeID.MultiplayerClient) {
					ModPacket packet = mod.GetPacket();
					packet.Write(player.whoAmI);
					packet.Write(heroLives);
					packet.Send();
				}
				if (heroLives > 0) {
					player.statLife = player.statLifeMax2;
					player.HealEffect(player.statLifeMax2);
					player.immune = true;
					player.immuneTime = player.longInvince ? 180 : 120;
					for (int k = 0; k < player.hurtCooldowns.Length; k++) {
						player.hurtCooldowns[k] = player.longInvince ? 180 : 120;
					}
					Main.PlaySound(SoundID.Item29, player.position);
					reviveTime = 60;
					return false;
				}
			}
			if (healHurt > 0 && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) {
				damageSource = PlayerDeathReason.ByCustomReason(" was dissolved by holy powers");
			}
			return true;
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
            
            if (questFish == ItemType<ExampleQuestFish>() && Main.rand.NextBool())
            {
                caughtType = ItemType<ExampleQuestFish>();
            }
        }
        public override void GetFishingLevel(Item fishingRod, Item bait, ref int fishingLevel)
		{
		}
	}
}
