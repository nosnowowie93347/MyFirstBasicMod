using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Buffs
{
	public class AnnoyingLittleLight : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Annoying Light");
			Description.SetDefault("Ugh, soooo annoying");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<PinksPlayer>().annoyingLittleLight = true;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.AnnoyingLittleLightProj>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.AnnoyingLittleLightProj>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			if (player.controlDown && player.releaseDown) {
				if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15) {
					for (int j = 0; j < 1000; j++) {
						if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType<Projectiles.AnnoyingLittleLightProj>() && Main.projectile[j].owner == player.whoAmI) {
							Projectile lightpet = Main.projectile[j];
							Vector2 vectorToMouse = Main.MouseWorld - lightpet.Center;
							lightpet.velocity += 5f * Vector2.Normalize(vectorToMouse);
						}
					}
				}
			}
		}
	}
}