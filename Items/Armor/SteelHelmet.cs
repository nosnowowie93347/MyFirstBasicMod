using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class SteelHelmet : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Helmet");
            Tooltip.SetDefault(Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 10));
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(gold: 9);
            item.rare = ItemRarityID.Yellow;
            item.defense = 25;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SteelChest>() && legs.type == ModContent.ItemType<Items.Armor.SteelPants>();
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.1f;
            Mod calamity = ModLoader.GetMod("CalamityMod");
            if (calamity != null)
            {
                player.buffImmune[calamity.BuffType("Nightwither")] = true;
            }
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You are amazing!";
            player.meleeCrit += 7;
            player.meleeDamage += 0.20f;
            player.meleeSpeed += 0.12f;
            player.moveSpeed += 0.12f;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.SteelBar>(), 17);   //you need 10 Wood
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}