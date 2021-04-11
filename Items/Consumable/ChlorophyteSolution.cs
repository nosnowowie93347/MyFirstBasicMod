using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Consumable
{
    public class ChlorophyteSolution : ModItem
    {

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Chlorophyte Solution");
            Tooltip.SetDefault("Used by the Clentaminator, transmutes Mud into Chlorophyte.");
        }

        public override void SetDefaults()
        {
            item.shoot = mod.ProjectileType("ChlorophyteSolution") - ProjectileID.PureSpray;
            item.ammo = ItemID.GreenSolution;
            item.width = 10;
            item.height = 12;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 4;
            item.maxStack = 999;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            /*recipe.AddIngredient(ItemID.DirtBlock);
			recipe.SetResult(this, 999);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);*/
            recipe.AddIngredient(ItemID.ChlorophyteOre, 10);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }

    public class InfiniteChlorophyteSolution : ModItem
    {

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Infinite Chlorophyte Solution");
            Tooltip.SetDefault("Used by the Clentaminator, transmutes Mud into Chlorophyte. Infinite.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ModContent.ItemType<ChlorophyteSolution>());
            item.consumable = false;
            item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChlorophyteSolution>(), 999);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
