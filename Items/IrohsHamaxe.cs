using MyFirstBasicMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class IrohsHamaxe : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Iroh's Hamaxe");
			Tooltip.SetDefault("Made by IrohPlayz999YT, a friend of Pink");
		}

		public override void SetDefaults() {
			Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
			Item.height = 40;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.axe = 190;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			Item.hammer = 165;      //How much hammer power the weapon has
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 999999;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(10)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}

