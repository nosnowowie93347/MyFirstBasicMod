using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Placeable
{
	public class PinksAnvil : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is a modded Anvil.");
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 24;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = TileType<Tiles.PinksAnvil>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			    .AddIngredient(ItemID.IronAnvil)
			    .AddIngredient<Items.Placeable.PinksBar>(12)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
	}
}