using Microsoft.Xna.Framework;
using MyFirstBasicMod.Items;
using MyFirstBasicMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace MyFirstBasicMod.Items.Weapons
{
	public class BirdSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deity's Lineage");
			Tooltip.SetDefault("'Contains the souls of everyone who's used this weapon");

		}


		int charger;
		public override void SetDefaults()
		{
			item.damage = 89;
			item.useTime = 19;
			item.useAnimation = 19;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.shootSpeed = 10;
			item.UseSound = SoundID.Item69;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.DeityBlast>();
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 244);
				Main.dust[dust].noGravity = true;

			}
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{

			{
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<DeityBlast>(), damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.EpicSoul>(), 15);
			recipe.AddTile(ModContent.TileType<Tiles.PinksAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}