using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
    public class CrystalGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Grenade");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.damage = 35;
            item.useTime = 40;
            item.value = 1000;
            item.useAnimation = 40;
            item.rare = ItemRarityID.Orange;
            item.shoot = ProjectileType<Projectiles.CrystalGrenadeProj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 5);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}