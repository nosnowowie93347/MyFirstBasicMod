using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class Test : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Pink's Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Waaaaaay too overpowered.\nIt's OPNess is over 9000!!");
		}

		public override void SetDefaults() 
		{
			item.damage = 300;
			item.melee = true;
			item.width = 30;
			item.height = 60;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 99999;
			item.rare = 3;
			item.UseSound = SoundID.Item16;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 14);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}