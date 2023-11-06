using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{

    public class CobaltShortsword : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 42;

            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = true;
            Item.damage = 38;
            Item.knockBack = 4.75f;
            Item.crit = 8;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;

        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CobaltBar, 7)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}