using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MyFirstBasicMod.Tiles;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SteelPants : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Pants");
            Tooltip.SetDefault("+7% increased movement and melee speed");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 85000;
            item.rare = ItemRarityID.Lime;
            item.defense = 21;
        }


        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.07f;
            player.moveSpeed += 0.07f;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.SteelBar>(), 22);   //you need 10 Wood
            recipe.AddTile(ModContent.TileType<PinksAnvil>());   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}