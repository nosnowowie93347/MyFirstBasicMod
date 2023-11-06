using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RunicHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Runic Hood");
			// Tooltip.SetDefault("Increases magic damage by 12% and movement speed by 5%");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 30;
			Item.value = 70000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<RunicPlate>() && legs.type == ModContent.ItemType<RunicGreaves>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "WORK IN PROGRESS. NOTHING YET";
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.12f;
			player.moveSpeed += 1.05f;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ModContent.ItemType<Rune>(), 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}