using MyFirstBasicMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.NPCs.Abomination
{
	//ported from my tAPI mod because I'm lazy
	// Abomination is a multi-stage boss.
	[AutoloadBossHead]
	public class Abomination : ModNPC
    {
        private static int hellLayer => Main.maxTilesY - 200;

		private const int sphereRadius = 300;

		private float attackCool
		{
			get => NPC.ai[0];
			set => NPC.ai[0] = value;
		}

		private float moveCool
		{
			get => NPC.ai[1];
			set => NPC.ai[1] = value;
		}

		private float rotationSpeed
		{
			get => NPC.ai[2];
			set => NPC.ai[2] = value;
		}

		private float captiveRotation
		{
			get => NPC.ai[3];
			set => NPC.ai[3] = value;
		}

		private int moveTime = 300;
		private int moveTimer = 60;
		internal int laserTimer;
		internal int laser1 = -1;
		internal int laser2 = -1;
		private bool dontDamage;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Abomination");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 40000;
			NPC.damage = 100;
			NPC.defense = 55;
			NPC.knockBackResist = 0f;
			NPC.width = 100;
			NPC.height = 100;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.npcSlots = 15f;
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.buffImmune[24] = true;
			music = MusicID.Boss2;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
			NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public override void AI()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient && NPC.localAI[0] == 0f)
			{
				for (int k = 0; k < 5; k++)
				{
					int captive = NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y, NPCType<CaptiveElement>());
					Main.npc[captive].ai[0] = NPC.whoAmI;
					Main.npc[captive].ai[1] = k;
					Main.npc[captive].ai[2] = 50 * (k + 1);
					if (k == 2)
					{
						Main.npc[captive].damage += 20;
					}
					CaptiveElement.SetPosition(Main.npc[captive]);
					Main.npc[captive].netUpdate = true;
				}
				NPC.netUpdate = true;
				NPC.localAI[0] = 1f;
			}
			Player player = Main.player[NPC.target];
			if (!player.active || player.dead || player.position.Y < hellLayer * 16)
			{
				NPC.TargetClosest(false);
				player = Main.player[NPC.target];
				if (!player.active || player.dead || player.position.Y < hellLayer * 16)
				{
					NPC.velocity = new Vector2(0f, 10f);
					if (NPC.timeLeft > 10)
					{
						NPC.timeLeft = 10;
					}
					return;
				}
			}
			moveCool -= 1f;
			if (Main.netMode != NetmodeID.MultiplayerClient && moveCool <= 0f)
			{
				NPC.TargetClosest(false);
				player = Main.player[NPC.target];
				double angle = Main.rand.NextDouble() * 2.0 * Math.PI;
				int distance = sphereRadius + Main.rand.Next(200);
				Vector2 moveTo = player.Center + (float)distance * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				moveCool = (float)moveTime + (float)Main.rand.Next(100);
				NPC.velocity = (moveTo - NPC.Center) / moveCool;
				rotationSpeed = (float)(Main.rand.NextDouble() + Main.rand.NextDouble());
				if (rotationSpeed > 1f)
				{
					rotationSpeed = 1f + (rotationSpeed - 1f) / 2f;
				}
				if (Main.rand.NextBool())
				{
					rotationSpeed *= -1;
				}
				rotationSpeed *= 0.01f;
				NPC.netUpdate = true;
			}
			if (Vector2.Distance(Main.player[NPC.target].position, NPC.position) > sphereRadius)
			{
				moveTimer--;
			}
			else
			{
				moveTimer += 3;
				if (moveTime >= 300 && moveTimer > 60)
				{
					moveTimer = 60;
				}
			}
			if (moveTimer <= 0)
			{
				moveTimer += 60;
				moveTime -= 3;
				if (moveTime < 99)
				{
					moveTime = 99;
					moveTimer = 0;
				}
				NPC.netUpdate = true;
			}
			else if (moveTimer > 60)
			{
				moveTimer -= 60;
				moveTime += 3;
				NPC.netUpdate = true;
			}
			captiveRotation += rotationSpeed;
			if (captiveRotation < 0f)
			{
				captiveRotation += 2f * (float)Math.PI;
			}
			if (captiveRotation >= 2f * (float)Math.PI)
			{
				captiveRotation -= 2f * (float)Math.PI;
			}
			attackCool -= 1f;
			if (Main.netMode != NetmodeID.MultiplayerClient && attackCool <= 0f)
			{
				attackCool = 200f + 200f * (float)NPC.life / (float)NPC.lifeMax + (float)Main.rand.Next(200);
				Vector2 delta = player.Center - NPC.Center;
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
				
				Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, delta.X, delta.Y, ProjectileType<ElementBall>(), damage, 3f, Main.myPlayer, BuffID.OnFire, 600f);
				NPC.netUpdate = true;
			}
			if (Main.expertMode)
			{
				ExpertLaser();
			}
			if (Main.rand.NextBool())
			{
				float radius = (float)Math.Sqrt(Main.rand.Next(sphereRadius * sphereRadius));
				double angle = Main.rand.NextDouble() * 2.0 * Math.PI;
			}
		}

		private void ExpertLaser()
		{
			laserTimer--;
			if (laserTimer <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
			{
				if (NPC.localAI[0] == 2f)
				{
					int laser1Index;
					int laser2Index;
					if (laser1 < 0)
					{
						laser1Index = NPC.whoAmI;
					}
					else
					{
						for (laser1Index = 0; laser1Index < 200; laser1Index++)
						{
							if (Main.npc[laser1Index].type == NPCType<CaptiveElement>() && laser1 == Main.npc[laser1Index].ai[1])
							{
								break;
							}
						}
					}
					if (laser2 < 0)
					{
						laser2Index = NPC.whoAmI;
					}
					else
					{
						for (laser2Index = 0; laser2Index < 200; laser2Index++)
						{
							if (Main.npc[laser2Index].type == NPCType<CaptiveElement>() && laser2 == Main.npc[laser2Index].ai[1])
							{
								break;
							}
						}
					}
					Vector2 pos = Main.npc[laser1Index].Center;
					int damage = Main.npc[laser1Index].damage / 2;
		
					Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, ProjectileType<ElementLaser>(), damage, 0f, Main.myPlayer, laser1Index, laser2Index);
				}
				else
				{
					NPC.localAI[0] = 2f;
				}
				laserTimer = 500 + Main.rand.Next(100);
				laserTimer = 60 + laserTimer * NPC.life / NPC.lifeMax;
				laser1 = Main.rand.Next(6) - 1;
				laser2 = Main.rand.Next(5) - 1;
				if (laser2 >= laser1)
				{
					laser2++;
				}
			}
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write((short)moveTime);
			writer.Write((short)moveTimer);
			if (Main.expertMode)
			{
				writer.Write((short)laserTimer);
				writer.Write((byte)(laser1 + 1));
				writer.Write((byte)(laser2 + 1));
			}
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			moveTime = reader.ReadInt16();
			moveTimer = reader.ReadInt16();
			if (Main.expertMode)
			{
				laserTimer = reader.ReadInt16();
				laser1 = reader.ReadByte() - 1;
				laser2 = reader.ReadByte() - 1;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			if (attackCool < 50f)
			{
				NPC.frame.Y = frameHeight;
			}
			else
			{
				NPC.frame.Y = 0;
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int k = 0; k < damage / NPC.lifeMax * 100.0; k++)
			{
			}
			if (Main.netMode != NetmodeID.MultiplayerClient && NPC.life <= 0)
			{
				Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.height / 2f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, NPCType<AbominationRun>());
			}
		}

		// We use this hook to prevent any loot from dropping. We do this because this is a multistage NPC and it shouldn't drop anything until the final form is dead.


		// We use this method to inflict a debuff on a player on contact. OnFire is inflicted 100% of the time in expert, and 50% of the time on non-expert mode.
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode || Main.rand.NextBool())
			{
				player.AddBuff(BuffID.OnFire, 600, true);
			}
		}

		public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			dontDamage = (player.Center - NPC.Center).Length() > sphereRadius;
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			dontDamage = player.active && (player.Center - NPC.Center).Length() > sphereRadius;
		}

		public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (dontDamage)
			{
				damage = 0;
				crit = true;
				dontDamage = false;
				SoundEngine.PlaySound(NPC.HitSound, NPC.position);
				return false;
			}
			return true;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			if (Main.expertMode && laserTimer <= 60 && (laser1 == -1 || laser2 == -1))
			{
				float rotation = laserTimer / 30f;
				if (laser1 == -1)
				{
					rotation *= -1f;
				}
			}
			return true;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
			return null;
		}
	}
}