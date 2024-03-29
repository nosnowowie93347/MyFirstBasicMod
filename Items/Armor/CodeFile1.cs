﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HardCrystalHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hard Crystal Helm");
            /* Tooltip.SetDefault("16% increased magic and summon damage"
                + "\nIncreases maximum minions by 1"); */
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 40000;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.16f;
            player.GetDamage(DamageClass.Summon) += 0.16f;
            player.maxMinions += 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<HardCrystalBreastplate>() && legs.type == ItemType<HardCrystalLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+15% magic and summon damage";
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetDamage(DamageClass.Summon) += 0.15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrystalShard, 15)
                .AddIngredient(ItemType<Items.EpicSoul>(), 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}