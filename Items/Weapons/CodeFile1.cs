using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
    public class GlowSting : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seraph's Strike");
            Tooltip.SetDefault("Right-click to release a flurry of strikes");
        }

        int currentHit;
        public override void SetDefaults()
        {
            Item.damage = 47;
            Item.DamageType = DamageClass.Melee;
            Item.width = 34;
            Item.height = 40;
            Item.autoReuse = true;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<Projectiles.GlowStingSpear>();
            Item.shootSpeed = 10f;
            this.currentHit = 0;
        }
        
        
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.noUseGraphic = true;
                Item.shoot = ModContent.ProjectileType<Projectiles.GlowStingSpear>();
                Item.useStyle = ItemUseStyleID.HoldUp;
                Item.useTime = 7;
                Item.useAnimation = 7;
                Item.damage = 34;
                Item.knockBack = 2;
                Item.shootSpeed = 8f;
            }
            else
            {
                Item.damage = 47;
                Item.noUseGraphic = false;
                Item.useTime = 25;
                Item.useAnimation = 25;
                Item.shoot = ProjectileID.None;
                Item.knockBack = 5;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.shootSpeed = 0f;
            }
            if (player.ownedProjectileCounts[Item.shoot] > 0)
                return false;
            return true;
        }
        public override void UseStyle(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                for (int projFinder = 0; projFinder < 300; ++projFinder)
                {
                    if (Main.projectile[projFinder].type == ModContent.ProjectileType<Projectiles.GlowStingSpear>())
                    {
                        Main.projectile[projFinder].Kill();
                        Main.projectile[projFinder].timeLeft = 2;
                    }
                }
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Vector2 origVect = new Vector2(speedX, speedY);
                Vector2 newVect;
                if (Main.rand.Next(2) == 1)
                {
                    newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                else
                {
                    newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                }
                speedX = newVect.X;
                speedY = newVect.Y;
                this.currentHit++;
                return true;
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.GlowingBar>(12)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }

    }
}