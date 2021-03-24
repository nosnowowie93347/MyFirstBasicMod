using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace MyFirstBasicMod.Items.Accessories {
    class StardustScarab : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Stardust Scroll");
            Tooltip.SetDefault(
                "\"You are their master\"\n" +
                "Reduces damage taken by 10%\n" +
                "30% increased minion damage\n" +
                "Increases your max number of minions by 4\n" +
                "Minor increases to all stats\n" +
                "Enemies are a LOT less likely to target you");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 7));
        }
        public override void SetDefaults() {
            item.width = 20;
            item.height = 20;
            item.value = 300000;
            item.rare = ItemRarityID.Red;
            item.expert = true;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            float defenseBonus = 10f; // max 10% reduction and 10 defense that grows 2%p per sec and maxes out in 5 sec
            player.statDefense += (int) Math.Round(defenseBonus) + 4; // celestial stone effect
            Util.AllDamageUp(player, 0.1f);
            player.minionDamage += 0.2f;
            Util.AllCritUp(player, 2);
            player.meleeSpeed += 0.12f;
            player.pickSpeed += 0.30f;
            player.minionKB += 0.5f;
            player.maxMinions += 4;
            player.lifeRegen += 3;
            player.aggro -= 450;
        }
        public override void AddRecipes() {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PapyrusScarab);
            recipe.AddIngredient(ItemID.CelestialStone);
            recipe.AddIngredient(ItemID.WormScarf);
            recipe.AddIngredient(ItemID.LunarBar, 17);
            recipe.AddIngredient(ItemID.FragmentStardust, 23);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
