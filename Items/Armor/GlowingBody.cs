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
			Tooltip.SetDefault("Increases melee damage by 12%");
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 30;
		}
		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += .12f;

		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.GlowingBar>(20)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}