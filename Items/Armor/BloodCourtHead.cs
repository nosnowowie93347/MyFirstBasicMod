using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BloodCourtHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodcourt's Visage");
			// Tooltip.SetDefault("30% increased magic damage\nIncreases your max number of minions, Increases magic crit strike chance by 20%, and +100 max mana");

			ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 90000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 25;
		}

        public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.30f;
			player.GetCritChance(DamageClass.Magic) += 20;
			player.statManaMax2 += 100;
			player.maxMinions += 1;
		}


		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immunity to a bunch of debuffs.";
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
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
        }


		public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<BloodCourtChestplate>() && legs.type == ModContent.ItemType<BloodCourtLeggings>();

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ModContent.ItemType<Items.DreamstrideEssence>(), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}