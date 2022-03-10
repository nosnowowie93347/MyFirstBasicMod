using MyFirstBasicMod.Tiles;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MyFirstBasicMod.Items.Weapons
{
	public class ElvenBow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Forged by the great elves of Terraria.");
			DisplayName.SetDefault("Elven Bow");
		}

		public override void SetDefaults() {
			item.damage = 37;
			item.ranged = true;
            item.crit = 14;
			item.width = 34;
			item.height = 55;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 9999;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ItemID.Shuriken; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 22f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Emerald, 20);
			recipe.AddTile(TileID.Anvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        // How can I make the shots appear out of the muzzle exactly?
        // Also, when I do this, how do I prevent shooting through tiles?
        public override bool shoot(player player, ref vector2 position, ref float speedx, ref float speedy, ref int type, ref int damage, ref float knockback)
        {
        	vector2 muzzleoffset = vector2.normalize(new vector2(speedx, speedy)) * 25f;
        	if (collision.canhit(position, 0, 0, position + muzzleoffset, 0, 0))
        	{
        		position += muzzleoffset;
        	}
        	return true;
        }

    }
}