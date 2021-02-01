using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.Chat;

namespace MyFirstBasicMod.NPCs.Overseer
{
	[AutoloadBossHead]
	public class Overseer : ModNPC
	{

		bool secondphase = false;
		int movementCounter;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Overseer");
			Main.npcFrameCount[NPC.type] = 7;
		}

		public override void SetDefaults()
		{
			NPC.width = 148;
			NPC.height = 172;

			NPC.damage = 76;
			NPC.defense = 50;
			NPC.lifeMax = 17900;
			NPC.knockBackResist = 0;

			NPC.boss = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.npcSlots = 10;
			bossBag = ModContent.ItemType<Items.OverseerBag>();
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath5;
		}




        public override void ModifyNPCLoot(NPCLoot NPCLoot)
        {
      
			if (Main.expertMode) {
				NPC.DropBossBags();
				return;
			}

            NPCLoot.Add(new CommonDrop(ModContent.ItemType<Items.EpicSoul>(), 13, 1, 10, 13));
            NPCLoot.Add(new CommonDrop(ModContent.ItemType<Items.Weapons.TerrabotsGun>(), 10, 1, 1, 10));
            NPCLoot.Add(new CommonDrop(ModContent.ItemType<Items.Consumables.DiamondskinPotion>(), 19, 5, 13, 19));
            NPCLoot.Add(new CommonDrop(ModContent.ItemType<Items.Weapons.ElenasSpear>(), 17, 1, 1, 17));
           
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemType<Items.GodlyHealingPotion>();
            
		}


		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.type == ProjectileID.LastPrismLaser) {
				damage /= 3;
			}
		}
		private void DespawnHandler()
		{
			Player player = Main.player[NPC.target];
			if (!player.active || player.dead) {
				NPC.velocity *= 0.96f;
				NPC.velocity.Y -= 1;
				if (NPC.timeLeft > 10) {
					NPC.timeLeft = 10;
				}
				return;
			}
		}
		public override bool PreAI()
		{
			//THE END OF DAYS COMES AND HELL COMES TO EARTH AND IN THOSE DAYS MEN SHALL SEEK DEATH, AND SHALL IN NO WISE FIND IT; AND THEY SHALL DESIRE TO DIE, AND DEATH FLEETH FROM THEM.
			//UPON SOUNDING THE FIFTH TRUMPET, A STAR FELL FROM HEAVEN TO THE EARTH. HAVING CEASED TO BE A MINISTER OF CHRIST, HE WHO IS REPRESENTED BY THIS STAR BECOMES THE MINISTER OF THE DEVIL; AND LETS LOOSE THE POWERS OF HELL AGAINST THE CHURCHES OF CHRIST. ON THE OPENING OF THE BOTTOMLESS PIT, THERE AROSE A GREAT SMOKE. THE DEVIL CARRIES ON HIS DESIGNS BY BLINDING THE EYES OF MEN, BY PUTTING OUT LIGHT AND KNOWLEDGE, AND PROMOTING IGNORANCE AND ERROR. OUT OF THIS SMOKE THERE CAME A SWARM OF LOCUSTS, EMBLEMS OF THE DEVIL'S AGENTS, WHO PROMOTE SUPERSTITION, IDOLATRY, ERROR, AND CRUELTY. THE TREES AND THE GRASS, THE TRUE BELIEVERS, WHETHER YOUNG OR MORE ADVANCED, SHOULD BE UNTOUCHED. BUT A SECRET POISON AND INFECTION IN THE SOUL, SHOULD ROB MANY OTHERS OF PURITY, AND AFTERWARDS OF PEACE. THE LOCUSTS HAD NO POWER TO HURT THOSE WHO HAD THE SEAL OF GOD. GOD'S ALL-POWERFUL, DISTINGUISHING GRACE WILL KEEP HIS PEOPLE FROM TOTAL AND FINAL APOSTACY. THE POWER IS LIMITED TO A SHORT SEASON; BUT IT WOULD BE VERY SHARP. IN SUCH EVENTS THE FAITHFUL SHARE THE COMMON CALAMITY, BUT FROM THE PESTILENCE OF ERROR THEY MIGHT AND WOULD BE SAFE. WE COLLECT FROM SCRIPTURE, THAT SUCH ERRORS WERE TO TRY AND PROVE THE CHRISTIANS, 1CO 11:19. AND EARLY WRITERS PLAINLY REFER THIS TO THE FIRST GREAT HOST OF CORRUPTERS WHO OVERSPREAD THE CHRISTIAN CHURCH.
			NPC.TargetClosest(true);
			Player player10 = Main.player[NPC.target];
			DespawnHandler();
			Lighting.AddLight((int)((NPC.position.X + (float)(NPC.width / 2)) / 16f), (int)((NPC.position.Y + (float)(NPC.height / 2)) / 16f), 0.0f, 0.04f, 0.8f);
			if (NPC.ai[0] == 0) {
				if (NPC.life > (NPC.lifeMax / 2)) {
					#region ai phase 1
					movementCounter++;
					NPC.TargetClosest(true);
					if (movementCounter < 800) {
						Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
						direction.Normalize();
						NPC.velocity *= 0.985f;
						int dust2 = Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, 206, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
						Main.dust[dust2].noGravity = true;
						if (Math.Sqrt((NPC.velocity.X * NPC.velocity.X) + (NPC.velocity.Y * NPC.velocity.Y)) >= 7f) {
							int dust = Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, 206, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
							Main.dust[dust].noGravity = true;
							Main.dust[dust].scale = 2f;
							dust = Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, 206, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
							Main.dust[dust].noGravity = true;
							Main.dust[dust].scale = 2f;
						}
						if (Math.Sqrt((NPC.velocity.X * NPC.velocity.X) + (NPC.velocity.Y * NPC.velocity.Y)) < 13f) {
							if (Main.rand.Next(18) == 1) {
								direction.X = direction.X * Main.rand.Next(21, 27);
								direction.Y = direction.Y * Main.rand.Next(21, 27);
								NPC.velocity.X = direction.X;
								NPC.velocity.Y = direction.Y;
							}
						}
						//   if (Math.Sqrt((NPC.velocity.X * NPC.velocity.X) + (NPC.velocity.Y * NPC.velocity.Y)) < 10f)
						// {
						//       if (Main.rand.Next(18) == 1)
						//       {
						//          direction.X = direction.X * Main.rand.Next(20, 23);
						//          direction.Y = direction.Y * Main.rand.Next(20, 23);
						//          NPC.velocity.X = direction.X;
						//          NPC.velocity.Y = direction.Y;
						//     }
						// }
						if (movementCounter % 150 == 50) {
							Vector2 direction9 = Main.player[NPC.target].Center - NPC.Center;
							direction9.Normalize();
							direction9.X *= 15f;
							direction9.Y *= 15f;

							int amountOfProjectiles = Main.rand.Next(7, 11);
							for (int i = 0; i < amountOfProjectiles; ++i) {
								float A = (float)Main.rand.Next(-250, 250) * 0.01f;
								float B = (float)Main.rand.Next(-250, 250) * 0.01f;
								Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, direction9.X + A, direction9.Y + B, ModContent.ProjectileType<CoreShard>(), 120, 1, Main.myPlayer, 0, 0);
							}
						}
					}
					if (movementCounter == 800) {
						NPC.velocity.X = 0;
						NPC.velocity.Y = 0;
					}
					if (movementCounter > 800) {
						if (movementCounter % 100 == 50) {
							Vector2 direction8 = Main.player[NPC.target].Center - NPC.Center;
							direction8.Normalize();
							direction8.X *= 28f;
							direction8.Y *= 28f;

							int amountOfProjectiles = Main.rand.Next(10, 15);
							for (int i = 0; i < amountOfProjectiles; ++i) {
								float A = (float)Main.rand.Next(-250, 250) * 0.01f;
								float B = (float)Main.rand.Next(-250, 250) * 0.01f;
								Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, direction8.X + A, direction8.Y + B, ModContent.ProjectileType<SpiritShard>(), 90, 1, Main.myPlayer, 0, 0);
							}
						}
						float speed = 14f;
						float acceleration = 0.12f;
						Vector2 vector2 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
						float xDir = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector2.X;
						float yDir = (float)(Main.player[NPC.target].position.Y + (Main.player[NPC.target].height / 2) - 120) - vector2.Y;
						float length = (float)Math.Sqrt(xDir * xDir + yDir * yDir);
						if (length > 400 && Main.expertMode) {
							++speed;
							acceleration += 0.05F;
							if (length > 600) {
								++speed;
								acceleration += 0.08F;
								if (length > 800) {
									++speed;
									acceleration += 0.05F;
								}
							}
						}
						float num10 = speed / length;
						xDir = xDir * num10;
						yDir = yDir * num10;
						if (NPC.velocity.X < xDir) {
							NPC.velocity.X = NPC.velocity.X + acceleration;
							if (NPC.velocity.X < 0 && xDir > 0)
								NPC.velocity.X = NPC.velocity.X + acceleration;
						}
						else if (NPC.velocity.X > xDir) {
							NPC.velocity.X = NPC.velocity.X - acceleration;
							if (NPC.velocity.X > 0 && xDir < 0)
								NPC.velocity.X = NPC.velocity.X - acceleration;
						}
						if (NPC.velocity.Y < yDir) {
							NPC.velocity.Y = NPC.velocity.Y + acceleration;
							if (NPC.velocity.Y < 0 && yDir > 0)
								NPC.velocity.Y = NPC.velocity.Y + acceleration;
						}
						else if (NPC.velocity.Y > yDir) {
							NPC.velocity.Y = NPC.velocity.Y - acceleration;
							if (NPC.velocity.Y > 0 && yDir < 0)
								NPC.velocity.Y = NPC.velocity.Y - acceleration;
						}
					}
					if (movementCounter > 1400)
						movementCounter = 0;
					#endregion
				}
				else {
					#region Ai phase 2
					if (!secondphase) {
						secondphase = true;
					}
					movementCounter++;
					NPC.TargetClosest(true);
					if (movementCounter < 800) {
						if (movementCounter % 120 == 50) {
							Vector2 direction9 = Main.player[NPC.target].Center - NPC.Center;
							direction9.Normalize();
							direction9.X *= 16f;
							direction9.Y *= 16f;

							int amountOfProjectiles = Main.rand.Next(7, 11);
							for (int i = 0; i < amountOfProjectiles; ++i) {
								float A = (float)Main.rand.Next(-250, 250) * 0.01f;
								float B = (float)Main.rand.Next(-250, 250) * 0.01f;
								Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, direction9.X + A, direction9.Y + B, ModContent.ProjectileType<CoreShard>(), 130, 1, Main.myPlayer, 0, 0);
							}
						}

						Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
						direction.Normalize();
						NPC.velocity *= 0.983f;
						int dust2 = Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, 206, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
						Main.dust[dust2].noGravity = true;
						if (Math.Sqrt((NPC.velocity.X * NPC.velocity.X) + (NPC.velocity.Y * NPC.velocity.Y)) >= 7f) {
							int dust = Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, 206, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
							Main.dust[dust].noGravity = true;
							Main.dust[dust].scale = 2f;
							dust = Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, 206, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
							Main.dust[dust].noGravity = true;
							Main.dust[dust].scale = 2f;
						}

						if (Math.Sqrt((NPC.velocity.X * NPC.velocity.X) + (NPC.velocity.Y * NPC.velocity.Y)) < 14f) {
							if (Main.rand.Next(18) == 1) {
								direction.X = direction.X * Main.rand.Next(27, 31);
								direction.Y = direction.Y * Main.rand.Next(27, 31);
								NPC.velocity.X = direction.X;
								NPC.velocity.Y = direction.Y;
							}
						}
						//   if (Math.Sqrt((NPC.velocity.X * NPC.velocity.X) + (NPC.velocity.Y * NPC.velocity.Y)) < 10f)
						// {
						//       if (Main.rand.Next(18) == 1)
						//       {
						//          direction.X = direction.X * Main.rand.Next(20, 23);
						//          direction.Y = direction.Y * Main.rand.Next(20, 23);
						//          NPC.velocity.X = direction.X;
						//          NPC.velocity.Y = direction.Y;
						//     }
						// }
					}
					if (movementCounter == 800) //spawn portals
					{
						NPC.velocity.X = 0;
						NPC.velocity.Y = 0;
					}

					if (movementCounter > 800) {
						if (movementCounter % 75 == 50) {
							Vector2 direction8 = Main.player[NPC.target].Center - NPC.Center;
							direction8.Normalize();
							direction8.X *= 24f;
							direction8.Y *= 28f;

							int amountOfProjectiles = Main.rand.Next(10, 15);
							for (int i = 0; i < amountOfProjectiles; ++i) {
								float A = (float)Main.rand.Next(-350, 350) * 0.01f;
								float B = (float)Main.rand.Next(-350, 350) * 0.01f;
								Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, direction8.X + A, direction8.Y + B, ModContent.ProjectileType<SpiritShard>(), 87, 1, NPC.target, 0, 0);
							}
						}

						float speed = 15f;
						float acceleration = 0.13f;
						Vector2 vector2 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
						float xDir = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector2.X;
						float yDir = (float)(Main.player[NPC.target].position.Y + (Main.player[NPC.target].height / 2) - 120) - vector2.Y;
						float length = (float)Math.Sqrt(xDir * xDir + yDir * yDir);
						if (length > 400 && Main.expertMode) {
							++speed;
							acceleration += 0.05F;
							if (length > 600) {
								++speed;
								acceleration += 0.08F;
								if (length > 800) {
									++speed;
									acceleration += 0.05F;
								}
							}
						}
						float num10 = speed / length;
						xDir = xDir * num10;
						yDir = yDir * num10;
						if (NPC.velocity.X < xDir) {
							NPC.velocity.X = NPC.velocity.X + acceleration;
							if (NPC.velocity.X < 0 && xDir > 0)
								NPC.velocity.X = NPC.velocity.X + acceleration;
						}
						else if (NPC.velocity.X > xDir) {
							NPC.velocity.X = NPC.velocity.X - acceleration;
							if (NPC.velocity.X > 0 && xDir < 0)
								NPC.velocity.X = NPC.velocity.X - acceleration;
						}
						if (NPC.velocity.Y < yDir) {
							NPC.velocity.Y = NPC.velocity.Y + acceleration;
							if (NPC.velocity.Y < 0 && yDir > 0)
								NPC.velocity.Y = NPC.velocity.Y + acceleration;
						}
						else if (NPC.velocity.Y > yDir) {
							NPC.velocity.Y = NPC.velocity.Y - acceleration;
							if (NPC.velocity.Y > 0 && yDir < 0)
								NPC.velocity.Y = NPC.velocity.Y - acceleration;
						}
					}
					if (movementCounter > 1600) {
						for (int I = 0; I < 2; I++) {
							//cos = y, sin = x
							int portal = Projectile.NewProjectile((int)(Main.player[NPC.target].Center.X + (Math.Sin(I * 180) * 500)), (int)(Main.player[NPC.target].Center.Y + (Math.Cos(I * 180) * 500)), 0, 0, ModContent.ProjectileType<SpiritPortal>(), NPC.damage, 1, NPC.target, 0, 0);
							Projectile Eye = Main.projectile[portal];
							Eye.ai[0] = I * 180;
						}
						movementCounter = 0;
					}
					#endregion
				}

				if (player10.active && !player10.dead) {
					#region teleportation
					if (Main.rand.Next(300) == 0) {
						int teleport = Projectile.NewProjectile(Main.player[NPC.target].Center.X + Main.rand.Next(-600, 600), Main.player[NPC.target].Center.Y + Main.rand.Next(-600, 600), 0, 0, ModContent.ProjectileType<SeerPortal>(), 55, 0, NPC.target);
						Projectile tele = Main.projectile[teleport];
					}
					#endregion
				}

				NPC.ai[1]++;
				if (NPC.ai[1] >= 180) {
					NPC.TargetClosest(true);

					Vector2 dir = Main.player[NPC.target].Center - NPC.Center;
					dir.Normalize();
					dir *= 8;
					Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, dir.X, dir.Y, ModContent.ProjectileType<HauntedWisp>(), 60, 0, Main.myPlayer);

					NPC.ai[1] = 0;
				}
			}
			return false;
		}

		
		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			if (NPC.frameCounter >= 6) {
				NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
				NPC.frameCounter = 0;
			}
		}
	}
}