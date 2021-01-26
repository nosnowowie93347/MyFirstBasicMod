using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BreastplateName : ModItem
    {
        
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pink's Chestplate");
            Tooltip.SetDefault("Pink's Chestplate");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 65000;
            item.rare = ItemRarityID.Green;
            item.defense = 30;
        }

        
        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 10;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 37);   
            recipe.AddTile(TileID.MythrilAnvil);   //at mythril anvil
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}