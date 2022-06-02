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
			Item.width = 28;
			Item.height = 24;
			Item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 28;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.GlowingBody>() && legs.type == ModContent.ItemType<Items.Armor.GlowingLegs>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You are glowing. Full set bonus: +4 defense";
			player.statDefense = (int)(player.statDefense + 4.00);
		}
		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += .12f;
			player.GetAttackSpeed(DamageClass.Melee) += .13f;

		}
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.GlowingBar>(15)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}