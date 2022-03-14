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
            item.damage = 99;
            item.ranged = true;
            item.crit = 11;
            item.width = 50;
            item.height = 18;
            item.useTime = 4;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; 
            item.knockBack = 4; 
            item.value = 2481;
            item.color = new Color(61, 252, 3); 
            item.rare = ItemRarityID.Green; 
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<FlamethrowerProjectile>();
            item.shootSpeed = 9f; 
            item.useAmmo = AmmoID.Gel; 
        }

        
        public override bool ConsumeAmmo(Player player)
        {
            
            return player.itemAnimation >= player.itemAnimationMax - 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flamethrower);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.PinksBar>(), 5);
            recipe.AddIngredient(ItemID.CursedFlame, 15);
            recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
            recipe.SetResult(this);
            recipe.AddRecipe();
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