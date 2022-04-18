
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
    public class OrichalcumStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Staff");
            Tooltip.SetDefault("'Made with Orichalcum'");
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 11;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 30000;
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ProjectileType<Projectiles.OrichalcumStaffProj>();
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
                .AddIngredient(ItemID.OrichalcumBar, 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}