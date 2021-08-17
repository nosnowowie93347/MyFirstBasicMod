using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace MyFirstBasicMod
{
	public class MyFirstBasicMod : Mod
	{
        public override void PostSetupContent()
        {
            // Showcases mod support with Boss Checklist without referencing the mod
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                    "AddBoss",
                    10.5f,
                    new List<int> { ModContent.NPCType<NPCs.Abomination.Abomination>(), ModContent.NPCType<NPCs.Abomination.CaptiveElement2>() },
                    this, // Mod
                    "$Mods.MyFirstBasicMod.NPCName.Abomination",
                    (Func<bool>)(() => PinksWorld.downedAbomination),
                    ModContent.ItemType<Items.Abomination.FoulOrb>(),
                    new List<int> { ModContent.ItemType<Items.Armor.AbominationMask>(), ModContent.ItemType<Items.Placeable.AbominationTrophy>() },
                    new List<int> { ModContent.ItemType<Items.Abomination.SixColorShield>(), ModContent.ItemType<Items.Abomination.MoltenDrill>() },
                    "$Mods.MyFirstBasicMod.BossSpawnInfo.Abomination"
                );

            }
        }
    }
}