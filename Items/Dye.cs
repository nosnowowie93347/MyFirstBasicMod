using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
    internal class PinkHairDye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pink's Dye");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            
            item.height = 26;
            item.maxStack = 99;
            item.value = Item.buyPrice(gold: 5);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item3;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.consumable = true;
        }
    }
}