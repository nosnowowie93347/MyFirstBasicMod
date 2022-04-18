using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MyFirstBasicMod.Projectiles;

namespace MyFirstBasicMod.Items.Weapons
{
    
    public class PinksFlamethrower : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.Flamethrower;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots a jet of flames\nThis is Pink's favorite weapon.");
        }

        public override void SetDefaults()
        {
            Item.damage = 99;
            Item.DamageType = DamageClass.Ranged;
            Item.crit = 11;
            Item.width = 50;
            Item.height = 18;
            Item.useTime = 4;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; 
            Item.knockBack = 4; 
            Item.value = 24811;
            Item.color = new Color(61, 252, 3); 
            Item.rare = ItemRarityID.Green; 
            Item.UseSound = SoundID.Item34;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<FlamethrowerProjectile>();
            Item.shootSpeed = 9f; 
            Item.useAmmo = AmmoID.Gel; 
        }

        
        public override bool ConsumeAmmo(Player player)
        {
            
            return Player.itemAnimation >= Player.itemAnimationMax - 4;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Flamethrower)
                .AddIngredient(ItemType<Items.Placeable.PinksBar>(), 5)
                .AddIngredient(ItemID.CursedFlame, 15)
                .AddTile(TileType<Tiles.PinksAnvil>())
                .Register();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 54f; 
            if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
            {
                position += muzzleOffset;
            }
            
            return true;
        }
        public override Vector2? HoldoutOffset()
        
        {
            return new Vector2(0, -2); 
        }
    }
}