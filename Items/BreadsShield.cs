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
				+ "\n" + Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 20));
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = ItemRarityID.Pink;
			item.accessory = true;
			item.defense = 8;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            
            player.allDamage += .20f; // increase all damage by 1900%
            player.meleeCrit += 5;
            player.lifeRegen += 6;
            player.armorPenetration += 3;
			
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 33);
			recipe.AddTile(ModContent.TileType<PinksWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}