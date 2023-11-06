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
			// DisplayName.SetDefault("Glowing Plate");
			// Tooltip.SetDefault("Increases ranged damage by 25%, 20% chance not to consume ammo\n10% Increased ranged crit chance.");
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 59;
		}
		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Ranged) += .25f;
            player.ammoCost80 = true;
            player.GetCritChance(DamageClass.Ranged) += 10;
            // MyPlayer modplayer = player.GetModPlayer<PinksPlayer>();
			// modplayer.WingTimeMaxMultiplier += 0.2f;

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