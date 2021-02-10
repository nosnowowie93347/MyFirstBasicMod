using MyFirstBasicMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GlowingHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Faceplate");
			Tooltip.SetDefault("Increases melee damage by 12% and melee speed by 13%");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.defense = 21;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.GlowingBody>() && legs.type == ModContent.ItemType<Items.Armor.GlowingLegs>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You are glowing. Full set bonus: +5 defense";
			player.statDefense = (int)(player.statDefense + 5.00);
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += .12f;
			player.meleeSpeed += .13f;

		}
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.GlowingBar>(), 15);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}