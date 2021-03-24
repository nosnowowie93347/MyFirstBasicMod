using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Consumable
{
    public class PeacePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("GIVE PEACE A CHANCE, MAN");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 45;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 6);
            item.buffType = ModContent.BuffType<Buffs.PeaceBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 18000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
    }
}