using MyFirstBasicMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class ExamplePet : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Paper Airplane");
			Tooltip.SetDefault("Summons a Paper Airplane to follow aimlessly behind you");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.ExamplePet>();
			item.buffType = ModContent.BuffType<Buffs.ExamplePet>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 10);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}