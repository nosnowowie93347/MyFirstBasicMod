using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs
	{
		// This ModNPC serves as an example of a complete AI example.
		public class FlyingTest: ModNPC
			{
				public override void SetStaticDefaults()
				{
				 	DisplayName.SetDefault("TEST");	// Automatic from .lang files
					Main.npcFrameCount[npc.type] = 6;	// make sure to set this for your modnpcs.
				}

				public override void SetDefaults()
				{
					npc.width = 32;
					npc.height = 32;
					npc.aiStyle = -1;	// This npc has a completely unique AI, so we set this to -1. The default aiStyle 0 will face the player, which might conflict with custom AI code.
					npc.damage = 16;
					npc.defense = 11;
					npc.lifeMax = 920;
					npc.HitSound = SoundID.NPCHit1;
					npc.DeathSound = SoundID.NPCDeath1;
					//npc.alpha = 175;
					//npc.color = new Color(0, 80, 255, 100);
					npc.value = 25 f;
					npc.buffImmune[BuffID.Poisoned] = true;
					npc.buffImmune[BuffID.Confused] = false;	// npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
				}

				public override float SpawnChance(NPCSpawnInfo spawnInfo)
				{
				 		// we would like this npc to spawn in the overworld.
					return SpawnCondition.OverworldDaySlime.Chance *0.1 f;
				}

				public void AI()
				{
					npc.TargetClosest(true);

					if (npc.ai[1] == 0)	// First AI
					{
						if (Main.player[npc.target].position.X < npc.position.X)
						{
							if (npc.velocity.X > -8) npc.velocity.X -= 0.22 f;
						}

						if (Main.player[npc.target].position.X > npc.position.X)
						{
							if (npc.velocity.X < 8) npc.velocity.X += 0.22 f;
						}

						if (Main.player[npc.target].position.Y < npc.position.Y + 300)
						{
							if (npc.velocity.Y < 0)
							{
								if (npc.velocity.Y > -4) npc.velocity.Y -= 0.7 f;
							}
							else npc.velocity.Y -= 0.8 f;
						}

						if (Main.player[npc.target].position.Y > npc.position.Y + 300)
						{
							if (npc.velocity.Y > 0)
							{
								if (npc.velocity.Y < 4) npc.velocity.Y += 0.7 f;
							}
							else npc.velocity.Y += 0.8 f;
						}

						npc.ai[0]++;

						if (npc.ai[0] >= 90)
						{
							float Speed = 12 f;
							Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
							int damage = 30;
							Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 17);
							float rotation = (float) Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height *0.5 f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width *0.5 f)));
							int num54 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 6, -2, ProjectileID.FrostBlastHostile, projectile.damage, projectile.knockBack, Main.myPlayer);
							npc.ai[0] = 0;
						}
					}

					if (npc.ai[1] == 1)	// Second AI
					{
					 			// NPC AI HERE
					}

					npc.ai[2] += 1;
					if (npc.ai[2] >= 600)
					{
						if (npc.ai[1] == 0) npc.ai[1] = 1;
						else npc.ai[1] = 0;
					}
				}