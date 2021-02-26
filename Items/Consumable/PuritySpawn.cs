using MyFirstBasicMod.NPCs.PuritySpirit;
using MyFirstBasicMod.Tiles;
using MyFirstBasicMod.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Consumable
{
	//imported from my tAPI mod because I'm lazy
	public class PuritySpawn : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Spawns in the master of pureness.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.rare = ItemRarityID.Cyan;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player) {
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return NPC.downedPlantBoss && !NPC.AnyNPCs(ModContent.NPCType<PuritySpirit>()) && !NPC.AnyNPCs(ModContent.NPCType<PurityShield>());
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Abomination.Abomination>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeetleHusk);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<PinksBar>(), 10);
			recipe.AddTile(ModContent.TileType<ExampleWorkbench>());
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}