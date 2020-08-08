using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class GodlyHealingPotion : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Godly Healing Potion");
			Tooltip.SetDefault("Heals for half of your maximum life"
				+ "\nHealing amount reduced by half if quick healing");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 75;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.healLife = 100; // While we change the actual healing value in GetHealLife, item.healLife still needs to be higher than 0 for the item to be considered a healing item
			item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
		}

		public override void GetHealLife(Player player, bool quickHeal, ref int healValue) {
			// Make the item heal half the player's max health normally, or one fourth if used with quick heal
			healValue = player.statLifeMax2 / (quickHeal ? 2 : 2);
		}
	}
}