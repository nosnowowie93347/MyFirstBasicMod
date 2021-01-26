using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Leggings : ModItem
    {
        
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pink's Pants");
            Tooltip.SetDefault("Pink's Pants");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 65000;
            item.rare = 2;
            item.defense = 42;
        }

        
        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.09f; //Ranged damage +45%
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 31);   //you need 10 Wood
            recipe.AddTile(TileID.MythrilAnvil);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}