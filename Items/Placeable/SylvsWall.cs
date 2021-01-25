using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace MyFirstBasicMod.Items.Placeable
{
    public class SylvsWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sylv's Wall");
            Tooltip.SetDefault("This is a modded wall for Sylv.");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = WallType<Walls.SylvsWall>();
        }

    }
}