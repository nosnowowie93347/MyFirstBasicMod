using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod
{
	// This class contains thoughtful examples of item recipe creation.
	public class ExampleRecipes : ModSystem
	{
		// A place to store the recipe group so we can easily use it later
		public static RecipeGroup ExampleRecipeGroup;

		public override void Unload() {
			ExampleRecipeGroup = null;
		}

		public override void AddRecipeGroups() {
			// Create a recipe group and store it
			// Language.GetTextValue("LegacyMisc.37") is the word "Any" in english, and the corresponding word in other languages
			ExampleRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<Items.Placeable.PinksBar>())}",
				ModContent.ItemType<Items.Placeable.PinksBar>(), ModContent.ItemType<Items.Placeable.PinksBar>());

			RecipeGroup.RegisterGroup("MyFirstBasicMod:PinksBar", ExampleRecipeGroup);
		}

		public override void AddRecipes() {
			////////////////////////////////////////////////////////////////////////////////////
			// The following basic recipe makes 999 ExampleItems out of 1 stone block. //
			////////////////////////////////////////////////////////////////////////////////////

			Recipe recipe = Recipe.Create(ItemID.Amber, 999);
			// This adds a requirement of 1 dirt block to the recipe.
			recipe.AddIngredient(ItemID.StoneBlock);
			// When you're done, call this to register the recipe.
			recipe.Register();

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			// The following recipe showcases and explains all methods (functions) present on Recipe, and uses an 'advanced' style called 'chaining'. //
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			// The reason why the said chaining works is that all methods on Recipe, with the exception of Register(), return its own instance,
			// which lets you call subsequent methods on that return value, without having to type a local variable's name.
			// When using chaining, note that only the last line is supposed to have a semicolon (;).

			var resultItem = ModContent.GetInstance<Items.Placeable.PinksBar>();

			// Start a new Recipe.
			resultItem.CreateRecipe()
				// Adds a Vanilla Ingredient.
				// Look up ItemIDs: https://github.com/tModLoader/tModLoader/wiki/Vanilla-Item-IDs
				// To specify more than one ingredient type, use multiple recipe.AddIngredient() calls.
				.AddIngredient(ItemID.StoneBlock)
				// An optional 2nd argument will specify a stack of the item. Any calls to any AddIngredient overload without a stack value at the end will have the stack default to 1.
				.AddIngredient(ItemID.Acorn, 10)
				// We can also specify the current item as an ingredient
				.AddIngredient(resultItem)
				// Adds a Mod Ingredient. Do not attempt ItemID.EquipMaterial, it's not how it works.
				.AddIngredient<Items.Weapons.Banhammer>()
				// An alternate string-based approach to the above. Try to only use it for other mods' items, because it's slower.
				.AddIngredient(Mod, "Banhammer")

				// RecipeGroups allow you create a recipe that accepts items from a group of similar ingredients. For example, all varieties of Wood are in the vanilla "Wood" Group
				// Check here for other vanilla groups: https://github.com/tModLoader/tModLoader/wiki/Intermediate-Recipes#using-existing-recipegroups
				.AddRecipeGroup(RecipeGroupID.Wood)
				// Just like with AddIngredient, there's a stack parameter with a default value of 1.
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				// Here is using a mod recipe group. Check out AddRecipeGroups() to see how to register a recipe group.
				.AddRecipeGroup(ExampleRecipeGroup, 2)
				// An alternate string-based approach to the above. Try to only use it for other mods' groups, because it's slower.
				.AddRecipeGroup("Wood")
				.AddRecipeGroup("MyFirstBasicMod:PinksBar", 2)

				// Adds a vanilla tile requirement.
				// To specify a crafting station, specify a tile. Look up TileIDs: https://github.com/tModLoader/tModLoader/wiki/Vanilla-Tile-IDs
				.AddTile(TileID.WorkBenches)
				// Adds a mod tile requirement. To specify more than one crafting station, use multiple recipe.AddTile() calls.
				.AddTile<Tiles.PinksWorkbench>()
				// An alternate string-based approach to the above. Try to only use it for other mods' tiles, because it's slower.
				.AddTile(Mod, "PinksWorkbench")

				// Adds pre-defined conditions. These 3 lines combine to make so that the recipe must be crafted in desert waters at night.
				.AddCondition(Recipe.Condition.InDesert)
				.AddCondition(Recipe.Condition.NearWater)
				.AddCondition(Recipe.Condition.TimeNight)
				// Adds a custom condition, that the player must be at <1/2 health for the recipe to work.
				// The first argument is a NetworkText instance, i.e. localized text. The key used here is defined in 'Localization/*.hjson' files.
				// The second argument uses a lambda expression to create a delegate, you can learn more about both in Google.
				.AddCondition(NetworkText.FromKey("RecipeConditions.LowHealth"), r => Main.LocalPlayer.statLife < Main.LocalPlayer.statLifeMax / 2)

				// When you're done, call this to register the recipe. Note that there's a semicolon at the end of the chain.
				.Register();

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			// The following recipe showcases and explains cloning recipes and how they can modified to differ from the original recipes they came from. //
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			// If you want to make a copy of an existing recipe with a slight difference, you can use Mod.CloneRecipe to create a clone of that recipe.
			// The clone will inherit all of the original recipe's properties except the owner mod will be this mod. You can change the clone as you see fit.
			// If you want to make multiple variations of a recipe in your mod, it may be easier to use a helper method instead of cloning.
			// Make sure to not use recipe cloning for situations that are better served by properly using AdjTiles, Recipe Groups, or faking various recipe conditions.

			// Start by creating a recipe you want to copy.
			Recipe baseRecipe = Recipe.Create(ModContent.ItemType<Items.Placeable.PinksBar>(), 10);
			baseRecipe.AddIngredient(ItemID.Wood, 10)
				.AddIngredient(ItemID.CopperCoin)
				.AddCondition(Recipe.Condition.InBeach)
				.AddCondition(Recipe.Condition.TimeDay)
				.Register();

			// Start a new Recipe by cloning another recipe.
			Recipe clonedRecipe = baseRecipe.Clone()
				// We can new properties to this recipe without affecting the one we cloned from.
				.AddIngredient(ItemID.SilverCoin)
				.AddTile(TileID.Anvils);

			// We can also remove properties from recipes like specific ingredients or conditions.
			clonedRecipe.RemoveIngredient(ItemID.CopperCoin);
			clonedRecipe.RemoveCondition(Recipe.Condition.InBeach);

			// When you're done, call this to register the recipe.
			clonedRecipe.Register();
		}

		public override void PostAddRecipes() {
			for (int i = 0; i < Recipe.numRecipes; i++) {
				Recipe recipe = Main.recipe[i];

				// All recipes that require wood will now need 100% more
				if (recipe.TryGetIngredient(ItemID.Wood, out Item ingredient)) {
					ingredient.stack *= 2;
				}
			}
		}
	}
}