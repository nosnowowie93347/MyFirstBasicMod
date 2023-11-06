using MyFirstBasicMod.Projectiles;
using MyFirstBasicMod.Items.Placeable;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
    public class PinkWhip : ModItem
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Pink Whip");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<PinkWhipProjectile>(), 20, 2, 4); 

            Item.shootSpeed = 4;
            Item.rare = ItemRarityID.Green;

            Item.channel = true;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient<PinksBar>(10)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}