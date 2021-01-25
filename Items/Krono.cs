using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class Krono : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Krono"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("We all have darkness inside us.\nThis weapon brings it out.");
		}

		public override void SetDefaults()
		{
			Item.damage = 166;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
			Item.height = 70;
			Item.useTime = 14;
			Item.useAnimation = 11;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = 99999;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item16;
			Item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(15)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}