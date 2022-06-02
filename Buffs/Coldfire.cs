using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Buffs
{
    public class ColdFire : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cold Fire");
            Description.SetDefault("You're Slow.");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed = player.moveSpeed * 0.4f;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity = npc.velocity * (0.4f);
        }
    }
}