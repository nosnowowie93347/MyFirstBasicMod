using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Buffs
{
    public class PinkWhipDebuff : ModBuff
    {
        public static readonly int TagDamage = 5;
        public override void SetStaticDefaults() {
            // This allows the debuff to be inflicted on NPCs that would otherwise be immune to all debuffs.
            // Other mods may check it for different purposes.
            BuffID.Sets.IsATagBuff[Type] = true;
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

        
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers) {
            // Only player attacks should benefit from this buff, hence the NPC and trap checks.
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;


            // SummonTagDamageMultiplier scales down tag damage for some specific minion and sentry projectiles for balance purposes.
            var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
            if (npc.HasBuff<PinkWhipDebuff>()) {
                // Apply a flat bonus to every hit
                modifiers.FlatBonusDamage += PinkWhipDebuff.TagDamage * projTagMultiplier;
            }

            
        }
    }
}