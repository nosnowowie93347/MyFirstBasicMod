using Terraria.ModLoader;
using Terraria.ID;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AbominationMask : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.rare = ItemRarityID.Blue;
			Item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
}