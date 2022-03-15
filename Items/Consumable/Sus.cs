using MyFirstBasicMod.NPCs;
using MyFirstBasicMod.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Consumable
{
    public class sus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sus");
            Tooltip.SetDefault("Don't...");
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
            if (!NPC.AnyNPCs(ModContent.NPCType<Ocram2>()) && Main.hardMode && !Main.dayTime)
                return true;
            return false;
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Ocram2>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddIngredient(ItemType<PinksBar>(), 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}