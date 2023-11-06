using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace MyFirstBasicMod.Items.Weapons
{
	// This is an example showing how to create a weapon that fires custom ammunition
	// The most important property is "Item.useAmmo". It tells you which item to use as ammo.
	// You can see the description of other parameters in the ExampleGun class and at https://github.com/tModLoader/tModLoader/wiki/Item-Class-Documentation
	public class FrostyGun : ModItem
	{
		public override void SetDefaults() {
			Item.width = 42; // The width of item hitbox
			Item.height = 30; // The height of item hitbox

			Item.autoReuse = true;  // Whether or not you can hold click to automatically use it again.
			Item.damage = 12; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged; // What type of damage does this item affect?
			Item.knockBack = 4f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.
			Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
			Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAnimation = 35; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useTime = 35; // The item's use time in ticks (60 ticks == 1 second.)
			Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, shoot, etc.)
			Item.value = Item.buyPrice(gold: 1); // The value of the weapon in copper coins

			// Custom ammo and shooting homing projectiles
			Item.shoot = ModContent.ProjectileType<ExampleHomingProjectile>();
			Item.useAmmo = ModContent.ItemType<ExampleCustomAmmo>(); // Restrict the type of ammo the weapon can use, so that the weapon cannot use other ammos
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.IceBlock, 50)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddTile<Tiles.PinksAnvil>()
				.Register();
		}
	}
	public class ExampleCustomAmmo : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults() {
			Item.width = 14; // The width of item hitbox
			Item.height = 14; // The height of item hitbox

			Item.damage = 13; // The damage for projectiles isn't actually 8, it actually is the damage combined with the projectile and the item together
			Item.DamageType = DamageClass.Ranged; // What type of damage does this ammo affect?

			Item.maxStack = Item.CommonMaxStack; // The maximum number of items that can be contained within a single stack
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
			Item.knockBack = 2f; // Sets the item's knockback. Ammunition's knockback added together with weapon and projectiles.
			Item.value = Item.sellPrice(0, 0, 1, 0); // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
			Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
			Item.shoot = ModContent.ProjectileType<ExampleHomingProjectile>(); // The projectile that weapons fire when using this item as ammunition.

			Item.ammo = Item.type; // Important. The first item in an ammo class sets the AmmoID to its type
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		// Here we create recipe for 999/ExampleCustomAmmo stack from 1/ExampleItem
		public override void AddRecipes() {
			CreateRecipe(999)
				.AddIngredient(ItemID.EmptyBullet, 100)
				.AddIngredient<Items.Placeable.PinksBar>()
				.AddTile<Tiles.PinksAnvil>()
				.Register();
		}
	}

	public class ExampleHomingProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}

		// Setting the default parameters of the projectile
		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
		public override void SetDefaults() {
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox

			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Ranged; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.light = 1f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
		}

		// Custom AI
		public override void AI() {
			float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target
			float projSpeed = 5f; // The speed at which the projectile moves towards the target

			// Trying to find NPC closest to the projectile
			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
			Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
		}

		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance) {
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs(max always 200)
			for (int k = 0; k < Main.maxNPCs; k++) {
				NPC target = Main.npc[k];
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy()) {
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance) {
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
	}
}