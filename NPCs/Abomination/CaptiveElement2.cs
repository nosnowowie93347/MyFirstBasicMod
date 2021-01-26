using MyFirstBasicMod.Items;
using MyFirstBasicMod.Items.Armor;
using MyFirstBasicMod.Items.Placeable;
using MyFirstBasicMod.Items.Weapons;
using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;

namespace MyFirstBasicMod.NPCs.Abomination
{
	//ported from my tAPI mod because I'm lazy
	[AutoloadBossHead]
	public class CaptiveElement2 : ModNPC
	{
		public const string CaptiveElement2Head = "MyFirstBasicMod/NPCs/Abomination/CaptiveElement2_Head_Boss_";

		
		private static int hellLayer => Main.maxTilesY - 200;

		private int captiveType
		{
			get => (int)NPC.ai[0];
			set => NPC.ai[0] = value;
		}

		private float attackCool
		{
			get => NPC.ai[1];
			set => NPC.ai[1] = value;
		}

		private int run
		{
			get => (int)NPC.ai[2];
			set => NPC.ai[2] = value;
		}

		private int jungleAI
		{
			get => (int)NPC.ai[3];
			set => NPC.ai[3] = value;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Captive Element");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 15000;
			NPC.damage = 100;
			NPC.defense = 55;
			NPC.knockBackResist = 0f;
			NPC.width = 100;
			NPC.height = 100;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.npcSlots = 10f;
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath7;
			music = MusicID.Boss2;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * bossLifeScale);
			NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public override void AI()
		{
			Player player = Main.player[NPC.target];
			if (NPC.localAI[0] == 0f)
			{
				if (GetDebuff() >= 0f)
				{
					NPC.buffImmune[GetDebuff()] = true;
				}
				if (captiveType == 3)
				{
					NPC.buffImmune[20] = true;
					NPC.ai[3] = 1f;
				}
				if (captiveType == 0)
				{
					NPC.coldDamage = true;
				}
				if (captiveType == 1)
				{
					NPC.alpha = 100;
				}
				if (Main.expertMode)
				{
					NPC.damage = 60;
				}
				if (captiveType == 2)
				{
					NPC.damage += 20;
				}
				NPC.localAI[0] = 1f;
				SoundEngine.PlaySound(SoundID.NPCDeath7, NPC.position);
			}
			//run away
			if ((!player.active || player.dead || player.position.Y + player.height < hellLayer * 16) && run < 2)
			{
				NPC.TargetClosest(false);
				player = Main.player[NPC.target];
				if (!player.active || player.dead || player.position.Y + player.height < hellLayer * 16)
				{
					run = 1;
				}
				else
				{
					run = 0;
				}
			}
			if (run > 0)
			{
				bool flag = true;
				if (run == 1)
				{
					for (int k = 0; k < 200; k++)
					{
						if (Main.npc[k].active && Main.npc[k].type == NPCType<CaptiveElement2>() && Main.npc[k].ai[2] == 0f)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					run = 2;
					NPC.velocity = new Vector2(0f, 10f);
					NPC.rotation = 0.5f * (float)Math.PI;
					if (NPC.timeLeft > 10)
					{
						NPC.timeLeft = 10;
					}
					NPC.netUpdate = true;
					return;
				}
			}
			if (run < 2 && NPC.timeLeft < 750)
			{
				NPC.timeLeft = 750;
			}
			//move
			int count = 0;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && Main.npc[k].type == NPCType<CaptiveElement2>())
				{
					count++;
				}
			}
			if (captiveType != 1 && captiveType != 4)
			{
				Vector2 moveTo = player.Center;
				if (captiveType == 0)
				{
					moveTo.Y -= 320f;
				}
				if (captiveType == 2)
				{
					moveTo.Y += 320f;
				}
				if (captiveType == 3)
				{
					if (jungleAI < 0)
					{
						moveTo.X -= 320f;
					}
					else
					{
						moveTo.X += 320f;
					}
				}
				float minX = moveTo.X - 50f;
				float maxX = moveTo.X + 50f;
				float minY = moveTo.Y;
				float maxY = moveTo.Y;
				if (captiveType == 0)
				{
					minY -= 50f;
				}
				if (captiveType == 2)
				{
					maxY += 50f;
				}
				if (captiveType == 3)
				{
					minY -= 240f;
					maxY += 240f;
				}
				if (NPC.Center.X >= minX && NPC.Center.X <= maxX && NPC.Center.Y >= minY && NPC.Center.Y <= maxY)
				{
					NPC.velocity *= 0.98f;
				}
				else
				{
					Vector2 move = moveTo - NPC.Center;
					float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
					float speed = 10f;
					if (captiveType == 3 && (jungleAI == -5 || jungleAI == 1))
					{
						speed = 8f;
					}
					if (magnitude > speed)
					{
						move *= speed / magnitude;
					}
					float inertia = 10f;
					if (speed == 8f)
					{
						inertia = 20f;
					}
					NPC.velocity = (inertia * NPC.velocity + move) / (inertia + 1);
					magnitude = (float)Math.Sqrt(NPC.velocity.X * NPC.velocity.X + NPC.velocity.Y + NPC.velocity.Y);
					if (magnitude > speed)
					{
						NPC.velocity *= speed / magnitude;
					}
				}
			}
			if (captiveType == 1)
			{
				Vector2 move = player.Center - NPC.Center;
				float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
				if (magnitude > 3.5f)
				{
					move *= 3.5f / magnitude;
				}
				NPC.velocity = move;
			}
			//look and shoot
			if (captiveType != 4)
			{
				LookToPlayer();
				attackCool -= 1f;
				if (attackCool <= 0f && Main.netMode != NetmodeID.MultiplayerClient)
				{
					if (captiveType == 3)
					{
						jungleAI++;
						if (jungleAI == 0)
						{
							jungleAI = 1;
						}
						if (jungleAI == 6)
						{
							jungleAI = -5;
						}
					}
					attackCool = 150f + 100f * (float)NPC.life / (float)NPC.lifeMax + (float)Main.rand.Next(50);
					attackCool *= (float)count / 5f;
					if (captiveType != 3 || jungleAI != -5 && jungleAI != 1)
					{
						int damage = NPC.damage / 3;

						float speed = 5f;
						if (captiveType != 1)
						{
							speed = Main.expertMode ? 9f : 7f;
						}
						Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 5f * (float)Math.Cos(NPC.rotation), speed * (float)Math.Sin(NPC.rotation), ProjectileType<Projectiles.PixelBall>(), damage, 3f, Main.myPlayer, GetDebuff(), GetDebuffTime());
					}
					NPC.TargetClosest(false);
					NPC.netUpdate = true;
				}
			}
			else
			{
				attackCool -= 1f;
				if (attackCool <= 0f)
				{
					attackCool = 80f + 40f * (float)NPC.life / (float)NPC.lifeMax;
					attackCool *= (float)count / 5f;
					NPC.TargetClosest(false);
					LookToPlayer();
					float speed = 12.5f - 2.5f * (float)NPC.life / (float)NPC.lifeMax;
					NPC.velocity = speed * new Vector2((float)Math.Cos(NPC.rotation), (float)Math.Sin(NPC.rotation));
					NPC.netUpdate = true;
				}
				else
				{
					LookInDirection(NPC.velocity);
					NPC.velocity *= 0.995f;
				}
			}
		}

		private void LookToPlayer()
		{
			Vector2 look = Main.player[NPC.target].Center - NPC.Center;
			LookInDirection(look);
		}

		private void LookInDirection(Vector2 look)
		{
			float angle = 0.5f * (float)Math.PI;
			if (look.X != 0f)
			{
				angle = (float)Math.Atan(look.Y / look.X);
			}
			else if (look.Y < 0f)
			{
				angle += (float)Math.PI;
			}
			if (look.X < 0f)
			{
				angle += (float)Math.PI;
			}
			NPC.rotation = angle;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frame.Y = captiveType * frameHeight;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				if (Main.expertMode)
				{
					int next = NPC.NewNPC((int)NPC.Center.X, (int)NPC.position.Y + NPC.height * 3 / 4, NPCType<FreedElement>());
					Main.npc[next].ai[0] = captiveType;
					Main.npc[next].netUpdate = true;
				}
				else
				{
					Color? color = GetColor();
				}
			}
		}



		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
            npcLoot.Add(new CommonDrop(ItemType<Items.Placeable.PinksBar>(), 16));
            npcLoot.Add(new CommonDrop(ItemType<Items.ExampleLifeFruit>(), 4));

            var normalModeRule = new OneFromOptionsDropRule(7, 1, new[]
            {
                ItemType<Items.Test>(),
                ItemType<Items.Weapons.SwordOfDreams>(),
                ItemType<Items.Weapons.TerrabotsGun>(),
                ItemType<Items.Weapons.ElenasSpear>(),
                ItemType<Items.IrohsHamaxe>(),
                ItemType<Items.ExampleLifeFruit>(),
                ItemType<Items.Armor.BreastplateName>()
            });
        }

		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The Abomination";
			potionType = ItemID.GreaterHealingPotion;
		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{
			if (captiveType == 2 && Main.expertMode)
			{
				cooldownSlot = 1;
			}
			return true;
		}

		public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
		{
			if (Main.expertMode || Main.rand.NextBool())
			{
				int debuff = GetDebuff();
				if (debuff >= 0)
				{
					player.AddBuff(debuff, GetDebuffTime(), true);
				}
			}
		}

		public int GetDebuff()
		{
			switch (captiveType)
			{
				case 0:
					return BuffID.Frostburn;
				case 1:
					return BuffID.Poisoned;
				case 3:
					return BuffID.Venom;
				case 4:
					return BuffID.Ichor;
				default:
					return -1;
			}
		}

		public int GetDebuffTime()
		{
			int time;
			switch (captiveType)
			{
				case 0:
					time = 300;
					break;
				case 1:
					time = 200;
					break;
				case 3:
					time = 200;
					break;
				case 4:
					time = 460;
					break;
				default:
					return -1;
			}
			return time;
		}

		public Color? GetColor()
		{
			switch (captiveType)
			{
				case 0:
					return new Color(0, 230, 230);
				case 1:
					return new Color(0, 153, 230);
				case 3:
					return new Color(0, 178, 0);
				case 4:
					return new Color(230, 192, 0);
				default:
					return null;
			}
		}

		public override void BossHeadSlot(ref int index)
		{
			if (captiveType > 0)
			{
				index = ModContent.GetModBossHeadSlot(CaptiveElement2Head + captiveType);
			}
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f;
			return null;
		}
	}
}