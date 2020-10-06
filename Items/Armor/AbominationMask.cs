<<<<<<< HEAD
﻿using Terraria.ModLoader;
using Terraria.ID;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AbominationMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
=======
﻿using Terraria.ModLoader;
using Terraria.ID;

namespace MyFirstBasicMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AbominationMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
>>>>>>> cc441405b0cde9937a83bfd44804b397531f5ddc
}