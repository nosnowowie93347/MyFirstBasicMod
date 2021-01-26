using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
    /// <summary>
    ///     Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
    ///     See Source code for Star Wrath projectile to see how it passes through tiles.
    ///     For a detailed sword guide see <see cref="ExampleSword" />
    /// </summary>
    public class SwordOfDreams : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword of Dreams");
            Tooltip.SetDefault("This sword belongs to a user going by the name Dream.\nIt's OPNess is over 9000!!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 31;
            Item.height = 47;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 210;
            Item.knockBack = 6;
            Item.crit = 9;

            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item1;

            Item.shoot = ProjectileID.StarWrath; // ID of the projectiles the sword will shoot
            Item.shootSpeed = 8f; // Speed of the projectiles the sword will shoot
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
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(15)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}
