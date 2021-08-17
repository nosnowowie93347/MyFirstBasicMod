using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
	public class TerrabotsGun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Made by Terrabot Himself!");
			DisplayName.SetDefault("Terrabot's Gun");
		}

		public override void SetDefaults() {
			item.damage = 240;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = Item.sellPrice(platinum: 3);
            item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}

		 public override void AddRecipes() {
		 	ModRecipe recipe = new ModRecipe(mod);
		 	recipe.AddIngredient(ItemType<Placeable.PinksBar>(), 10);
		 	recipe.AddTile(TileType<PinksAnvil>());
		 	recipe.SetResult(this);
		 	recipe.AddRecipe();
		 }

		/*
		 * Feel free to uncomment any of the examples below to see what they do
		 */

		// What if I wanted this gun to have a 38% chance not to consume ammo?
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .38f;
		}

		// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
		// Uzi/Molten Fury style: Replace normal Bullets with Highvelocity
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.BulletHighVelocity; // or ProjectileID.FireArrow;
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}*/

		// What if I wanted it to shoot like a shotgun?
		// Shotgun style: Multiple Projectiles, Random spread 
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}*/

		// What if I wanted an inaccurate gun? (Chain Gun)
		// Inaccurate Gun style: Single Projectile, Random spread 
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}*/

		// What if I wanted multiple projectiles in a even spread? (Vampire Knives) 
		// Even Arc style: Multiple Projectile, Even Spread 
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}*/

		// Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(10, 0);
		}

        // How can I make the shots appear out of the muzzle exactly?
        // Also, when I do this, how do I prevent shooting through tiles?
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
	}
}