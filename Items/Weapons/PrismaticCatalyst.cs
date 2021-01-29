
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
    public class PrismaticCatalyst : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prismatic Catalyst");
            Tooltip.SetDefault("'Clense your soul'");
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 55;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 77;
            Item.useAnimation = 77;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = 30000;
            Item.rare = ItemRarityID.Orange;
            Item.healLife = 10;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
        }
    }
}