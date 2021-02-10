using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class GodLeggings : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Pants");
            Tooltip.SetDefault("+35% move speed");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 65000;
            item.rare = ItemRarityID.LightPurple;
            item.defense = 35;
        }


        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += .35f;
            player.allDamage += .15f;
            player.meleeCrit += 7;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Armor.Leggings>(), 1);   //you need 10 Wood
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}