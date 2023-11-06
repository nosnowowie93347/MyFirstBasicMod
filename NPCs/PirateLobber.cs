using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using MyFirstBasicMod.Projectiles;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using System;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace MyFirstBasicMod.NPCs
{
	public class PirateLobber : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pirate Lobber");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.width = 34;
			NPC.height = 48;
			NPC.damage = 29;
			NPC.defense = 16;
			NPC.lifeMax = 140;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 20, 0);
			NPC.knockBackResist = 0.35f;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[31] = false;
			// Banner = NPC.type;
			// BannerItem = ModContent.ItemType<Items.Banners.PirateLobberBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Invasions.Pirates,
				new FlavorTextBestiaryInfoElement("This pirate had found rolling to be a much more effective way to transport barrels along the deck. Funnily enough, it works pretty well on foes as well!"),
			});
		}

		int frame = 0;
		bool attack = false;

		public override void AI()
		{
			NPC.spriteDirection = NPC.direction;
			Player target = Main.player[NPC.target];
			int distance = (int)Vector2.Distance(NPC.Center, target.Center);

			if (distance < 400)
			{
				if (!attack)
					ResetFrame();
				attack = true;
			}

			if (distance > 500)
			{
				if (attack)
					ResetFrame();
				attack = false;
			}

			if (attack)
			{
				NPC.velocity.X = .008f * NPC.direction;
				if (frame == 5 && NPC.frameCounter == 0)
					Attack();
			}
			else
			{
				NPC.aiStyle = 3;
				AIType = NPCID.AngryBones;
			}
		}

		private void ResetFrame()
		{
			NPC.frameCounter = 0;
			frame = 0;
		}

		private void Attack()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				var vel = new Vector2(NPC.direction * 5, 0);
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center - vel, vel, ModContent.ProjectileType<ElementBall>(), NPCUtils.ToActualDamage(60, 1.3f), 5, Main.myPlayer);
			}
			SoundEngine.PlaySound(SoundID.Item1, NPC.Center);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			var effects = NPC.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center - screenPos + new Vector2(0, NPC.gfxOffY), NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
			return false;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frame.Width = 60;
			NPC.frame.X = attack ? NPC.frame.Width : 0;
			int numFrames = attack ? 8 : 6;
			int frameDuation = attack ? 7 : 4;
			NPC.frameCounter++;
			if (NPC.frameCounter >= frameDuation)
			{
				NPC.frameCounter = 0;
				frame++;
			}
			frame %= numFrames;
			NPC.frame.Y = frameHeight * frame;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{

			int[] GoldFurniture = new int[] { ItemID.GoldenBathtub, ItemID.CoinGun, ItemID.PirateStaff, ItemID.Cutlass, ItemID.DiscountCard, ItemID.GoldenBed, ItemID.GoldenBookcase, ItemID.GoldenCandelabra, ItemID.GoldenCandle, ItemID.GoldenChair, ItemID.GoldenChandelier,
					ItemID.GoldenChest, ItemID.GoldenClock, ItemID.GoldenDoor, ItemID.GoldenDresser, ItemID.GoldenLamp, ItemID.GoldenLantern, ItemID.GoldenPiano, ItemID.GoldenShower, ItemID.GoldenSink,
					ItemID.GoldenSofa, ItemID.GoldenTable, ItemID.GoldenToilet, ItemID.GoldenWorkbench, ModContent.ItemType<Items.Accessories.OrangeRing>(), ModContent.ItemType<Items.Placeable.PinksOre>() };
			int loot = Main.rand.Next(GoldFurniture.Length);
			Item.NewItem(NPC.GetSource_Death(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, GoldFurniture[loot]);
		}

		

		public override float SpawnChance(NPCSpawnInfo spawnInfo) => SpawnCondition.Pirates.Chance * 0.1f;
	}
}