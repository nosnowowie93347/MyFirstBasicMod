using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Leggings : ModItem
    {
        
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pink's Pants");
            Tooltip.SetDefault("+26% melee damage");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 85000;
            item.rare = ItemRarityID.Lime;
            item.defense = 43;
        }

        
        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.19f; 
            player.meleeDamage += .26f;
            player.meleeCrit += 7;
            player.statLifeMax2 += 10;
            player.rangedCrit += 5;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 32);   //you need 10 Wood
            recipe.AddTile(TileID.MythrilAnvil);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}