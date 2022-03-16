using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MyFirstBasicMod.Buffs
{
	public class PinkMinecartBuff : ModBuff 
	{ 
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Pink Minecart");
			Description.SetDefault("Ride the rails in style, with a pink minecart!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<Mounts.PinkMinecart>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}