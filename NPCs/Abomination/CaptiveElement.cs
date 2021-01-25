using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;

namespace MyFirstBasicMod.NPCs.Abomination
{
	//ported from my tAPI mod because I'm lazy
	[AutoloadBossHead]
	public class CaptiveElement : ModNPC
	{
		public const string CaptiveElementHead = "MyFirstBasicMod/NPCs/Abomination/CaptiveElement_Head_Boss_";

		

		private int center
		{
			get => (int)NPC.ai[0];
			set => NPC.ai[0] = value;
		}

		private int captiveType
		{
			get => (int)NPC.ai[1];
			set => NPC.ai[1] = value;
		}

		private float attackCool
		{
			get => NPC.ai[2];
			set => NPC.ai[2] = value;
		}

		private int change
		{
			get => (int)NPC.ai[3];
			set => NPC.ai[3] = value;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Captive Element");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 15000;
			NPC.damage = 100;
			NPC.defense = 55;
			NPC.knockBackResist = 0f;
			NPC.dontTakeDamage = true;
			NPC.width = 100;
			NPC.height = 100;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.npcSlots = 10f;
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			music = MusicID.Boss2;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * bossLifeScale);
			NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public override void AI()
		{
			NPC abomination = Main.npc[center];
			if (!abomination.active || abomination.type != NPCType<Abomination>())
			{
				if (change > 0 || NPC.AnyNPCs(NPCType<AbominationRun>()))
				{
					if (change == 0)
					{
						NPC.netUpdate = true;
					}
					change++;
				}
				else
				{
					NPC.life = -1;
					NPC.active = false;
					return;
				}
			}
			if (change > 0)
			{
				Color? color = GetColor();
				if (color.HasValue)
				{
					for (int x = 0; x < 5; x++)
					{
						double angle = Main.rand.NextDouble() * 2.0 * Math.PI;
					}
				}
				if (Main.netMode != NetmodeID.MultiplayerClient && change >= 100f)
				{
					int next = NPC.NewNPC((int)NPC.Center.X, (int)NPC.position.Y + NPC.height, NPCType<CaptiveElement2>());
					Main.npc[next].ai[0] = captiveType;
					if (captiveType != 4)
					{
						Main.npc[next].ai[1] = 300f + (float)Main.rand.Next(100);
					}
					NPC.life = -1;
					NPC.active = false;
				}
				return;
			}
			else if (NPC.timeLeft < 750)
			{
				NPC.timeLeft = 750;
			}
			if (NPC.localAI[0] == 0f)
			{
				if (GetDebuff() >= 0f)
				{
					NPC.buffImmune[GetDebuff()] = true;
				}
				if (captiveType == 3f)
				{
					NPC.buffImmune[20] = true;
				}
				if (captiveType == 0f)
				{
					NPC.coldDamage = true;
				}
				NPC.localAI[0] = 1f;
			}
			SetPosition(NPC);
			attackCool -= 1f;
			if (Main.netMode != NetmodeID.MultiplayerClient && attackCool <= 0f)
			{
				attackCool = 200f + 200f * (float)abomination.life / (float)abomination.lifeMax + (float)Main.rand.Next(200);
				Vector2 delta = Main.player[abomination.target].Center - NPC.Center;
				float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
				if (magnitude > 0)
				{
					delta *= 5f / magnitude;
				}
				else
				{
					delta = new Vector2(0f, 5f);
				}
				int damage = (NPC.damage - 30) / 2;
				
				Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, delta.X, delta.Y, ProjectileType<ElementBall>(), damage, 3f, Main.myPlayer, GetDebuff(), GetDebuffTime());
				NPC.netUpdate = true;
			}
		}

		public static void SetPosition(NPC NPC)
		{
			CaptiveElement modNPC = NPC.ModNPC as CaptiveElement;
			if (modNPC != null)
			{
				Vector2 center = Main.npc[modNPC.center].Center;
				double angle = Main.npc[modNPC.center].ai[3] + 2.0 * Math.PI * modNPC.captiveType / 5.0;
				NPC.position = center + 300f * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) - NPC.Size / 2f;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frame.Y = captiveType * frameHeight;
			if (captiveType == 1)
			{
				NPC.alpha = 100;
			}
			if (attackCool < 50f)
			{
				NPC.frame.Y += 5 * frameHeight;
			}
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
					time = 400;
					break;
				case 1:
					time = 300;
					break;
				case 3:
					time = 400;
					break;
				case 4:
					time = 900;
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
				index = ModContent.GetModBossHeadSlot(CaptiveElementHead + captiveType);
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Abomination abomination = Main.npc[center].ModNPC as Abomination;
			if (Main.expertMode && abomination != null && abomination.NPC.active && abomination.laserTimer <= 60 && (abomination.laser1 == captiveType || abomination.laser2 == captiveType))
			{
				Color? color = GetColor();
				if (!color.HasValue)
				{
					color = Color.White;
				}
				float rotation = abomination.laserTimer / 30f;
				if (abomination.laser1 == captiveType)
				{
					rotation *= -1f;
				}
			}
			return true;
		}
	}
}