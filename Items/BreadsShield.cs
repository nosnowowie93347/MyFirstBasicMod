using MyFirstBasicMod.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace MyFirstBasicMod.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class BreadsShield : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(""
				+ "\n" + Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 1000));
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 100000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.defense = 100;
			item.lifeRegen = 19;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			
				player.allDamage += 10f; // increase all damage by 1900%
			
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 40);
			recipe.AddTile(ModContent.TileType<Tiles.PinksWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}