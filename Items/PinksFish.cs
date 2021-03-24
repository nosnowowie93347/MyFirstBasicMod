using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Items
{
    public class PinksFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pink's Fish");
        }

        public override void SetDefaults()
        {
            item.questItem = true;
            item.maxStack = 1;
            item.width = 26;
            item.height = 26;
            item.uniqueStack = true;
            item.rare = ItemRarityID.Quest;
        }

        public override bool IsQuestFish()
        {
            return true;
        }

        public override bool IsAnglerQuestAvailable()
        {
            return Main.hardMode;
        }

        public override void AnglerQuestChat(ref string description, ref string catchLocation)
        {
            description = "I've heard stories of a fish that belongs to someone named Pinkalicious. I'd love to know who this is. Go fetch!";
            catchLocation = "Caught anywhere.";
        }
    }
}