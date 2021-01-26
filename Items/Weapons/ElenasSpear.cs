using MyFirstBasicMod.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
	public class ElenasSpear : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ellie's Spear");
			Tooltip.SetDefault("The spear that belongs to my sister!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults() {
			Item.damage = 80;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 18;
			Item.useTime = 16;
			Item.shootSpeed = 3.7f;
			Item.knockBack = 6.5f;
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(silver: 10);

            Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an Item. This prevents the melee hitbox of this Item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this Item.
			Item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<ElenasSpearProjectile>();
		}
		
		public override bool CanUseItem(Player player) {
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
     //   public override void AddRecipes()
       // {
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(ItemType<Placeable.PinksBar>(), 20);
        //    recipe.AddIngredient(ItemID.DarkLance, 1);
        //   recipe.AddTile(TileID.WorkBenches);
        //    recipe.SetResult(this, 1);
          //  recipe.AddRecipe();
      //  }
    }
}
