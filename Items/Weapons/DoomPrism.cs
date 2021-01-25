using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
    public class DoomPrism : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is an example magic weapon");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your Item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
            Item.width = 34;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
            Item.noMelee = true; // Makes the Item not do damage with it's melee hitbox.
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.BlackBolt; // Shoot a black bolt, also known as the projectile shot from the onyx blaster.
            Item.shootSpeed = 7; // How fast the Item shoots the projectile.
            Item.crit = 32; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
            Item.mana = 11; // This is how much mana the Item uses.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(9)
                .AddIngredient<Items.EpicSoul>(9)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}