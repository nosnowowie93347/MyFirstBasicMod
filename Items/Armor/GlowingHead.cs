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
			// DisplayName.SetDefault("Glowing Faceplate");
			// Tooltip.SetDefault("Increases ranged damage by 12% and ranged crit chance by 13%");
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 41;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.GlowingBody>() && legs.type == ModContent.ItemType<Items.Armor.GlowingLegs>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You are glowing. Full set bonus: +4 defense, and +30% ranged damage.";
			player.statDefense = (player.statDefense + 4);
			player.GetDamage(DamageClass.Ranged) += .30f;
		}
		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Ranged) += .12f;
			player.GetCritChance(DamageClass.Ranged) += 13;

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