using MyFirstBasicMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class IrohsHamaxe : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Iroh's Hamaxe");
			Tooltip.SetDefault("Made by IrohPlayz999YT, a friend of Pink");
		}

		public override void SetDefaults() {
			item.damage = 65;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 4;
			item.useAnimation = 4;
			item.axe = 190;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			item.hammer = 165;      //How much hammer power the weapon has
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 999999;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

