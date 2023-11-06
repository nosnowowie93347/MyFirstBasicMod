using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Linq;

namespace MyFirstBasicMod.Items.Armor
{

	[AutoloadEquip(EquipType.Legs)]
	public class RunicGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Runic Greaves");
			// Tooltip.SetDefault("Reduces mana cost by 15% and increases magic damage by 10%");

		}
		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 30;
			Item.value = 60000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.manaCost -= 0.15f;
			player.GetDamage(DamageClass.Magic) += 0.1f;


		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ModContent.ItemType<Rune>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}