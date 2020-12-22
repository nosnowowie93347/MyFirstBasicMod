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

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("Pink's Helmet") && legs.type == mod.ItemType("Pink's Pants");  //put your Breastplate name and Leggings name
        }
        public override void UpdateEquip(Player player)
        {
            player.setBonus = "Being Awesome!";
            player.meleeDamage += 0.15f; //+15 % damage
            player.rangedDamage += 0.15f; //Ranged damage +45%
            player.statDefense = (int)(player.statDefense * 0.65);  // 65% defense
            player.statLifeMax2 += 30;
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