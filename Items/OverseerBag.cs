using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
	public class OverseerBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Consumable\nRight Click to open");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }


		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.rare = -2;

			Item.maxStack = 30;

			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(30, 54));
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.TerrabotsGun>());
			player.QuickSpawnItem(ModContent.ItemType<Items.EpicSoul>(), Main.rand.Next(18, 28));

			int[] lootTable = {
				ModContent.ItemType<Items.Weapons.TerrabotsGun>(),
				ModContent.ItemType<Items.TerrabotsPickaxe>(),
				ModContent.ItemType<Items.Test>(),
				ModContent.ItemType<Items.Weapons.TerrabotsBullet>()
			};
			int loot = Main.rand.Next(lootTable.Length);
			player.QuickSpawnItem(lootTable[loot]);

						
		}
	}
}