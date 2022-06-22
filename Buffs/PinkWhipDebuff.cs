using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Buffs
{
    public class PinkWhipDebuff : ModBuff
    {
        public override void SetStaticDefaults() {
            // This allows the debuff to be inflicted on NPCs that would otherwise be immune to all debuffs.
            // Other mods may check it for different purposes.
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex) {
            npc.GetGlobalNPC<PinkWhipDebuffNPC>().markedByPinkWhip = true;
        }
    }

    public class PinkWhipDebuffNPC : GlobalNPC
    {
        // This is required to store information on entities that isn't shared between them.
        public override bool InstancePerEntity => true;

        public bool markedByPinkWhip;

        public override void ResetEffects(NPC npc) {
            markedByPinkWhip = false;
        }

        
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            // Only player attacks should benefit from this buff, hence the NPC and trap checks.
            if (markedByPinkWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type])) {
                damage += 5;
            }
        }
    }
}