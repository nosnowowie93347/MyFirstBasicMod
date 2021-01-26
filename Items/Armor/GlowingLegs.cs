using MyFirstBasicMod.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlowingLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Greaves");
			Tooltip.SetDefault("Increases movement speed by 7% and melee speed by 5%");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.defense = 14;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += .07f;
			player.meleeSpeed += .05f;

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GlowingBar>(), 8);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}