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
            item.damage = 70; 
            item.magic = true;
            item.crit = 11;
            item.width = 54; //Item width
            item.height = 54; //Item height
            item.maxStack = 1; //How many of this item you can stack
            item.useTime = 7; 
            item.useAnimation = 7;
            item.knockBack = 1f; 
            item.noMelee = true; 
            item.useStyle = ItemUseStyleID.HoldingOut; 
            item.value = 120000; 
            item.rare = ItemRarityID.Yellow; 
            item.shoot = ProjectileID.VortexLightning; 
            item.shootSpeed = 7f; 
            item.mana = 5;
            item.autoReuse = true; 
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
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