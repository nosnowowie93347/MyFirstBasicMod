using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BloodCourtLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodcourt's Leggings");
			// Tooltip.SetDefault("Increases movement speed by 10%\nIncreases maximum mana by 30, 15% increased magic damage");

		}
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 104000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 44;
		}
		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 30;
			player.GetDamage(DamageClass.Magic) += 0.15f;
			player.moveSpeed += .1f;
			player.maxRunSpeed += .06f;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ModContent.ItemType<Items.DreamstrideEssence>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}