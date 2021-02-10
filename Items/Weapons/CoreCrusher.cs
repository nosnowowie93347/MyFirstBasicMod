using MyFirstBasicMod.Items.Placeable;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
	public class CoreCrusher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Core Crusher");
			Tooltip.SetDefault("Launches fire waves");
		}


		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.rare = ItemRarityID.Orange;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.knockBack = 7;
			item.value = 99990;
			item.damage = 70;
            item.crit = 10;
            item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<Projectiles.CoreCrusher>();
			item.shootSpeed = 15f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GlowingBar>(), 14);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}