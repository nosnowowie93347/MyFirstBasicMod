using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.NPCs.Overseer
{
	public class CoreShard : ModProjectile
	{
		int target;
		// USE THIS DUST: 261

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core Shard");
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
			SoundEngine.PlaySound(SoundID.NPCKilled, (int)Projectile.position.X, (int)Projectile.position.Y, 6);
		}

		public override bool PreAI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57F;
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