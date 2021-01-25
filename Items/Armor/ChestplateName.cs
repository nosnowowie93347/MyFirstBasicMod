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
            Item.width = 18;
            Item.height = 18;
            Item.value = 65000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 30;
        }

        
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.15f; //+15 % damage
            player.GetDamage(DamageClass.Ranged) += 0.15f; //Ranged damage +45%
            player.statDefense = (int)(player.statDefense * 1.00);  // 65% defense
            player.statLifeMax2 += 30;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(37)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}