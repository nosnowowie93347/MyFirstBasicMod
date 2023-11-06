using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Accessories
{
    public class GreenRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Emerald Ring");
            // Tooltip.SetDefault("5% increased damage");
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice(0, 0, 70, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += .05f;
            player.GetDamage(DamageClass.Magic) += .05f;
            player.GetDamage(DamageClass.Throwing) += .05f;
            player.GetDamage(DamageClass.Ranged) += .05f;
            player.GetDamage(DamageClass.Summon) += .05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 4)
                .AddIngredient(ItemID.Emerald, 3)
                .Register();
        }
    }
}