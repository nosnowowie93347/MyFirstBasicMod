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
            DisplayName.SetDefault("Emerald Ring");
            Tooltip.SetDefault("5% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice(0, 0, 70, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += .05f;
            player.magicDamage += .05f;
            player.thrownDamage += .05f;
            player.rangedDamage += .05f;
            player.minionDamage += .05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 4);
            recipe.AddIngredient(ItemID.Emerald, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}