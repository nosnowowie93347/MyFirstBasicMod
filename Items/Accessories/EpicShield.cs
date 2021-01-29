using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class EpicShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Epic Shield");
            Tooltip.SetDefault("Provides immunity to a few important debuffs\nAs health decreases, defense increases");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 36;
            item.rare = ItemRarityID.Pink;
            item.value = 100000;
            item.accessory = true;
            item.defense = 6;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PocketMirror, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            float defBoost = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2 * 20f;
            player.statDefense += (int)defBoost;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Frozen] = true;
        }
    }
}