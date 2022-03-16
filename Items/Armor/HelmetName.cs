using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class HelmetName : ModItem
    {
        
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pink's Helmet");
            Tooltip.SetDefault("Immune to nearly all vanilla and calamity debuffs" + "\n" + Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 15));
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.LightRed;
            item.defense = 29;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BreastplateName>() && legs.type == ModContent.ItemType<Items.Armor.Leggings>();
        }
        public override void UpdateEquip(Player player)
        {
           Mod calamity = ModLoader.GetMod("CalamityMod");
            player.buffImmune[BuffID.OnFire] = true;
            if (calamity != null)
            {
                player.buffImmune[calamity.BuffType("BrimstoneFlames")] = true;
                player.buffImmune[calamity.BuffType("AstralInfection")] = true;
                player.buffImmune[calamity.BuffType("BurningBlood")] = true;
                player.buffImmune[calamity.BuffType("ExtremeGravity")] = true;
                player.buffImmune[calamity.BuffType("CrushDepth")] = true;
                player.buffImmune[calamity.BuffType("Clamity")] = true;
                player.buffImmune[calamity.BuffType("GodSlayerInferno")] = true;
                player.buffImmune[calamity.BuffType("WhisperingDeath")] = true;
                player.buffImmune[calamity.BuffType("WeakPetrification")] = true;
                player.buffImmune[calamity.BuffType("ArmorCrunch")] = true;
                player.buffImmune[calamity.BuffType("Plague")] = true;
                player.buffImmune[calamity.BuffType("FreezingWeather")] = true;
                player.buffImmune[calamity.BuffType("FrozenLungs")] = true;
                player.buffImmune[calamity.BuffType("LethalLavaBurn")] = true;
                player.buffImmune[calamity.BuffType("SearingLava")] = true;
                player.buffImmune[calamity.BuffType("WarCleave")] = true;
                player.buffImmune[calamity.BuffType("Warped")] = true;
                player.buffImmune[calamity.BuffType("AbyssalFlames")] = true;
                player.buffImmune[calamity.BuffType("HolyInferno")] = true;
                player.buffImmune[calamity.BuffType("PrismaticCooldown")] = true;
                player.buffImmune[calamity.BuffType("SearingLava")] = true;
                player.buffImmune[calamity.BuffType("FishAlert")] = true;
                player.buffImmune[calamity.BuffType("IcarusFolly")] = true;
                player.buffImmune[calamity.BuffType("VulnerabilityHex")] = true;
                player.buffImmune[calamity.BuffType("SulphuricPoisoning")] = true;
            }
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.WaterCandle] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Wet] = true;
            player.buffImmune[BuffID.MoonLeech] = true;
            player.buffImmune[BuffID.Midas] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.allDamage += 0.15f; //+15 % damage
            player.statLifeMax2 += 30;
            player.meleeCrit += 7;
            player.magicCrit += 11;
            player.rangedCrit += 5;
            player.statManaMax2 += 20;
            player.lifeRegen += 5;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You are awesome!. Full set bonus: +6 defense";
            player.statDefense = (int)(player.statDefense + 6.00);
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Placeable.PinksBar>(), 27);   //you need 10 Wood
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}