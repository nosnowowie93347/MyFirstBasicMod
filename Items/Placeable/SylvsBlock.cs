using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Placeable
{
    public class SylvsBlock: ModItem
    {
    	public override void SetStaticDefaults() {
    		Tooltip.SetDefault("This is Sylv's Block!");
    		DisplayName.SetDefault("Sylv's Block");
    	}
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.createTile = TileType<Tiles.SylvsBlock>();
            item.useTurn = true;
            item.autoReuse = true;
            item.value = Terraria.Item.sellPrice(0, 0, 50, 0);
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 10);   //you need 10 Wood
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
