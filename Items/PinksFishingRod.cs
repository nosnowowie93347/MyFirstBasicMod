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
		// You can use vanilla textures by using the format: Terraria/Item_<ID>
		public override string Texture => "Terraria/Item_" + ItemID.WoodFishingPole;
		public static Color OverrideColor = Color.Coral;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink's Fishing Rod");
			Tooltip.SetDefault("Fires multiple lines at once. Can fish in lava.\n" +
				"The fishing line never snaps.");
			//Allows the pole to fish in lava
			ItemID.Sets.CanFishInLava[item.type] = true;
		}

		public override void SetDefaults()
		{
			//These are copied through the CloneDefaults method
			//item.useStyle = 1;
			//item.useAnimation = 8;
			//item.useTime = 8;
			//item.width = 24;
			//item.height = 28;
			//item.UseSound = SoundID.Item1;
			item.CloneDefaults(ItemID.WoodFishingPole);

			//Sets the poles fishing power
			item.fishingPole = 30;

			//Sets the speed in which the bobbers are launched, Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f
			item.shootSpeed = 12f;

			//The Bobber projectile
			item.shoot = ProjectileType<PinksBobber>();

			// Change the item's draw color so that it is visually distinct from the vanilla Wooden Fishing Rod.
			item.color = OverrideColor;
		}

		//Grants the High Test Fishing Line bool if holding the item
		//NOTE: Only triggers through the hotbar, not if you hold the item by hand outside of the inventory
		public override void HoldItem(Player player)
		{
			player.accFishingLine = true;
		}

		//Overrides the default shooting method to fire multiple bobbers
		//NOTE: This will allow the fishing rod to summon multiple Duke Fishrons with multiple Truffle Worms in the inventory
		

		
	}
}