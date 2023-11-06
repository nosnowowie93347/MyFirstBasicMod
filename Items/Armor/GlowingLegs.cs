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
			// DisplayName.SetDefault("Glowing Greaves");
			// Tooltip.SetDefault("Increases movement speed by 7% and 20% chance not to consume ammo\n+20% ranged damage and crit chance");
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 51;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += .07f;
			player.GetDamage(DamageClass.Ranged) += .20f;
			player.GetCritChance(DamageClass.Ranged) += 20;
			player.maxRunSpeed += .03f;
			player.ammoCost80 = true;

		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.GlowingBar>(9)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}