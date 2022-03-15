using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
   
    public class TrueEdgeShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Edge Shortsword");
            Tooltip.SetDefault("The shortsword version of the True Night's Edge");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 42;

            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTime = 18;
            item.useAnimation = 18;
            item.autoReuse = true;

            item.melee = true;
            item.damage = 95;
            item.knockBack = 4.25f;
            item.crit = 5;
            item.value = Item.buyPrice(gold: 10);
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item1;

            item.shoot = ProjectileID.NightBeam; // ID of the projectiles the sword will shoot
            item.shootSpeed = 11.25f; // Speed of the projectiles the sword will shoot
        }
        // This method gets called when firing your weapon/sword.
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            // Loop these functions 3 times.
            for (int i = 0; i < 3; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y + (Main.rand.Next(-40, 41) * 0.02f);
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NightsEdge);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
