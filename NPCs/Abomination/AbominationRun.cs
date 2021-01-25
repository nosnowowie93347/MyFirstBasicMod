using Terraria;
using Terraria.ID;
using System;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.Abomination
{
	//ported from my tAPI mod because I'm lazy
	[AutoloadBossHead]
	public class AbominationRun : ModNPC
	{
		public override string Texture => "MyFirstBasicMod/NPCs/Abomination/Abomination";

		public override string HeadTexture => "MyFirstBasicMod/NPCs/Abomination/Abomination_Head_Boss";

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
			NPC.dontTakeDamage = true;
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
			// Custom Music: music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/DriveMusic");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
			NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public override void AI()
		{
			if (NPC.localAI[0] == 0f)
			{
				SoundEngine.PlaySound(SoundID.Roar, NPC.position, 0);
				NPC.localAI[0] = 1f;
			}
			NPC.velocity.Y += 1f;
			if (NPC.timeLeft > 10)
			{
				NPC.timeLeft = 10;
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode || Main.rand.NextBool())
			{
				player.AddBuff(BuffID.OnFire, 600, true);
			}
		}
	}
}