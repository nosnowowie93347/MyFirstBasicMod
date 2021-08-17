
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	internal class RubysRobe : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 14;
			item.rare = ItemRarityID.Pink;
			item.vanity = false;
			item.defense = 28;
			item.expertOnly = false;
		}

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
		{
			robes = true;
			// The equipSlot is added in ExampleMod.cs --> Load hook
			equipSlot = mod.GetEquipSlot("RubysRobe_Legs", EquipType.Legs);
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}
	}
}