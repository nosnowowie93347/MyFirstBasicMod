using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace MyFirstBasicMod.Items
{
	public class GodlyHealingPotion : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Godly Healing Potion");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;
            Tooltip.SetDefault("Heals for half of your maximum life"
				+ "\nHealing amount reduced by half if quick healing");
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 75;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.healLife = 100; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the Item to be considered a healing Item
			Item.potion = true; // Makes it so this Item applies potion sickness on use and allows it to be used with quick heal
		}


		public override void GetHealLife(Player player, bool quickHeal, ref int healValue) {
			// Make the Item heal half the player's max health normally, or one fourth if used with quick heal
			healValue = player.statLifeMax2 / (quickHeal ? 2 : 2);
		}
	}
}