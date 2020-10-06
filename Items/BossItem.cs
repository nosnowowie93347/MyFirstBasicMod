using MyFirstBasicMod.Items.Placeable;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class BossItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Used to craft boss items");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<PinksBar>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}