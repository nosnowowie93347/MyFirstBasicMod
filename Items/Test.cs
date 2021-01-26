using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class Test : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Pink's Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Waaaaaay too overpowered.\nIt's OPNess is over 9000!!");
		}

		public override void SetDefaults() 
		{
			Item.damage = 200;
            Item.DamageType = DamageClass.Melee;
            Item.width = 30;
			Item.height = 60;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7;
			Item.value = 99999;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(13)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}