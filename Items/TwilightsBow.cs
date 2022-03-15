using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class TwilightsBow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Behold! It's Twilight's Bow!");
			DisplayName.SetDefault("Twilight's Bow");
		}

		public override void SetDefaults() {
			item.damage = 137;
			item.ranged = true;
            item.crit = 14;
			item.width = 34;
			item.height = 55;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 99999;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = ItemID.Shuriken; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 22f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.Placeable.PinksBar>(), 20);
            recipe.AddIngredient(ItemID.MoltenFury, 1);
			recipe.AddTile(TileType<PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.VenomArrow) // or ProjectileID.WoodenArrowFriendly
            {
                type = ProjectileType<Projectiles.TwilightArrow>(); // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
    }
}
}
