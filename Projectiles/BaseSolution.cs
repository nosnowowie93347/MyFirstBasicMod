using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyFirstBasicMod.Projectiles
{
	public abstract class BaseSolution : ModProjectile
	{

        public override string Texture
        {
            get
            {
                return "MyFirstBasicMod/Projectiles/BaseSolution";
            }
        }

        public int minDistance = 0;
        public int maxTime = 133;
        public int dustType = 110;
        public int radius = 2;

        public bool toChange = true;

        public override void AutoStaticDefaults()
        {
            base.AutoStaticDefaults();
            DisplayName.SetDefault("Clentaminator Spray");
        }

        public override void SetDefaults()
		{
			//projectile.name = "Conversion Spray";
			projectile.width = 6;
			projectile.height = 6;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

        public override void AI()
		{
            //int dustType = ModContent.DustType("DirtSolution");
            if (minDistance >= 0)
            {
                if (projectile.owner == Main.myPlayer)
                {
                    Player p = Main.player[Main.myPlayer];
                    float xCenter = projectile.position.X + (float)(projectile.width / 2);
                    float yCenter = projectile.position.Y + (float)(projectile.height / 2);
                    float pxCenter = p.position.X + (float)(p.width / 2);
                    float pyCenter = p.position.Y + (float)(p.height / 2);
                    double distance = Math.Sqrt((xCenter - pxCenter) * (xCenter - pxCenter) + (yCenter - pyCenter) * (yCenter - pyCenter));

                    if (distance > minDistance)
                        Convert((int)(projectile.position.X + (float)(projectile.width / 2)) / 16, (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16, radius);
                }
            }
			if (projectile.timeLeft > maxTime)
			{
				projectile.timeLeft = maxTime;
			}
			if (projectile.ai[0] > 7f)
			{
				float dustScale = 1f;
				if (projectile.ai[0] == 8f)
				{
					dustScale = 0.2f;
				}
				else if (projectile.ai[0] == 9f)
				{
					dustScale = 0.4f;
				}
				else if (projectile.ai[0] == 10f)
				{
					dustScale = 0.6f;
				}
				else if (projectile.ai[0] == 11f)
				{
					dustScale = 0.8f;
				}
				projectile.ai[0] += 1f;
				for (int i = 0; i < radius*2 + 1; i++)
				{
                    int dustIndex = -1;
                    ModDust md = ModDust.GetDust(dustType);
                    if (md == null)
                    {
                        dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                    }else
                    {
                        dustIndex = Dust.NewDust(new Vector2(projectile.position.X - radius * 16, projectile.position.Y), projectile.width + radius * 32, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                    }

					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1.75f;
					dust.velocity.X = dust.velocity.X * 2f;
					dust.velocity.Y = dust.velocity.Y * 2f;
					dust.scale *= dustScale;
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * (float)projectile.direction;
		}

		public virtual void Convert(int i, int j, int size = 4)
		{
			
		}
	}
}
