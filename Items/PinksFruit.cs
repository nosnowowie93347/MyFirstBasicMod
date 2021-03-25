using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	
	internal class PinksFruit : ModItem
	{
		public override string Texture => "Terraria/Item_" + ItemID.LifeFruit;

		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pinks Fruit");
			Tooltip.SetDefault("Permanently increases maximum life by 5\nUp to 20 can be used");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.color = Color.LightPink;
		}

		public override bool CanUseItem(Player player) {
			
			return player.statLifeMax == 500 && player.GetModPlayer<PinksPlayer>().pinkLifeFruits < PinksPlayer.maxPinkLifeFruits;
		}

		public override bool UseItem(Player player) {
			// Do not do this: player.statLifeMax += 2;
			player.statLifeMax2 += 5;
            player.statLife += 5;
			if (Main.myPlayer == player.whoAmI) {
				// This spawns the green numbers showing the heal value and informs other clients as well.
				player.HealEffect(5, true);
			}
			// This is very important. This is what makes it permanent.
			player.GetModPlayer<PinksPlayer>().pinkLifeFruits += 1;
			
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Placeable.PinksBar>(), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}