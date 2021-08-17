using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class TerrabotsPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This pickaxe was created by Terrabot, Pink's Discord bot.");
			DisplayName.SetDefault("Terrabot's Pickaxe");
		}

		public override void SetDefaults() {
			item.damage = 100;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
            item.crit = 1;
			item.useAnimation = 17;
			item.pick = 220;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7.5f;
			item.value = 89999;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.Placeable.PinksBar>(), 21);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}