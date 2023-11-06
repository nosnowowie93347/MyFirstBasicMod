using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent.Drawing;
using Terraria.ObjectData;
using Terraria.Localization;

namespace MyFirstBasicMod.Items.Placeable
{
	public class SylvsSink : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<SylvsSinkTile>());
			Item.width = 24;
			Item.height = 30;
			Item.value = 3000;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<SylvsBlock>(3)
				.AddTile<Tiles.PinksWorkbench>()
				.Register();
		}
	}
	public class SylvsSinkTile : ModTile
	{
		public override void SetStaticDefaults() {
			// Hello! As you may have noticed, this is a sink --- and as such, it ought to be a water source, right?
			// Well, let's do it one better, shall we?
			TileID.Sets.CountsAsWaterSource[Type] = true;
			TileID.Sets.CountsAsHoneySource[Type] = true;
			TileID.Sets.CountsAsLavaSource[Type] = true;
			// By using these three sets, we've registered our sink as counting as a water, lava, and honey source for crafting purposes! The future is now.
			// Each one works individually and independently of the other two, so feel free to make your sink a source for whatever you'd like it to be!

			// ...modded liquids sold separately.

			Main.tileSolid[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.addTile(Type);

			AddMapEntry(new Color(100, 100, 100), Language.GetText("MapObject.Sink"));

			DustType = 84;
			AdjTiles = new int[] { Type };
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}