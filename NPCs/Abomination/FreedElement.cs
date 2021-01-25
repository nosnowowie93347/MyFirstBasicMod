using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.NPCs.Abomination
{
	public class FreedElement : ModNPC
	{
		private int elementType
		{
			get => (int)NPC.ai[0];
			set => NPC.ai[0] = value;
		}

		private int chargeTimer
		{
			get => (int)NPC.ai[1];
			set => NPC.ai[1] = value;
		}

		private float chargeX
		{
			get => NPC.ai[2];
			set => NPC.ai[2] = value;
		}

		private float chargeY
		{
			get => NPC.ai[3];
			set => NPC.ai[3] = value;
		}

		public override string Texture => "MyFirstBasicMod/NPCs/Abomination/CaptiveElement2";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Freed Element");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 15000;
			NPC.damage = 100;
			NPC.defense = 55;
			NPC.knockBackResist = 0f;
			NPC.dontTakeDamage = true;
			NPC.alpha = 255;
			NPC.width = 50;
			NPC.height = 50;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.npcSlots = 5f;
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
			if (NPC.localAI[0] == 0f)
			{
				if (elementType == 0)
				{
					NPC.coldDamage = true;
				}
				if (elementType == 2)
				{
					NPC.damage += 20;
				}
				NPC.localAI[0] = 1f;
			}
			if (NPC.AnyNPCs(NPCType<CaptiveElement2>()))
			{
				if (NPC.timeLeft < 750)
				{
					NPC.timeLeft = 750;
				}
			}
			else
			{
				NPC.life = -1;
				NPC.active = false;
				return;
			}
			chargeTimer--;
			if (chargeTimer <= 0)
			{
				NPC.TargetClosest(false);
				Player player = Main.player[NPC.target];
				Vector2 offset = player.Center - NPC.Center;
				if (offset != Vector2.Zero)
				{
					offset.Normalize();
				}
				offset *= 12f;
				chargeX = offset.X;
				chargeY = offset.Y;
				chargeTimer = 150;
				NPC.netUpdate = true;
			}
			else if (chargeTimer <= 30)
			{
				chargeX = 0;
				chargeY = 0;
			}
			NPC.velocity = (99f * NPC.velocity + new Vector2(chargeX, chargeY)) / 100f;
		}


		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{
			if (elementType == 2 && Main.expertMode)
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
			switch (elementType)
			{
				case 0:
					return BuffID.Frostburn;
				case 1:
					return BuffID.Frostburn;
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
			switch (elementType)
			{
				case 0:
					time = 400;
					break;
				case 1:
					time = 400;//300;
					break;
				case 3:
					time = 400;
					break;
				case 4:
					time = 600;
					break;
				default:
					return -1;
			}
			return time;
		}

		public Color? GetColor()
		{
			switch (elementType)
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
	}
}