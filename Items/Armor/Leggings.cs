using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Leggings : ModItem
    {
        
        public override void SetStaticDefaults() {
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 65000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 42;
        }


        public override void UpdateEquip(Player player)
        {
            player.setBonus = "Being Awesome!";
            player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.statLifeMax2 += 30;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(31)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}