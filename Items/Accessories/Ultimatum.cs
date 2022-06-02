using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Accessories
{
	public class Ultimatum : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ultimatum");
			Tooltip.SetDefault("25% increased damage\n"
							 + "Increases base damage for all weapons by 3\n"
							 + "Increases total damage for all weapons by 4\n"
							 + "10% increased melee crit chance\n"
							 + "Magic attacks ignore an additional 5 defense points\n"
							 + "Increases ranged firing speed by 15%");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			
			player.GetDamage(DamageClass.Generic) *= 1.25f;
			player.GetDamage(DamageClass.Generic).Base += 3f;
			player.GetDamage(DamageClass.Generic).Flat += 4f;

			
			player.GetCritChance(DamageClass.Melee) += 10f;

			
			player.GetAttackSpeed(DamageClass.Ranged) += 0.15f;
			player.GetArmorPenetration(DamageClass.Magic) += 5f;

		}
	}
}