using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
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
        public const int maxPinkLifeFruits = 20;
        public const int LifePerFruit = 5;


        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault($"Permanently increases maximum life by {LifePerFruit}\nUp to {maxPinkLifeFruits} can be used");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.color = Color.Purple;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override bool CanUseItem(Player player)
        {
            // Any mod that changes statLifeMax to be greater than 500 is broken and needs to fix their code.
            // This check also prevents this item from being used before vanilla health upgrades are maxed out.
            return player.statLifeMax == 500 && player.GetModPlayer<PinksPlayer>().pinkLifeFruits < PinksPlayer.maxPinkLifeFruits;
        }

        public override bool? UseItem(Player player)
        {
            // Do not do this: player.statLifeMax += 2;
            player.statLifeMax2 += LifePerFruit;
            player.statLife += LifePerFruit;
            if (Main.myPlayer == player.whoAmI)
            {
                // This spawns the green numbers showing the heal value and informs other clients as well.
                player.HealEffect(LifePerFruit, true);
            }

            // This is very important. This is what makes it permanent.
            player.GetModPlayer<PinksPlayer>().pinkLifeFruits++;
            // This handles the 2 achievements related to using any life increasing item or getting to exactly 500 hp and 200 mp.
            // Ignored since our item is only useable after this achievement is reached
            // AchievementsHelper.HandleSpecialEvent(player, 2);
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