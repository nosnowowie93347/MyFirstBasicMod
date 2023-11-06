using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace MyFirstBasicMod.Utilities
{
	/// <summary>
	/// A class containing useful methods for registering <c>BossChecklist</c> information,
	/// along with internal methods for initializing <see cref="SpiritMod"/>-specific data.
	/// </summary>
	public static class BossChecklistDataHandler
	{
		public static string IsNullOrEmptyFallback(this string str, string fallback) =>
			string.IsNullOrEmpty(str)
				? fallback
				: str;

		public enum EntryType
		{
			Boss,
			Miniboss,
			Event
		}

		public static Mod BossChecklistMod
		{
			get
			{
				if (ModLoader.TryGetMod("BossChecklist", out Mod result))
					return result;
				return null;
			}
		}

		public static bool BossChecklistIsLoaded => BossChecklistMod != null;

		public class BCIDData
		{
			public readonly List<int> npcIDs;
			public readonly List<int> itemSpawnIDs;
			public readonly List<int> itemCollectionIDs;
			public readonly List<int> itemLootIDs;

			public BCIDData(List<int> npcIDs, List<int> itemSpawnIDs, 
				List<int> itemCollectionIDs, List<int> itemLootIDs)
			{
				this.npcIDs = npcIDs;
				this.itemSpawnIDs = itemSpawnIDs;
				this.itemCollectionIDs = itemCollectionIDs;
				this.itemLootIDs = itemLootIDs;
			}
		}

		public static void AddBoss(this Mod mod, float progression, string npcName, Func<bool> downedCondition,
			BCIDData identificationData, string spawnInfo, string despawnMessage, string texture,
			string overrideHeadIconTexture, Func<bool> bossAvailable) =>
			AddBCEntry(EntryType.Boss, mod, progression, npcName, downedCondition, identificationData, spawnInfo,
				despawnMessage, texture, overrideHeadIconTexture, bossAvailable);

		public static void AddMiniBoss(this Mod mod, float progression, string npcName, Func<bool> downedCondition,
			BCIDData identificationData, string spawnInfo, string despawnMessage, string texture,
			string overrideHeadIconTexture, Func<bool> bossAvailable) =>
			AddBCEntry(EntryType.Miniboss, mod, progression, npcName, downedCondition, identificationData, spawnInfo,
				despawnMessage, texture, overrideHeadIconTexture, bossAvailable);

		public static void AddEvent(this Mod mod, float progression, string eventName, Func<bool> downedCondition,
			BCIDData identificationData, string spawnInfo, string despawnMessage, string texture,
			string overrideHeadIconTexture,
			Func<bool> eventAvailable) =>
			AddBCEntry(EntryType.Event, mod, progression, eventName, downedCondition, identificationData, spawnInfo,
				despawnMessage, texture, overrideHeadIconTexture, eventAvailable);

		private static void AddBCEntry(EntryType entryType, Mod mod, float progression, string bcName,
			Func<bool> downedCondition, BCIDData identificationData, string spawnInfo,
			string despawnMessage, string texture, string overrideHeadIconTexture,
			Func<bool> bossAvailable)
		{
			string addType;

			switch (entryType) {
				case EntryType.Boss:
					addType = "AddBoss";
					break;

				case EntryType.Miniboss:
					addType = "AddMiniBoss";
					break;

				case EntryType.Event:
					addType = "AddEvent";
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(entryType), entryType, null);
			}

			BossChecklistMod.Call(
				addType,
				progression,
				identificationData.npcIDs ?? new List<int>(),
				mod,
				bcName,
				downedCondition,
				identificationData.itemSpawnIDs ?? new List<int>(),
				identificationData.itemCollectionIDs ?? new List<int>(),
				identificationData.itemLootIDs ?? new List<int>(),
				spawnInfo.IsNullOrEmptyFallback("Mods.BossChecklist.BossLog.DrawnText.NoInfo"),
				despawnMessage.IsNullOrEmptyFallback(entryType == EntryType.Boss
					? "Mods.BossChecklist.BossVictory.Generic"
					: ""),
				texture.IsNullOrEmptyFallback("BossChecklist/Resources/BossTextures/BossPlaceholder_byCorrina"),
				overrideHeadIconTexture,
				bossAvailable ?? (() => true)
			);
		}
		
		internal static void RegisterSpiritData(Mod MyFirstBasicMod)
		{
			if (!BossChecklistIsLoaded)
				return;

			RegisterInterfaces(MyFirstBasicMod);
		}

		private static void RegisterInterfaces(Mod MyFirstBasicMod)
		{
			foreach (Type type in MyFirstBasicMod.Code.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IBCRegistrable)))) {
				BCIDData identificationData = new BCIDData(null, null, null, null);
				string spawnInfo = "";
				string despawnMessage = "";
				string texture = "";
				string headTextureOverride = "";
				Func<bool> isAvailable = null;

				if (!(Activator.CreateInstance(type) is IBCRegistrable registrableType))
					continue;

				registrableType.RegisterToChecklist(out EntryType entryType, out float progression, out string name,
					out Func<bool> downedCondition, ref identificationData, ref spawnInfo, ref despawnMessage,
					ref texture, ref headTextureOverride, ref isAvailable);

				AddBCEntry(entryType, MyFirstBasicMod, progression, name, downedCondition, identificationData, spawnInfo, despawnMessage, texture, headTextureOverride, isAvailable);
			}
		}
	}
}