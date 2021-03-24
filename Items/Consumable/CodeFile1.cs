using MyFirstBasicMod.NPCs.Overseer;
using MyFirstBasicMod.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Consumable
{
    public class GodSpawner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Spawner");
            Tooltip.SetDefault("Use at nighttime to summon the Overseer");
        }


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = ItemRarityID.Cyan;
            item.maxStack = 99;

            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<Overseer>()) && !Main.dayTime)
                return true;
            return false;
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Overseer>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 4);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddIngredient(ModContent.ItemType<PinksBar>(), 4);
            recipe.AddIngredient(ItemID.LunarBar, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}