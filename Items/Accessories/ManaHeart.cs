using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MyFirstBasicMod.Items.Accessories
{
	public class ManaHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Heals you by 20 health for every 200 mana consumed.");
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<PinksPlayer>().manaHeart = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the Item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

	}
}
