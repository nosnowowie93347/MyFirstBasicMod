using MyFirstBasicMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
	public class JoeysFlail : ModItem
	{
	public override void SetStaticDefaults() {
			DisplayName.SetDefault("Joey's Flail");
			Tooltip.SetDefault("This flail was made by Joey");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.Cyan;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
			item.damage = 200;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<Projectiles.ExampleFlailProjectile>();
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 9;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddIngredient(ModContent.ItemType<Items.EpicSoul>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}