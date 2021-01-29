using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.Overseer
{
	public class HauntedWisp : ModProjectile
	{
		int target;
		// USE THIS DUST: 261

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Haunted Wisp");
		}

		public override void SetDefaults()
		{
			Projectile.width = Projectile.height = 12;

			Projectile.hostile = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;

			Projectile.penetrate = -1;

			Projectile.timeLeft = 300;
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
			else {
				Player targetPlayer = Main.player[this.target];
				if (!targetPlayer.active || targetPlayer.dead) {
					this.target = -1;
					Projectile.ai[0] = 0;
					Projectile.netUpdate = true;
				}
				else {
					float currentRot = Projectile.velocity.ToRotation();
					Vector2 direction = targetPlayer.Center - Projectile.Center;
					float targetAngle = direction.ToRotation();
					if (direction == Vector2.Zero) {
						targetAngle = currentRot;
					}

					float desiredRot = currentRot.AngleLerp(targetAngle, 0.1f);
					Projectile.velocity = new Vector2(Projectile.velocity.Length(), 0f).RotatedBy(desiredRot, default(Vector2));
				}
			}

			if (Projectile.timeLeft <= 60) {
				Projectile.alpha -= 4;
			}

			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 4; i < 31; i++) {
				float x = Projectile.oldVelocity.X * (30f / i);
				float y = Projectile.oldVelocity.Y * (30f / i);
				int newDust = Dust.NewDust(new Vector2(Projectile.oldPosition.X - x, Projectile.oldPosition.Y - y), 8, 8, 261, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.8f);
				Main.dust[newDust].noGravity = true;
				Main.dust[newDust].velocity *= 0.5f;
				newDust = Dust.NewDust(new Vector2(Projectile.oldPosition.X - x, Projectile.oldPosition.Y - y), 8, 8, 261, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default(Color), 1.4f);
				Main.dust[newDust].velocity *= 0.05f;
				Main.dust[newDust].noGravity = true;
			}
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