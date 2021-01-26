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
            Tooltip.SetDefault("Pink's Helmet\n Immune to most debuffs");
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
            return body.type == ModContent.ItemType<Items.Armor.BreastplateName>() && legs.type == ModContent.ItemType<Items.Armor.Leggings>();
        }
        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.meleeDamage += 0.11f; //+15 % damage
            player.statLifeMax2 += 10;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You are awesome!. Full set bonus: +6 defense";
            player.statDefense = (int)(player.statDefense + 6.00);
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 25);   //you need 10 Wood
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}