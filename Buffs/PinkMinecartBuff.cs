using MyFirstBasicMod.Mounts;
using MyFirstBasicMod.Items;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Buffs
{
    //TODO 1.4.5: review MinecartLeft/Right if it still exists
    public class PinkMinecartBuff : ModBuff
    {
        

        // Use the vanilla Description
        public override LocalizedText Description => Language.GetText("BuffDescription.MinecartLeft");

        public override void SetStaticDefaults()
        {
            BuffID.Sets.BasicMountData[Type] = new BuffID.Sets.BuffMountData()
            {
                mountID = ModContent.MountType<PinkMinecart>()
            };
        }
    }
}