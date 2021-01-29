using MyFirstBasicMod.Tiles;
using MyFirstBasicMod.Items;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
    public class BulletPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded bullet ammo."); // The Item's description, can be set to whatever you want.
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 12; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the Item together.
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 1;
            Item.consumable = false; // This marks the Item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<Projectiles.TerrabotsBullet>(); //The projectile that weapons fire when using this Item as ammunition.
            Item.shootSpeed = 16f; // The speed of the projectile.
            Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Placeable.PinksBar>(5)
                .AddIngredient(ItemID.MusketBall, 100)
                .AddTile<PinksWorkbench>()
                .Register();
        }
    }
}