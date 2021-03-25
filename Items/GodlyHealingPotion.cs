using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace MyFirstBasicMod.Items
{
	public class GodlyHealingPotion : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Godly Healing Potion");
			Tooltip.SetDefault("Heals for half of your maximum life"
				);
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 75;
			item.consumable = true;
			item.rare = ItemRarityID.Pink;
			item.healLife = 100; 
			item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Items.Placeable.PinksBar>(), 19);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}

		public override void GetHealLife(Player player, bool quickHeal, ref int healValue) {
			// Make the item heal half the player's max health
			healValue = player.statLifeMax2 / 2;
		}
	}
}