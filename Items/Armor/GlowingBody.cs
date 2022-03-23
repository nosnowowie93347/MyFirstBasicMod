using MyFirstBasicMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GlowingBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Plate");
			Tooltip.SetDefault("Increases melee critical strike chance by 10% and melee damage by 12%");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.defense = 85;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += .15f;
			player.statLifeMax2 += 90;
			player.meleeDamage += .16f;
			player.magicDamage += .12f;
			player.rangedDamage += .55f;
			player.meleeCrit += 6;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TrueSolarFlareChestplate>());
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.GlowingBar>(), 20);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}