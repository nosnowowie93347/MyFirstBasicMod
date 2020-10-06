<<<<<<< HEAD
﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class SwordOfDreams : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword of Dreams"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This sword belongs to a user going by the name Dream.\nIt's OPNess is over 9000!!");
		}

		public override void SetDefaults()
		{
			item.damage = 150;
			item.melee = true;
			item.width = 30;
			item.height = 60;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7;
			item.value = 99999;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item16;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
=======
﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class SwordOfDreams : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword of Dreams"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This sword belongs to a user going by the name Dream.\nIt's OPNess is over 9000!!");
		}

		public override void SetDefaults()
		{
			item.damage = 150;
			item.melee = true;
			item.width = 30;
			item.height = 60;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7;
			item.value = 99999;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item16;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
>>>>>>> cc441405b0cde9937a83bfd44804b397531f5ddc
}