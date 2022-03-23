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
			item.defense = 53;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += .29f;
			player.allDamage += .25f;
			player.meleeCrit += 7;
			player.magicDamage += .10f;
			player.rangedCrit += 4;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TrueSolarFlareLeggings>());
			recipe.AddIngredient(ModContent.ItemType<GlowingBar>(), 8);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}