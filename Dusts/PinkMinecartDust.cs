using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MyFirstBasicMod.Dusts
{
	public class PinkMinecartDust : ModDust
	{
		public override void SetDefaults()
		{
			updateType = 213;
		}

		public override Color? GetAlpha(Dust dust, Color lightColor)
		{
			int fade = (int)(dust.scale / 2.5f * 255f);
			return new Color(fade, fade, fade, fade);
		}
	}
}