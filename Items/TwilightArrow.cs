using MyFirstBasicMod.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 999;
        }

		public override void SetDefaults() {
			Item.damage = 300;
            Item.DamageType = DamageClass.Ranged;
			Item.width = 1;
			Item.height = 1;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the Item consumable so that the ammo would automatically consumed
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileType<Projectiles.TwilightArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 16f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
		public override void OnConsumeAmmo(Player player) {
			if (Main.rand.NextBool(5)) {
				player.AddBuff(BuffID.Wrath, 300);
			}
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(1)
                .AddIngredient(ItemID.WoodenArrow, 50)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}