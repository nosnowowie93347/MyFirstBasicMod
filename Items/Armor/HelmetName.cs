using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HelmetName : ModItem
    {
        public static readonly int MoveSpeedBonus = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MoveSpeedBonus);

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Pink's Helmet");
            // Tooltip.SetDefault("Pink's Helmet\n Immune to most debuffs");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 65000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 24;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BreastplateName>() && legs.type == ModContent.ItemType<Leggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.setBonus = "Being Awesome!";
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
            player.GetDamage(DamageClass.Melee) += 0.25f; //+15 % damage
            player.GetDamage(DamageClass.Ranged) += 0.19f;
            player.statLifeMax2 += 30;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You are awesome!. Full set bonus: +5% move speed";
            player.moveSpeed += MoveSpeedBonus / 100f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(25)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}