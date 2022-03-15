using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{

    public class CobaltShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 42;

            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTime = 19;
            item.useAnimation = 19;
            item.autoReuse = true;

            item.melee = true;
            item.damage = 38;
            item.knockBack = 4.75f;
            item.crit = 8;
            item.value = Item.buyPrice(gold: 2);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;

        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
