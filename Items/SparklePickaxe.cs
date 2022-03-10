using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
    public class SparklePickaxe : ModItem 
    {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Covered in sparkles.");
            DisplayName.SetDefault("Sparkle Pickaxe");
            
        }
        public override void SetDefaults() {
            item.damage = 21;
            item.autoReuse = true;
            item.pick = 95;
            item.useTime = 16;
            item.useAnimation = 16;
            item.width = 40;
            item.height = 40;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2.75f;
            item.value = Item.buyPrice(platinum: 12);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 10);
            recipe.AddIngredient(ItemID.Sapphire, 10);
            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}