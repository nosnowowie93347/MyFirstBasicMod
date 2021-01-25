using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Projectiles
{
	public class PixelBall : ElementBall
	{
		public override string Texture => Mod.Name + "/Projectiles/ElementBall";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixel Ball");
		}

		public override void PlaySound()
		{
			SoundEngine.PlaySound(SoundID.Item33, Projectile.position);
		}

		public override string GetName()
		{
			if (Projectile.ai[0] == 24f)
			{
				return "Fire Sprite";
			}
			if (Projectile.ai[0] == 44f)
			{
				return "Frost Sprite";
			}
			if (Projectile.ai[0] == 70f)
			{
				return "Infestation Sprite";
			}
			if (Projectile.ai[0] == 69f)
			{
				return "Ichor Sprite";
			}
			return "Doom Bubble";
		}
	}
}