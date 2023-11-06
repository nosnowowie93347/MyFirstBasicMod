using MyFirstBasicMod.Mounts;
using MyFirstBasicMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class MinecartKeys : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Minecart Keys");
			// Tooltip.SetDefault("The keys to the pink minecart added by this mod.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = 30000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item79;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<PinkMinecart>();
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Minecart)
				.AddIngredient(ModContent.ItemType<Placeable.PinksBar>(), 15)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}