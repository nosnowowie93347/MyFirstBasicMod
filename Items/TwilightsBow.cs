using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace MyFirstBasicMod.Items
{
	public class TwilightsBow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Behold! It's Twilight's Bow!");
			DisplayName.SetDefault("Twilight's Bow");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults() {
			Item.damage = 120;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 65;
			Item.useTime = 14;
			Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 99999;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 31f;
			Item.useAmmo = AmmoID.Arrow;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Items.Placeable.PinksBar>(20)
                .AddIngredient(ItemID.MoltenFury)
                .AddTile<Tiles.PinksWorkbench>()
                .Register();
        }

        /*
		 * Feel free to uncomment any of the examples below to see what they do
		 */

        // What if I wanted this gun to have a 38% chance not to consume ammo?
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .18f;
		}

		

		
		// Also, when I do this, how do I prevent shooting through tiles?
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		

	}
}
