﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs
{
	// This ModNPC serves as an example of a complete AI example.
	public class FlutterSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Flutter Slime"); // Automatic from .lang files
			Main.npcFrameCount[NPC.type] = 6; // make sure to set this for your modNPCs.
		}

		public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 32;
			NPC.aiStyle = -1; // This NPC has a completely unique AI, so we set this to -1. The default aiStyle 0 will face the player, which might conflict with custom AI code.
			NPC.damage = 16;
			NPC.defense = 11;
			NPC.lifeMax = 120;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			//NPC.alpha = 175;
			//NPC.color = new Color(0, 80, 255, 100);
			NPC.value = 25f;
			NPC.buffImmune[BuffID.Poisoned] = true;
			NPC.buffImmune[BuffID.Confused] = false; // NPC default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. NPC.confused is true while the NPC is confused.
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			// we would like this NPC to spawn in the overworld.
			return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
		}

		// These const ints are for the benefit of the programmer. Organization is key to making an AI that behaves properly without driving you crazy.
		// Here I lay out what I will use each of the 4 NPC.ai slots for.
		private const int AI_State_Slot = 0;
		private const int AI_Timer_Slot = 1;
		private const int AI_Flutter_Time_Slot = 2;
		private const int AI_Unused_Slot_3 = 3;

		// NPC.localAI will also have 4 float variables available to use. With ModNPC, using just a local class member variable would have the same effect.
		private const int Local_AI_Unused_Slot_0 = 0;
		private const int Local_AI_Unused_Slot_1 = 1;
		private const int Local_AI_Unused_Slot_2 = 2;
		private const int Local_AI_Unused_Slot_3 = 3;

		// Here I define some values I will use with the State slot. Using an ai slot as a means to store "state" can simplify things greatly. Think flowchart.
		private const int State_Asleep = 0;
		private const int State_Notice = 1;
		private const int State_Jump = 2;
		private const int State_Hover = 3;
		private const int State_Fall = 4;

		// This is a property (https://msdn.microsoft.com/en-us/library/x9fsa0sw.aspx), it is very useful and helps keep out AI code clear of clutter.
		// Without it, every instance of "AI_State" in the AI code below would be "NPC.ai[AI_State_Slot]". 
		// Also note that without the "AI_State_Slot" defined above, this would be "NPC.ai[0]".
		// This is all to just make beautiful, manageable, and clean code.
		public float AI_State
		{
			get => NPC.ai[AI_State_Slot];
			set => NPC.ai[AI_State_Slot] = value;
		}

		public float AI_Timer
		{
			get => NPC.ai[AI_Timer_Slot];
			set => NPC.ai[AI_Timer_Slot] = value;
		}

		public float AI_FlutterTime
		{
			get => NPC.ai[AI_Flutter_Time_Slot];
			set => NPC.ai[AI_Flutter_Time_Slot] = value;
		}

		// AdvancedFlutterSlime will need: float in water, diminishing aggo, spawn projectiles.

		// Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
		public override void AI()
		{
			// The NPC starts in the asleep state, waiting for a player to enter range
			if (AI_State == State_Asleep)
			{
				// TargetClosest sets NPC.target to the player.whoAmI of the closest player. the faceTarget parameter means that NPC.direction will automatically be 1 or -1 if the targeted player is to the right or left. This is also automatically flipped if NPC.confused
				NPC.TargetClosest(true);
				// Now we check the make sure the target is still valid and within our specified notice range (500)
				if (NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) < 500f)
				{
					// Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
					AI_State = State_Notice;
					AI_Timer = 0;
				}
			}
			// In this state, a player has been targeted
			else if (AI_State == State_Notice)
			{
				// If the targeted player is in attack range (250).
				if (Main.player[NPC.target].Distance(NPC.Center) < 250f)
				{
					// Here we use our Timer to wait .33 seconds before actually jumping. In FindFrame you'll notice AI_Timer also being used to animate the pre-jump crouch
					AI_Timer++;
					if (AI_Timer >= 20)
					{
						AI_State = State_Jump;
						AI_Timer = 0;
					}
				}
				else
				{
					NPC.TargetClosest(true);
					if (!NPC.HasValidTarget || Main.player[NPC.target].Distance(NPC.Center) > 500f)
					{
						// Out targeted player seems to have left our range, so we'll go back to sleep.
						AI_State = State_Asleep;
						AI_Timer = 0;
					}
				}
			}
			// In this state, we are in the jump. 
			else if (AI_State == State_Jump)
			{
				AI_Timer++;
				if (AI_Timer == 1)
				{
					// We apply an initial velocity the first tick we are in the Jump frame. Remember that -Y is up. 
					NPC.velocity = new Vector2(NPC.direction * 2, -10f);
				}
				else if (AI_Timer > 40)
				{
					// after .66 seconds, we go to the hover state. // TODO, gravity?
					AI_State = State_Hover;
					AI_Timer = 0;
				}
			}
			// In this state, our NPC starts to flutter/fly a little to make it's movement a little bit interesting.
			else if (AI_State == State_Hover)
			{
				AI_Timer += 1;
				// Here we make a decision on how long this flutter will last. We check netmode != 1 to prevent Multiplayer Clients from running this code. (similarly, spawning projectiles should also be wrapped like this)
				// netmode == 0 is SP, netmode == 1 is MP Client, netmode == 2 is MP Server. 
				// Typically in MP, Client and Server maintain the same state by running deterministic code individually. When we want to do something random, we must do that on the server and then inform MP Clients.
				// Informing MP Clients is done automatically by syncing the NPC.ai array over the network whenever NPC.netUpdate is set. Don't set netUpdate unless you do something non-deterministic ("random")
				if (AI_Timer == 1 && Main.netMode != NetmodeID.MultiplayerClient)
				{
					// For reference: without proper syncing: https://gfycat.com/BackAnxiousFerret and with proper syncing: https://gfycat.com/TatteredKindlyDalmatian
					AI_FlutterTime = Main.rand.NextBool() ? 100 : 50;
					NPC.netUpdate = true;
				}
				// Here we add a tiny bit of upward velocity to our NPC.
				NPC.velocity += new Vector2(0, -.35f);
				// ... and some additional X velocity when traveling slow.
				if (Math.Abs(NPC.velocity.X) < 2)
				{
					NPC.velocity += new Vector2(NPC.direction * .05f, 0);
				}
				if (AI_Timer > AI_FlutterTime)
				{
					// after fluttering for 100 ticks (1.66 seconds), our Flutter Slime is tired, so he decides to go into the Fall state.
					AI_State = State_Fall;
					AI_Timer = 0;
				}
			}
			// In this state, we fall untill we hit the ground. Since NPC.noTileCollide is false, our NPC collides with ground it lands on and will have a zero y velocity once it has landed.
			else if (AI_State == State_Fall)
			{
				if (NPC.velocity.Y == 0)
				{
					NPC.velocity.X = 0;
					AI_State = State_Asleep;
					AI_Timer = 0;
				}
			}
		}

		// Our texture is 32x32 with 2 pixels of padding vertically, so 34 is the vertical spacing.  These are for my benefit and the numbers could easily be used directly in the code below, but this is how I keep code organized.
		private const int Frame_Asleep = 0;
		private const int Frame_Notice = 1;
		private const int Frame_Falling = 2;
		private const int Frame_Flutter_1 = 3;
		private const int Frame_Flutter_2 = 4;
		private const int Frame_Flutter_3 = 5;

		// Here in FindFrame, we want to set the animation frame our NPC will use depending on what it is doing.
		// We set NPC.frame.Y to x * frameHeight where x is the xth frame in our spritesheet, counting from 0. For convenience, I have defined some consts above.
		public override void FindFrame(int frameHeight)
		{
			// This makes the sprite flip horizontally in conjunction with the NPC.direction.
			NPC.spriteDirection = NPC.direction;

			// For the most part, our animation matches up with our states.
			if (AI_State == State_Asleep)
			{
				// NPC.frame.Y is the goto way of changing animation frames. NPC.frame starts from the top left corner in pixel coordinates, so keep that in mind.
				NPC.frame.Y = Frame_Asleep * frameHeight;
			}
			else if (AI_State == State_Notice)
			{
				// Going from Notice to Asleep makes our NPC look like it's crouching to jump.
				if (AI_Timer < 10)
				{
					NPC.frame.Y = Frame_Notice * frameHeight;
				}
				else
				{
					NPC.frame.Y = Frame_Asleep * frameHeight;
				}
			}
			else if (AI_State == State_Jump)
			{
				NPC.frame.Y = Frame_Falling * frameHeight;
			}
			else if (AI_State == State_Hover)
			{
				// Here we have 3 frames that we want to cycle through.
				NPC.frameCounter++;
				if (NPC.frameCounter < 10)
				{
					NPC.frame.Y = Frame_Flutter_1 * frameHeight;
				}
				else if (NPC.frameCounter < 20)
				{
					NPC.frame.Y = Frame_Flutter_2 * frameHeight;
				}
				else if (NPC.frameCounter < 30)
				{
					NPC.frame.Y = Frame_Flutter_3 * frameHeight;
				}
				else
				{
					NPC.frameCounter = 0;
				}
			}
			else if (AI_State == State_Fall)
			{
				NPC.frame.Y = Frame_Falling * frameHeight;
			}
		}
	}
}