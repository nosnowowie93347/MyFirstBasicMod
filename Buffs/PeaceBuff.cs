using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Buffs
{
    public class PeaceBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Peace Buff");
            Description.SetDefault("Enemies are less likely to target you.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro -= (int)(player.aggro - 0.75);

        }
    }
}