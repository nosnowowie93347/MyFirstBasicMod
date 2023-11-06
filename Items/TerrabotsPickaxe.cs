using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items
{
	public class TerrabotsPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("This pickaxe was created by Terrabot, Pink's Discord bot.");
			// DisplayName.SetDefault("Terrabot's Pickaxe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults() {
			Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.pick = 230;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.75f;
			Item.value = 59990;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(11)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}
