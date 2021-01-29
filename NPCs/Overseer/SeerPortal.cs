using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.Overseer
{
	public class SeerPortal : ModProjectile
	{
		// USE THIS DUST: 261
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Portal");
		}

		public override void SetDefaults()
		{
			Projectile.width = Projectile.height = 360;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;

			Projectile.penetrate = -1;

			Projectile.timeLeft = 120;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, 0f, 0f, 206, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}

		public override void Kill(int timeLeft)
		{
			// Projectile.rotation += 0.2f;
			SoundEngine.PlaySound(SoundID.NPCKilled, (int)Projectile.position.X, (int)Projectile.position.Y, 6);
			NPC parent = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Overseer>())];
			for (int J = 0; J < 20; J++) {
				Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 206, 0f, 0f, 206, default(Color), 2f);
				Dust.NewDust(new Vector2(parent.position.X, parent.position.Y), parent.width, parent.height, 206, 0f, 0f, 206, default(Color), 2f);

			}
			parent.position = Projectile.position;
		}

	}
}