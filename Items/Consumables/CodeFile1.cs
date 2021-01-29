using Terraria;
using Terraria.ID;
using MyFirstBasicMod.NPCs.Overseer;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MyFirstBasicMod.Items.Consumables
{
    public class SpiritIdol : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Idol");
            Tooltip.SetDefault("'Awaken the Being, asleep for aeons'");
        }


        public override void SetDefaults()
        {
            Item.width = Item.height = 16;
            Item.rare = ItemRarityID.Cyan;
            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = Item.useAnimation = 20;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            if (!Main.dayTime)
                return true;
            return false;
        }
        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Overseer>());
            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        
    }
}