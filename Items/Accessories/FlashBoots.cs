using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MyFirstBasicMod.Items.Placeable;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class FlashBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Flash's Boots");
            // Tooltip.SetDefault("These boots belong to the fastest man alive.");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 24;
            Item.accessory = true; 
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(gold: 1); 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 9f; 
            player.moveSpeed += 0.25f;
        }
        public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.FrostsparkBoots)
				.AddIngredient<PinksBar>()
				.AddTile<Tiles.PinksAnvil>()
				.Register();
		}
    }
}