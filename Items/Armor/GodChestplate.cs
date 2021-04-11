using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class GodChestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Chestplate");
            Tooltip.SetDefault(Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 22));
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 65000;
            item.rare = ItemRarityID.Yellow;
            item.defense = 49;
        }


        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += .15f;
            player.statLifeMax2 += 60;
            player.meleeDamage += .16f;
            player.magicDamage += .12f;
            player.meleeCrit += 6;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Armor.BreastplateName>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());   //at mythril anvil
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}