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
			item.width = 22;
			item.height = 20;
			item.value = 200000;
			item.rare = ItemRarityID.Pink;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 261;
            player.lifeRegen += 4;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.89f;
			ascentWhenRising = 0.17f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.136f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9f;
			acceleration *= 2.85f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.Placeable.PinksBar>(), 30);
			recipe.AddTile(TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}