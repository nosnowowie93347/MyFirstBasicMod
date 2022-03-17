using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class TrueSolarFlareChestplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TRUE Solar Flare Chestplate");
            Tooltip.SetDefault(Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 22));
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 65000;
            item.rare = ItemRarityID.Yellow;
            item.defense = 75;
        }


        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += .15f;
            player.statLifeMax2 += 90;
            player.meleeDamage += .16f;
            player.magicDamage += .12f;
            player.rangedDamage += .55f;
            player.meleeCrit += 6;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Armor.GodChestplate>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());   //at mythril anvil
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}