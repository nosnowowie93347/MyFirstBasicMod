using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace MyFirstBasicMod
{
	public static class ItemUtils
	{
		public static void DropItem(this Entity ent, int type, int stack = 1)
		{
			Item.NewItem(ent.Hitbox, type, stack);
		}

		public static void DropItem(this Entity ent, int type, float chance)
		{
			if (Main.rand.NextDouble() < chance) {
				Item.NewItem(ent.Hitbox, type);
			}
		}

		public static void DropItem(this Entity ent, int type, int min, int max)
		{
			Item.NewItem(ent.Hitbox, type, Main.rand.Next(min, max));
		}
		}
		}