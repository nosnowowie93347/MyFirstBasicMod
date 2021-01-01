using MyFirstBasicMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
    public class EpicLaserOfDoom : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoot a laser beam that can eliminate anything...");
        }

        public override void SetDefaults()
        {
            item.damage = 140;
            item.noMelee = true;
            item.magic = true;
            item.channel = true; //Channel so that you can hold the weapon [Important]
            item.mana = 5;
            item.rare = ItemRarityID.Pink;
            item.width = 28;
            item.height = 30;
            item.useTime = 20;
            item.UseSound = SoundID.Item13;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 14f;
            item.useAnimation = 20;
            item.shoot = ProjectileType<Projectiles.EpicLaserOfDoom>();
            item.value = Item.sellPrice(silver: 3);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Placeable.PinksBar>(), 20);
            recipe.AddTile(TileType<Tiles.PinksAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}