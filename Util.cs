using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod {
    class Util {

        public static bool IsMyPlayer(Player player) {
            return player.whoAmI == Main.myPlayer;
        }

        public static void SetHermesRocketBoots(Player player, float speedUp = 0.08f, float maxMPH = 34.49f) {
            player.moveSpeed += speedUp;
            player.rocketBoots = 1;
            player.accRunSpeed = maxMPH / 5.11f;
        }

        public static void SetSpectreBoots(Player player, float speedUp = 0.08f, float maxMPH = 34.49f) {
            player.moveSpeed += speedUp;
            player.rocketBoots = 2;
            player.accRunSpeed = maxMPH / 5.11f;
        }

        public static void SetFrostsparkBoots(Player player, float speedUp = 0.08f, float maxMPH = 34.49f) {
            player.moveSpeed += speedUp;
            player.rocketBoots = 3;
            player.accRunSpeed = maxMPH / 5.11f;
            player.iceSkate = true;
        }

        public static void SetArcticDivingGear(Player player) {
            player.arcticDivingGear = true;
            player.iceSkate = true;
            player.accDivingHelm = true;
            player.accFlipper = true;
            if (player.wet) {
                Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.9f, 0.9f, 0.9f);
            }
        }

        public static void SetMasterNinjaGear(Player player) {
            if (player.dash < 3) {
                player.dash = 1;
            }
            player.spikedBoots = 2;
            player.blackBelt = true;
        }

        public static void SetLavaWader(Player player, int lavaMax = 420) {
            player.fireWalk = true;
            player.waterWalk = true;
            player.lavaMax += lavaMax;
        }

        public static void AllDamageUp(Player player, float amount) {
            player.allDamage += amount;
        }

        public static void AllCritUp(Player player, int amount) {
            player.meleeCrit += amount;
            player.magicCrit += amount;
            player.rangedCrit += amount;
            player.thrownCrit += amount;
        }

        public static void RoyalGel(Player player) {
            player.npcTypeNoAggro[1] = true;
            player.npcTypeNoAggro[16] = true;
            player.npcTypeNoAggro[59] = true;
            player.npcTypeNoAggro[71] = true;
            player.npcTypeNoAggro[81] = true;
            player.npcTypeNoAggro[138] = true;
            player.npcTypeNoAggro[121] = true;
            player.npcTypeNoAggro[122] = true;
            player.npcTypeNoAggro[141] = true;
            player.npcTypeNoAggro[147] = true;
            player.npcTypeNoAggro[183] = true;
            player.npcTypeNoAggro[184] = true;
            player.npcTypeNoAggro[204] = true;
            player.npcTypeNoAggro[225] = true;
            player.npcTypeNoAggro[244] = true;
            player.npcTypeNoAggro[302] = true;
            player.npcTypeNoAggro[333] = true;
            player.npcTypeNoAggro[335] = true;
            player.npcTypeNoAggro[334] = true;
            player.npcTypeNoAggro[336] = true;
            player.npcTypeNoAggro[537] = true;
        }

        

       



    }
}
