using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
    public class TrueSapphireStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Sapphire Staff");
            Tooltip.SetDefault("'Deadly storm'");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 40; //The damage
            Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
            Item.width = 54; //Item width
            Item.height = 54; //Item height
            Item.maxStack = 1; //How many of this item you can stack
            Item.useTime = 5; //How **** this **** takes for the item to be used -gamrguy: Really? Just really? -Graydee: It was movildima, not me
            Item.useAnimation = 5; //How long the animation of the item takes
            Item.knockBack = 1f; //How much knockback the item produces
            Item.noMelee = true; //Whether the weapon should do melee damage or not
            Item.useStyle = ItemUseStyleID.Shoot; //How the weapon is held, 5 is the gun hold style
            Item.value = 120000; //How much the item is worth
            Item.rare = ItemRarityID.Yellow; //The rarity of the item
            Item.shoot = ProjectileID.VortexLightning; //What the item shoots, retains an int value | *
            Item.shootSpeed = 7f; //How fast the projectile fires
            Item.mana = 4;
            Item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<Items.EpicSoul>(), 15)
                .AddIngredient(ItemID.SapphireStaff)
                .AddIngredient(ItemType<Items.Placeable.PinksBar>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                Vector2 mouse = Main.MouseWorld;
                Projectile.NewProjectile(mouse.X + Main.rand.Next(-80, 80), player.Center.Y - 350 + Main.rand.Next(-50, 50), 0, 20, ProjectileType<Projectiles.SapphireDroplet>(), damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(mouse.X + Main.rand.Next(-80, 80), player.Center.Y - 350 + Main.rand.Next(-50, 50), 0, 20, ProjectileType<Projectiles.SapphireDroplet>(), damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}