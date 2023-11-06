using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace MyFirstBasicMod.Items
{
    public class BreadPickaxe : ModItem 
    {
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("Made of the strongest bread in all the land.");
            // DisplayName.SetDefault("Bread Pickaxe");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void SetDefaults() {
            Item.damage = 70;
            Item.autoReuse = true;
            Item.pick = 155;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.width = 40;
            Item.height = 40;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(14)
                .AddTile<Tiles.PinksAnvil>()
                .Register();
        }
    }
}
