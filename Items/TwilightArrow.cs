using MyFirstBasicMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class TwilightArrow : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Twilight's Arrow");
			Tooltip.SetDefault("Behold. You are now in posession of Twilight's Arrow.");
		}

		public override void SetDefaults() {
			item.damage = 60;
			item.ranged = true;
			item.width = 1;
			item.height = 1;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 100000;
			item.rare = ItemRarityID.Orange;
			item.shoot = ProjectileType<Projectiles.TwilightArrow>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
		public override void OnConsumeAmmo(Player player) {
			if (Main.rand.NextBool(5)) {
				player.AddBuff(BuffID.Wrath, 300);
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 50);
			recipe.AddIngredient(ItemType<Items.Placeable.PinksBar>(), 1);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}