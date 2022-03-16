using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstExampleMod.Items
{

	public class SolarEruption : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.SolarEruption)
			{ 
				item.damage = 112;       
			}
		}
	}
}