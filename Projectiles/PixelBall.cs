using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Projectiles
{
	public class PixelBall : ElementBall
	{
		public override string Texture => mod.Name + "/Projectiles/ElementBall";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixel Ball");
		}

		public override void PlaySound()
		{
			Main.PlaySound(SoundID.Item33, projectile.position);
		}

		public override string GetName()
		{
			if (projectile.ai[0] == 24f)
			{
				return "Fire Sprite";
			}
			if (projectile.ai[0] == 44f)
			{
				return "Frost Sprite";
			}
			if (projectile.ai[0] == 70f)
			{
				return "Infestation Sprite";
			}
			if (projectile.ai[0] == 69f)
			{
				return "Ichor Sprite";
			}
			return "Doom Bubble";
		}
	}
}