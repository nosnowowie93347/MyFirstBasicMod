using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MyFirstBasicMod.Items
{
    // Making an item like Life Fruit (That goes above 500) involves a lot of code, as there are many things to consider.
    // (An alternate that approaches 500 can simply follow vanilla code, however.):
    // You can't make player.statLifeMax more than 500 (it won't save), so you'll have to maintain your extra life within your mod.
    // Within your ModPlayer, you need to save/load a count of usages. You also need to sync the data to other players. 
    internal class PinksLifeFruit : ModItem
    {
        public static readonly int maxPinkLifeFruits = 20;
        public static readonly int LifePerFruit = 10;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(LifePerFruit, maxPinkLifeFruits);

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault($"Permanently increases maximum life by {LifePerFruit}\nUp to {maxPinkLifeFruits} can be used");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.color = Color.Purple;
        }

        public override bool CanUseItem(Player player) {
            // This check prevents this item from being used before vanilla health upgrades are maxed out.
            return player.ConsumedLifeCrystals == Player.LifeCrystalMax && player.ConsumedLifeFruit == Player.LifeFruitMax;
        }

        public override bool? UseItem(Player player) {
            // Moving the exampleLifeFruits check from CanUseItem to here allows this example fruit to still "be used" like Life Fruit can be
            // when at the max allowed, but it will just play the animation and not affect the player's max life
            if (player.GetModPlayer<PinksPlayer>().pinkLifeFruits >= maxPinkLifeFruits) {
                // Returning null will make the item not be consumed
                return null;
            }

            // This method handles permanently increasing the player's max health and displaying the green heal text
            player.UseHealthMaxIncreasingItem(LifePerFruit);

            // This field tracks how many of the example fruit have been consumed
            player.GetModPlayer<PinksPlayer>().pinkLifeFruits++;

            return true;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.EpicSoul>(5)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }
    }
}