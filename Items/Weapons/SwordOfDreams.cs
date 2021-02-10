using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
   
    public class SwordOfDreams : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword of Dreams");
            Tooltip.SetDefault("This sword belongs to a user going by the name Dream.\nIt's OPNess is over 9000!!");
        }

        public override void SetDefaults()
        {
            item.width = 46;
            item.height = 62;

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 14;
            item.useAnimation = 14;
            item.autoReuse = true;

            item.melee = true;
            item.damage = 310;
            item.knockBack = 5.75f;
            item.crit = 11;
            item.value = Item.buyPrice(platinum: 7);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;

            item.shoot = ProjectileID.StarWrath; // ID of the projectiles the sword will shoot
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
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 24);
            recipe.AddIngredient(ItemID.NightsEdge);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
