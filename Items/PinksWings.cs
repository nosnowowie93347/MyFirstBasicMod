using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MyFirstBasicMod.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class PinksWings : ModItem
	{
		
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pink's Wings");
			Tooltip.SetDefault("These are Pink's wings. Don't use these.\n Pink loves his wings");
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 20;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 211;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9f;
			acceleration *= 2.83f;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(10)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}