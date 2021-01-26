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
			item.damage = 200;
			item.melee = true;
			item.width = 30;
			item.height = 60;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7;
			item.value = 99999;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 35);
            recipe.AddIngredient(ItemID.Excalibur, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}