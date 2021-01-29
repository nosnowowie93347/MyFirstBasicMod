using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.Overseer
{
	public class CaptiveSpirit : ModNPC
	{
		bool start = true;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Captive Spirit");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 34;
			NPC.height = 70;

			NPC.damage = 120;
			NPC.defense = 74;
			NPC.lifeMax = 900;
			NPC.knockBackResist = 0;

			NPC.noGravity = true;
			NPC.noTileCollide = true;

			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath5;
		}

		public override bool PreAI()
		{
			NPC.rotation = NPC.velocity.ToRotation() + 1.57f;
			if (start) {
				for (int num621 = 0; num621 < 15; num621++) {
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 206, 0f, 0f, 100, default(Color), 2f);
				}
				NPC.velocity.X = NPC.ai[0];
				NPC.velocity.Y = NPC.ai[1];
				start = false;
			}

			if (Main.rand.Next(3) == 0)
				Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 206, 0f, 0f, 100, default(Color), 2f);

			NPC.TargetClosest(true);
			Player targetPlayer = Main.player[NPC.target];
			float currentRot = NPC.velocity.ToRotation();
			Vector2 direction = targetPlayer.Center - NPC.Center;
			float targetAngle = direction.ToRotation();
			if (direction == Vector2.Zero)
				targetAngle = currentRot;

			float desiredRot = currentRot.AngleLerp(targetAngle, 0.1f);
			NPC.velocity = new Vector2(NPC.velocity.Length(), 0f).RotatedBy(desiredRot, default(Vector2));
			return false;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			if (NPC.frameCounter >= 5) {
				NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
				NPC.frameCounter = 0;
			}
		}
	}
}
