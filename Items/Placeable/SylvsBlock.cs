using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Placeable
{
    public class SylvsBlock: ModItem
    {
    	public override void SetStaticDefaults() {
    		// Tooltip.SetDefault("This is Sylv's Block!");
    		// DisplayName.SetDefault("Sylv's Block");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.createTile = TileType<Tiles.SylvsBlock>();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
        }

    }
}
