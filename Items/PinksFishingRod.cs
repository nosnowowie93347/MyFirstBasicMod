using MyFirstBasicMod.Projectiles;
using MyFirstBasicMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class PinksFishingRod : ModItem
	{
		
		public override string Texture => "Terraria/Item_" + ItemID.WoodFishingPole;
		public static Color OverrideColor = Color.Coral;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink's Fishing Rod");
			Tooltip.SetDefault("Fires multiple lines at once. Can fish in lava.\n" +
				"The fishing line never snaps.");
			
			ItemID.Sets.CanFishInLava[item.type] = true;
		}

		public override void SetDefaults()
		{
			
			item.CloneDefaults(ItemID.WoodFishingPole);

			//Sets the poles fishing power
			item.fishingPole = 60;

			//Sets the speed in which the bobbers are launched, Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f
			item.shootSpeed = 12f;

			//The Bobber projectile
			item.shoot = ProjectileType<PinksBobber>();

			// Change the item's draw color so that it is visually distinct from the vanilla Wooden Fishing Rod.
			item.color = OverrideColor;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodFishingPole, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

		
		public override void HoldItem(Player player)
		{
			player.accFishingLine = true;
		}

		
		

		
	}
}