using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Shaders;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.Core;
using Terraria.Utilities;
using Terraria.UI.Chat;
using MyFirstBasicMod.Utilities;
using static Terraria.ModLoader.Core.TmodFile;
namespace MyFirstBasicMod
{
	public class MyFirstBasicMod : Mod
	{
		public bool FinishedContentSetup { get; private set; }
		public override void PostSetupContent()
		{
			if (!Main.dedServ)
			{
				//nighttimeAmbience = new SoundLooper(this, "Sounds/NighttimeAmbience"); //NEEDSUPDATE
				//underwaterAmbience = new SoundLooper(this, "Sounds/UnderwaterAmbience");
				//wavesAmbience = new SoundLooper(this, "Sounds/WavesAmbience");
				//lightWind = new SoundLooper(this, "Sounds/LightWind");
				//desertWind = new SoundLooper(this, "Sounds/DesertWind");
				//caveAmbience = new SoundLooper(this, "Sounds/CaveAmbience");
				//spookyAmbience = new SoundLooper(this, "Sounds/SpookyAmbience");
				//scarabWings = new SoundLooper(this, "Sounds/BossSFX/Scarab_Wings");
			}


			BossChecklistDataHandler.RegisterSpiritData(this);

			FinishedContentSetup = true;
		}
	}
}