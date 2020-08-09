using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RubysHelmet : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ruby's Helmet");
			Tooltip.SetDefault("Ruby's very own helmet. \nNot part of a set");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 17;
		}
        public override void UpdateArmorSet(Player player) {
            player.statLifeMax2 += 70;
}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.Placeable.SylvsBlock>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}