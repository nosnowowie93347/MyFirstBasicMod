using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class HardCrystalBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hard Crystal Breastplate");
            /* Tooltip.SetDefault("8% increased magic and summon damage"
                + "\nIncreases maximum minions"); */
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 50000;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) *= 1.08f;
            player.GetDamage(DamageClass.Summon) *= 1.08f;
            player.maxMinions += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrystalShard, 20)
                .AddIngredient(ItemType<Items.EpicSoul>(), 15)
                .AddTile(Terraria.ID.TileID.Anvils)
                .Register();
        }
    }
}