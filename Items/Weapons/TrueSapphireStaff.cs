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
        }

        public override void SetDefaults()
        {
            item.damage = 70; //The damage
            item.magic = true;
            item.crit = 11;
            item.width = 54; //Item width
            item.height = 54; //Item height
            item.maxStack = 1; //How many of this item you can stack
            item.useTime = 5; //How **** this **** takes for the item to be used -gamrguy: Really? Just really? -Graydee: It was movildima, not me
            item.useAnimation = 5; //How long the animation of the item takes
            item.knockBack = 1f; //How much knockback the item produces
            item.noMelee = true; //Whether the weapon should do melee damage or not
            item.useStyle = ItemUseStyleID.HoldingOut; //How the weapon is held, 5 is the gun hold style
            item.value = 120000; //How much the item is worth
            item.rare = ItemRarityID.Yellow; //The rarity of the item
            item.shoot = ProjectileID.VortexLightning; //What the item shoots, retains an int value | *
            item.shootSpeed = 7f; //How fast the projectile fires
            item.mana = 4;
            item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
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