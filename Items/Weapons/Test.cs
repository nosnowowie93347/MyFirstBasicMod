using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MyFirstBasicMod.Items.Weapons
{
	public class SuperSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Super Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("It's OPNess is over 9000!!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults() 
		{
            Item.CloneDefaults(ItemID.Zenith);
			Item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(9)
                .AddIngredient<Items.EpicSoul>(9)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}