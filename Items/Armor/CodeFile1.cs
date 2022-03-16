using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class SteelChest : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Chestplate");
            Tooltip.SetDefault(Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 11));
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(gold: 9);
            item.rare = ItemRarityID.Yellow;
            item.defense = 35;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.11f;
            player.meleeCrit += 6;
        }
        
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.SteelBar>(), 23);  
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}