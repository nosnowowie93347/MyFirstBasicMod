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
			Tooltip.SetDefault("This pickaxe was created by Terrabot, Pink's Discord bot.");
			DisplayName.SetDefault("Terrabot's Pickaxe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults() {
			Item.damage = 200;
            Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.pick = 235;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7.5f;
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
