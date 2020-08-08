using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HelmetName : ModItem
    {
        
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pink's Helmet");
            Tooltip.SetDefault("Pink's Helmet");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 65000;
            item.rare = 2;
            item.defense = 23;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("Pink's Chestplate") && legs.type == mod.ItemType("Pink's Pants");  //put your Breastplate name and Leggings name
        }
        public override void UpdateEquip(Player player)
        {
            player.setBonus = "Being Awesome!";
            player.meleeDamage += 0.15f; //+15 % damage
            player.rangedDamage += 0.15f; //Ranged damage +45%
            player.statDefense = (int)(player.statDefense * 1.22);  // 65% defense
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 20);   //you need 10 Wood
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}