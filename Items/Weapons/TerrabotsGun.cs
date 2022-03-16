using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
	public class TerrabotsGun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Made by Terrabot Himself!");
			DisplayName.SetDefault("Terrabot's Gun");
		}

		public override void SetDefaults() {
			item.damage = 210;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4.5f;
			item.value = Item.sellPrice(gold: 20);
            item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 14f;
			item.useAmmo = AmmoID.Bullet;
		}

		 public override void AddRecipes() {
		 	ModRecipe recipe = new ModRecipe(mod);
		 	recipe.AddIngredient(ItemType<Placeable.PinksBar>(), 10);
		 	recipe.AddTile(TileType<PinksAnvil>());
		 	recipe.SetResult(this);
		 	recipe.AddRecipe();
		 }

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .38f;
		}

		

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(10, 0);
		}

        // How can I make the shots appear out of the muzzle exactly?

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