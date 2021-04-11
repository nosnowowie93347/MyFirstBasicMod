using Terraria.ID;

namespace MyFirstBasicMod.Projectiles
{
    public class ChlorophyteSolution : OreSpreadSolution
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            oreID = TileID.Chlorophyte;
            replacingTiles = TileID.Sets.Mud;
        }
    }
}
