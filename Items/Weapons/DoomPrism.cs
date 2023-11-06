using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Enums;
using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
    public class DoomPrism : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Bring doom upon your enemies!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() {
            // DefaultToStaff handles setting various Item values that magic staff weapons use.
            // Hover over DefaultToStaff in Visual Studio to read the documentation!
            // Shoot a black bolt, also known as the projectile shot from the onyx blaster.
            Item.DefaultToStaff(ProjectileID.BlackBolt, 7, 20, 11);
            Item.width = 34;
            Item.height = 40;
            Item.UseSound = SoundID.Item71;

            // A special method that sets the damage, knockback, and bonus critical strike chance.
            // This weapon has a crit of 32% which is added to the players default crit chance of 4%
            Item.SetWeaponValues(45, 6, 32);

            Item.SetShopValues(ItemRarityColor.LightRed4, 10000);
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
        public override void ModifyManaCost(Player player, ref float reduce, ref float mult) {
            // We can use ModifyManaCost to dynamically adjust the mana cost of this item, similar to how Space Gun works with the Meteor armor set.
            // See ExampleHood to see how accessories give the reduce mana cost effect.
            if (player.statLife < player.statLifeMax2 / 2) {
                mult *= 0.5f; // Half the mana cost when at low health. Make sure to use multiplication with the mult parameter.
            }
        }
    }
}