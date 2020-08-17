using MyFirstBasicMod.Mounts;
using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class CarKey : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This is a modded mount.");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 30000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = MountType<Car>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.Placeable.PinksBar>(), 10);
			recipe.AddTile(TileType<PinksWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}