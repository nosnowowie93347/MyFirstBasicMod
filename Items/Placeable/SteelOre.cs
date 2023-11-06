using Terraria.ID;
using Terraria;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Placeable
{
    public class SteelOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steel Ore");
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = TileType<Tiles.SteelOre>();
            Item.width = 12;
            Item.height = 12;
            Item.value = 3000;
        }
    }
}