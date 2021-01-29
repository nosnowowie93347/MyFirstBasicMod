using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.Overseer
{
	public class SpiritPortal : ModProjectile
	{
		bool start = true;
		// USE THIS DUST: 261

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Portal");
		}

		public override void SetDefaults()
		{
			Projectile.width = Projectile.height = 360;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;

			Projectile.penetrate = -1;

			Projectile.timeLeft = 700;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCKilled, (int)Projectile.position.X, (int)Projectile.position.Y, 6);
			NPC parent = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Overseer>())];
			Player player = Main.player[parent.target];
			Vector2 direction8 = player.Center - Projectile.Center;
			direction8.Normalize();
			direction8.X *= 22f;
			direction8.Y *= 22f;

			int amountOfProjectiles = Main.rand.Next(5, 7);
			for (int i = 0; i < amountOfProjectiles; ++i) {
				float A = (float)Main.rand.Next(-250, 250) * 0.01f;
				float B = (float)Main.rand.Next(-250, 250) * 0.01f;
				Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, direction8.X + A, direction8.Y + B, ModContent.ProjectileType<SpiritShard>(), 80, 1, Main.myPlayer, 0, 0);
			}
		}

		public override bool PreAI()
		{
			if (start) {
				for (int num621 = 0; num621 < 55; num621++) {
					int num622 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, 0f, 0f, 206, default(Color), 2f);
				}
				Projectile.ai[1] = Projectile.ai[0];
				start = false;
			}
			Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, 0f, 0f, 206, default(Color), 2f);
			Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, 0f, 0f, 206, default(Color), 2f);
			Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, 0f, 0f, 206, default(Color), 2f);
			Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, 0f, 0f, 206, default(Color), 2f);
			Projectile.rotation = Projectile.rotation + 3f;
			//Projectile.rotation = Projectile.rotation + 3f;
			//Making player variable "p" set as the Projectile's owner
			float lowestDist = float.MaxValue;
			NPC parent = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Overseer>())];
			Player player = Main.player[parent.target]; // 
			if ((Projectile.ai[1] / 2) % 75 == 1) {
				Vector2 dir = player.Center - Projectile.Center;
				dir.Normalize();
				dir *= 14;
				int spiritdude = NPC.NewNPC((int)Projectile.Center.X, (int)Projectile.Center.Y, ModContent.NPCType<CaptiveSpirit>(), parent.target, 0, 0, 0, -1);
				NPC Spirits = Main.npc[spiritdude];
				Spirits.ai[0] = dir.X;
				Spirits.ai[1] = dir.Y;
			}
			//Factors for calculations
			double deg = (double)Projectile.ai[1]; //The degrees, you can multiply Projectile.ai[1] to make it orbit faster, may be choppy depending on the value
			double rad = deg * (Math.PI / 180); //Convert degrees to radians
			double dist = 500; //Distance away from the player

			/*Position the Projectile based on where the player is, the Sin/Cos of the angle times the /
    		/distance for the desired distance away from the player minus the Projectile's width   /
    		/and height divided by two so the center of the Projectile is at the right place.     */
			Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
			Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;

			//Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
			Projectile.ai[1] += 2f;

			return false;
		}


	}
}