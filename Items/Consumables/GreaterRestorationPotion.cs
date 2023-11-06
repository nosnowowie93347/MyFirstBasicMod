using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Consumables
{
    public class GreaterRestorationPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Greater Restoration Potion");
            // Tooltip.SetDefault("Reduced potion cooldown");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 20;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 28;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = 2500;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item3;
            Item.potion = true;
            Item.healLife = 120;
            Item.healMana = 120;
        }
        public override bool ConsumeItem(Player player)
        {
            player.ClearBuff(21);
            player.potionDelay = player.restorationDelayTime;
            player.AddBuff(21, player.potionDelay, true);
            return base.ConsumeItem(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RestorationPotion);
            recipe.AddIngredient(ItemID.PixieDust);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }

    }
}