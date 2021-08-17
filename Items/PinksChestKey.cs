using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace MyFirstBasicMod.Items
{
	class PinksChestKey : ModItem
	{
		public override void SetDefaults() {
			//item.CloneDefaults(ItemID.GoldenKey);
			item.width = 14;
			item.height = 20;
			item.maxStack = 99;
		}
	}
}