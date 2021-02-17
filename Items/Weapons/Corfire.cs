using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
	public class Corfire : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.CorruptYoyo);

			item.damage = 86;
			item.width = 30;
			item.height = 26;
			item.shoot = mod.ProjectileType("CorfirePro");
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corfire");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HelFire, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.CursedFlame, 18);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}