using MyFirstBasicMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GlowingHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Faceplate");
			Tooltip.SetDefault("Increases melee damage by 12% and melee speed by 13%");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.defense = 63;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.GlowingBody>() && legs.type == ModContent.ItemType<Items.Armor.GlowingLegs>();
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
            player.allDamage += 0.85f; //+15 % damage
            player.statLifeMax2 += 80;
            player.meleeCrit += 13;
            player.meleeDamage += 0.9f;
            player.magicDamage += 0.9f;
            player.magicCrit += 18;
            player.rangedCrit += 12;
            player.statManaMax2 += 70;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You are awesome!. Full set bonus: +14 defense";
            player.statDefense = (int)(player.statDefense + 14.00);
            player.allDamage += 0.2f;
        }
        public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TrueSolarFlareHelmet>());
			recipe.AddIngredient(ModContent.ItemType<Items.Placeable.GlowingBar>(), 15);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}