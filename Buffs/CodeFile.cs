using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Buffs
{
    public class PinksDefenseBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Defensive Buff");
            Description.SetDefault("Grants +12 defense.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 12; //Grant a +4 defense boost to the player while the buff is active.
        }
    }
}