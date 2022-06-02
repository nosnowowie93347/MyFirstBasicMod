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
			Item.width = 24;
			Item.height = 28;
			Item.value = 100000;
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.defense = 100;
			Item.lifeRegen = 19;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {

            player.GetDamage(DamageClass.Generic) += 10f; // increase all damage by 1900%

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(40)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}