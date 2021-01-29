using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.IO;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.Overseer
{
	public class SpiritShard : ModProjectile
	{
		int target;
		// USE THIS DUST: 261

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Shard");
		}

		public override void SetDefaults()
		{
			Projectile.width = Projectile.height = 12;

			Projectile.hostile = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;

			Projectile.penetrate = 1;

			Projectile.timeLeft = 175;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 14);
			int proj = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, (int)(Projectile.damage), 0, Main.myPlayer);
		}

		public override bool PreAI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57F;

			if (Projectile.ai[0] == 0 && Main.netMode != NetmodeID.MultiplayerClient) {
				target = -1;
				float distance = 2000f;
				for (int k = 0; k < 255; k++) {
					if (Main.player[k].active && !Main.player[k].dead) {
						Vector2 center = Main.player[k].Center;
						float currentDistance = Vector2.Distance(center, Projectile.Center);
						if (currentDistance < distance || target == -1) {
							distance = currentDistance;
							target = k;
						}
					}
				}
				if (target != -1) {
					Projectile.ai[0] = 1;
					Projectile.netUpdate = true;
				}
			}
			Player targetPlayer = Main.player[this.target];
			Vector2 direction = targetPlayer.Center - Projectile.Center;
			direction.Normalize();
			Projectile.velocity *= 0.98f;
			int dust2 = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 206, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			Main.dust[dust2].noGravity = true;
			if (Math.Sqrt((Projectile.velocity.X * Projectile.velocity.X) + (Projectile.velocity.Y * Projectile.velocity.Y)) >= 7f) {
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 206, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 2f;
				dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 206, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 2f;
			}
			if (Math.Sqrt((Projectile.velocity.X * Projectile.velocity.X) + (Projectile.velocity.Y * Projectile.velocity.Y)) < 14f) {
				if (Main.rand.Next(24) == 1) {
					direction.X = direction.X * Main.rand.Next(20, 24);
					direction.Y = direction.Y * Main.rand.Next(20, 24);
					Projectile.velocity.X = direction.X;
					Projectile.velocity.Y = direction.Y;
				}
			}
			return false;
		}

		public override void SendExtraAI(System.IO.BinaryWriter writer)
		{
			writer.Write(this.target);
		}

		public override void ReceiveExtraAI(System.IO.BinaryReader reader)
		{
			this.target = reader.Read();
		}
	}
}