using MyFirstBasicMod.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)] // Load the spritesheet you create as a shield for the player when it is equipped.
	public class EpicShield : ModItem
	{
		public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 3;
            /* Tooltip.SetDefault("25% increased damage\n"
				 + "Increases base damage for all weapons by 3\n"
				 + "Increases total damage for all weapons by 4\n"
				 + "10% increased melee crit chance\n"
				 + "Magic attacks ignore an additional 5 defense points\n"
				 + "Increases ranged firing speed by 15%"); */
        }
		public override void SetDefaults() {
			
			Item.width = 24;
			Item.height = 28;
			Item.value = Item.buyPrice(10);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;

			Item.defense = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
	
			player.GetDamage(DamageClass.Generic) *= 1.25f;
			player.GetDamage(DamageClass.Generic).Base += 3f;
			player.GetDamage(DamageClass.Generic).Flat += 4f;
			player.GetCritChance(DamageClass.Melee) += 10f;
			player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Frozen] = true;
			player.GetAttackSpeed(DamageClass.Ranged) += 0.15f;
			player.GetArmorPenetration(DamageClass.Magic) += 5f;

		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<PinksBar>()
				.AddIngredient(ItemID.CobaltShield)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}