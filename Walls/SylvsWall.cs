using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Walls
{
	public class SylvsWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = true;
			drop = ItemType<Items.Placeable.SylvsWall>();
			AddMapEntry(new Color(150, 150, 150));
		}


		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.4f;
			g = 0.4f;
			b = 0.4f;
		}
	}
}