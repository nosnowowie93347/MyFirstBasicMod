using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MyFirstBasicMod.Items.Weapons
{
    public class TrueBloodBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Blood Breaker");
        }
        public override void SetDefaults()
        {
            item.damage = 110;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 10;
            item.useAnimation = 40;
            item.knockBack = 9;
            item.value = 500000;
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.hammer = 100;
            item.useStyle = 1;
            item.tileBoost = 2;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override bool UseItem(Player player)
        {
            if (player.itemAnimation <= item.useTime)
            {
                if (player.velocity.Y == 0)
                {
                    Main.PlaySound(42, player.position, 207 + Main.rand.Next(3));
                }
                else
                {
                    Main.PlaySound(42, player.position, 213 + Main.rand.Next(4));
                }
            }
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodBreaker, 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}


