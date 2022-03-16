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
			DisplayName.SetDefault("Minecart Keys");
			Tooltip.SetDefault("The keys to the pink minecart added by this mod.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = ModContent.MountType<PinkMinecart>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Placeable.PinksBar>(), 10);
			recipe.AddTile(ModContent.TileType<PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}