using MyFirstBasicMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace MyFirstBasicMod.Items.Weapons
{
	public class Banhammer : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Banhammer");
			// Tooltip.SetDefault("One of the best hammers I've ever seen");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults() {
			Item.damage = 85;
            Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.hammer = 105;      //How much hammer power the weapon has
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(19)
                .AddIngredient<Items.EpicSoul>(9)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}

