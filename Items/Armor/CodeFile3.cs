using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class HardCrystalLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hard Crystal Leggings");
            Tooltip.SetDefault("Increases maximum minions by 2");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 30000;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrystalShard, 15)
                .AddIngredient(ItemType<Items.EpicSoul>(), 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}