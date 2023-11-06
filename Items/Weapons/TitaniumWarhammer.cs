using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Weapons
{
    public class TitaniumWarhammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Titanium Warhammer");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }


        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightRed;

            Item.hammer = 86;

            Item.damage = 50;
            Item.knockBack = 8.5f;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TitaniumBar, 13)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}