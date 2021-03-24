using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
    public class TrueEmeraldStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Emerald staff");
            Tooltip.SetDefault("'Blow all your enemies away'");
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.magic = true;
            item.crit = 6;
            item.mana = 9;
            item.width = 40;
            item.height = 40;
            item.useTime = 7;
            item.useAnimation = 7;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 120000; //How much the item is worth
            item.rare = ItemRarityID.Yellow; //The rarity of the item
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ProjectileID.EmeraldBolt;
            item.shootSpeed = 8f;
        }

        

        
    }
}