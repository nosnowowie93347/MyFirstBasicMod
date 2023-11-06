using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BloodCourtChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodcourt's Vestments");
			// Tooltip.SetDefault("6% increased damage\n+5 magic regen\n20% chance to not consume ammo\n+100 max life, -5% mana cost");

		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = 123000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 51;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) += 0.06f;
			player.manaRegen += 5;
			player.ammoCost80 = true;
			player.manaCost -= 0.05f;
			player.statLifeMax2 += 100;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ModContent.ItemType<Items.DreamstrideEssence>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}