using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
    public class BreadPickaxe : ModItem 
    {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Made of the strongest bread in all the land.");
            DisplayName.SetDefault("Bread Pickaxe");
            
        }
        public override void SetDefaults() {
            item.damage = 111;
            item.autoReuse = true;
            item.pick = 140;
            item.useTime = 8;
            item.useAnimation = 8;
            item.width = 40;
            item.height = 40;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
            item.value = Item.buyPrice(platinum: 12);
            item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.Placeable.PinksBar>(), 14);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
