using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Placeable
{
	public class GlowingBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Glowing Bar");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }


		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.value = 10000;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.rare = ItemRarityID.Yellow;
			Item.consumable = true;
			Item.maxStack = 99;
			Item.createTile = ModContent.TileType<Tiles.GlowingBar>();
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.GlowingOre>(4)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}