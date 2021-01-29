
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
    public class EnchantedAmethystStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted amethyst staff");
            Tooltip.SetDefault("'Made with shadow magic'");
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 11;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = 30000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ProjectileType<Projectiles.TrueAmethystProjectile>();
            Item.shootSpeed = 1f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            Projectile.NewProjectile((mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockBack, player.whoAmI, 0f, 0f);
            Projectile.NewProjectile((mouse.X - 16) + Main.rand.Next(32), (mouse.Y - 16) + Main.rand.Next(32), Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), ProjectileType<Projectiles.TrueAmethystProjectile>(), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AmethystStaff)
                .AddIngredient(ItemID.Amethyst, 15)
                .AddIngredient(ItemType<Items.EpicSoul>(), 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}