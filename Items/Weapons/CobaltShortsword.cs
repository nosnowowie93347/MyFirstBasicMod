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
            item.useTime = 14;
            item.useAnimation = 14;
            item.autoReuse = true;

            item.melee = true;
            item.damage = 40;
            item.knockBack = 5.75f;
            item.crit = 11;
            item.value = Item.buyPrice(platinum: 7);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;

        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
