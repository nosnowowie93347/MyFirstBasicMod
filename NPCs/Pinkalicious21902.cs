using System;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using MyFirstBasicMod.Dusts;
using MyFirstBasicMod.Items;
using MyFirstBasicMod.Items.Placeable;
using MyFirstBasicMod.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
namespace MyFirstBasicMod.NPCs
{
    // [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class Pinkalicious21902 : ModNPC
    {
        private static Profiles.StackedNPCProfile NPCProfile;
        public override string Texture => "MyFirstBasicMod/NPCs/ExamplePerson";

        public const string ShopName = "Shop";
        public int NumberOfTimesTalkedTo = 0;

        public override void SetStaticDefaults() {
            Main.npcFrameCount[Type] = 25; // The total amount of frames the NPC has

            NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs. This is the remaining frames after the walking frames.
            NPCID.Sets.AttackFrameCount[Type] = 4; // The amount of frames in the attacking animation.
            NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the NPC that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 0; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
            NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30; // The denominator for the chance for a Town NPC to attack. Lower numbers make the Town NPC appear more aggressive.
            NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers() {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            // Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
            // NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love) // Loves living near the dryad.
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Dislike) // Dislikes living near the merchant.
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate) // Hates living near the demolitionist.
            ; // < Mind the semicolon!

            // This creates a "profile" for ExamplePerson, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party")
            );
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 30;
            NPC.defense = 95;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
        }

        public override void HitEffect(NPC.HitInfo hit) {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++) {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Sparkle>());
            }

            // Create gore when the NPC is killed.
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0) {
                // Retrieve the gore types. This NPC has shimmer and party variants for head, arm, and leg gore. (12 total gores)
                string variant = "";
                if (NPC.IsShimmerVariant) variant += "_Shimmer";
                if (NPC.altTexture == 1) variant += "_Party";
                int hatGore = NPC.GetPartyHatGore();
                int headGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Head").Type;
                int armGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Arm").Type;
                int legGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Leg").Type;

                // Spawn the gores. The positions of the arms and legs are lowered for a more natural look.
                if (hatGore > 0) {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) { // Requirements for the town NPC to spawn.
            for (int k = 0; k < Main.maxPlayers; k++) {
                Player player = Main.player[k];
                if (!player.active) {
                    continue;
                }

                // Player has to have a PinksBar in order for the NPC to spawn
                if (player.inventory.Any(item => item.type == ModContent.ItemType<PinksBar>() || item.type == ModContent.ItemType<Items.Placeable.PinksOre>())) {
                    return true;
                }
            }

            return false;
        }
    


        // Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
        

        public override List<string> SetNPCNameList() {
            return new List<string>() {
                
                "Somebody",
                "Blocky",
                "Colorless"
            };
        }

        public override void FindFrame(int frameHeight)
        {
            /*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
        }

        public override string GetChat()
        {
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
            }
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "Sometimes I feel like I'm different from everyone else here.";
                case 1:
                    return "What's your favorite color? My favorite colors are pink and blue.";
               
                case 2:
                    {
                        return "I am Pinkalicious21902, the creator of this mod!";
                    }
                case 3:
                    {
                        return "IT'S TIME TO DUEL!";
                    }
                default:
                    return "What? I don't have any arms or legs? Oh, don't be ridiculous!";
            }
        }

        /* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/
        public override void SetChatButtons(ref string button, ref string button2) {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "stuff";
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop) {
            if (firstButton) {
                // We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
                shop = ShopName;
            }
            else {
                // If the 2nd button is pressed, open the inventory...
                Main.playerInventory = true;
                // remove the chat window...
                Main.npcChatText = "";
                // and start an instance of our UIState.
                
                // Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
            }
        }
        

        
        public override void AddShops() {
            var npcShop = new NPCShop(Type, ShopName);
                

            if (ModContent.TryFind("CalamityMod/Cryophobia", out ModItem cryophobia)) {
                npcShop.Add(cryophobia.Type);
            }
			if (Main.hardMode && NPC.downedPirates) {
				if (ModContent.TryFind("CalamityMod/AbsoluteZero", out ModItem AbsoluteZero)) {
					npcShop.Add(AbsoluteZero.Type);
				}
			}
			if (Main.hardMode && NPC.downedPlantBoss) {
				if (ModContent.TryFind("CalamityMod/BlossomFlux", out ModItem BlossomFlux)) {
					npcShop.Add(BlossomFlux.Type);
				}
			}
			if (NPC.downedMoonlord) {
				npcShop.Add(ModContent.ItemType<GodlyHealingPotion>());
			}
			npcShop.Add(ModContent.ItemType<SwordOfDreams>());
			npcShop.Add(ModContent.ItemType<TerrabotsBullet>());
			npcShop.Add(ModContent.ItemType<TerrabotsGun>());
			
            npcShop.Register(); // Name of this shop tab
        }
        // public override void SetupShop(Chest shop, ref int nextSlot)
        // {
        //     var modCalamity = ModLoader.GetMod("CalamityMod");
        //     if (modCalamity != null)
        //     {

        //         shop.item[nextSlot].SetDefaults(modCalamity.ItemType("Cryophobia"));
        //         nextSlot++;
        //         if (Main.hardMode && NPC.downedPirates)
        //         {
        //             shop.item[nextSlot].SetDefaults(modCalamity.ItemType("AbsoluteZero"));
        //             nextSlot++;
        //         }
        //         //If Plantera is dead, and the world is in Expert mode, sell blossom flux from calamity
        //         if (NPC.downedPlantBoss && Main.expertMode)
        //         {
        //             shop.item[nextSlot].SetDefaults(modCalamity.ItemType("BlossomFlux"));
        //             nextSlot++;
        //         }
        //         //If moon lord is dead, sell rampart of deities
        //         if (NPC.downedMoonlord) {
        //             shop.item[nextSlot].SetDefaults(modCalamity.ItemType("RampartOfDeities"));
        //             nextSlot++;
        //             shop.item[nextSlot].SetDefaults(modCalamity.ItemType("OmegaHealingPotion"));
        //             nextSlot++;
        //         }
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.SwordOfDreams>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.TerrabotsBullet>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BreadPickaxe>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.IrohsHamaxe>());
        //         nextSlot++;
        //     }
        //     if (modCalamity == null)
        //     {
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.SylvsBlock>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.TerrabotsBullet>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.TerrabotsGun>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.TrueEdgeShortsword>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.SwordOfDreams>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BreadPickaxe>());
        //         nextSlot++;
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.IrohsHamaxe>());
        //         nextSlot++;
        //     }
            
        //     if (Main.moonPhase < 2)
        //     {
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Test>());
        //         nextSlot++;
        //     }
        //     else if (Main.moonPhase < 6)
        //     {
        //         shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.EpicLaserOfDoom>());
        //         nextSlot++;
        //     }
        //     else
        //     {
        //     }
        //     // // Here is an example of how your npc can sell items from other mods.
        //     // var modCalamity = ModLoader.GetMod("Calamity");
        //     // if (modCalamity != null) {
        //     //     shop.item[nextSlot].SetDefaults(modCalamity.ItemType("RampartOfDeities"));
        //     //     nextSlot++;
        //     // }
            
            
        // }

        // public override void ModifyNPCLoot(NPCLoot npcLoot)
        // {
        //     Item.NewItem(NPC.getRect(), ModContent.ItemType<Items.Armor.RubysRobe>());
        // }

        // Make this Town NPC teleport to the King and/or Queen statue when triggered.
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }

        // Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)NPC.whoAmI);
                packet.Send();
            }
            else
            {
                StatueTeleport();
            }
        }

        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }
                Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<Dusts.Sparkle>(), Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 10;
        }

        

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}