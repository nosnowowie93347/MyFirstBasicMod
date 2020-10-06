using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Projectiles
{
	public class ElementBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Ball");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.alpha = 255;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void AI()
		{
			if (projectile.localAI[0] == 0f)
			{
				PlaySound();
				if (projectile.ai[0] < 0f)
				{
					projectile.alpha = 0;
				}
				if (projectile.ai[0] == 44f)
				{
					projectile.coldDamage = true;
				}
				if (projectile.ai[0] < 0f && Main.expertMode)
				{
					cooldownSlot = 1;
				}
				projectile.Name = GetName();
				projectile.localAI[0] = 1f;
			}
		}

		public virtual void PlaySound()
		{
			Main.PlaySound(SoundID.Item20, projectile.position);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if ((Main.expertMode || Main.rand.NextBool()) && projectile.ai[0] >= 0f)
			{
				target.AddBuff((int)projectile.ai[0], (int)projectile.ai[1], true);
			}
		}

		public virtual string GetName()
		{
			if (projectile.ai[0] == 24f)
			{
				return "Fireball";
			}
			if (projectile.ai[0] == 44f)
			{
				return "Frost Ball";
			}
			if (projectile.ai[0] == 70f)
			{
				return "Venom Ball";
			}
			if (projectile.ai[0] == 69f)
			{
				return "Ichor Ball";
			}
			return "Death Bubble";
		}

		public Color? GetColor()
		{
			if (projectile.ai[0] == 24f)
			{
				return new Color(250, 10, 0);
			}
			if (projectile.ai[0] == 44f)
			{
				return new Color(0, 230, 230);
			}
			if (projectile.ai[0] == 70f)
			{
				return new Color(0, 178, 0);
			}
			if (projectile.ai[0] == 69f)
			{
				return new Color(230, 192, 0);
			}
			return null;
		}
	}
}