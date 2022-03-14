using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class FlashBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flash's Boots");
            Tooltip.SetDefault("These boots belong to the fastest man alive.");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 24;
            item.accessory = true; 
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(gold: 1); 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 9f; 
            player.moveSpeed += 0.25f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostparkBoots, 1);
            recipe.AddTile(TileType<PinksAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}