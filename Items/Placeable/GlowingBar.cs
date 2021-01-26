using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
	public class GlowingBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Bar");
		}


		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.value = 10000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.rare = ItemRarityID.Yellow;
			item.consumable = true;
			item.maxStack = 99;
			item.createTile = ModContent.TileType<Tiles.GlowingBar>();
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.GlowingOre>(), 4);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}