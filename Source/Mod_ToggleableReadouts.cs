using Verse;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using RimWorld;
using static ToggleableReadouts.ToggleableReadoutsUtility;
 
namespace ToggleableReadouts
{
    public class Mod_ToggleableReadouts : Mod
	{
		public Mod_ToggleableReadouts(ModContentPack content) : base(content)
		{
			new Harmony(this.Content.PackageIdPlayerFacing).PatchAll();
			//base.GetSettings<ModSettings_ToggleableReadouts>();
			LongEventHandler.QueueLongEvent(() => Setup(), null, false, null);
		}
		/*
		static int lastNumOfLines = 1;
		public override void DoSettingsWindowContents(Rect inRect)
		{
			Listing_Standard options = new Listing_Standard();
			//Make stationary rect for the filter box
			Rect filterRect = new Rect(inRect.x, inRect.y + 30f, inRect.width, 100f);
			//Prepare scrollable view area rect
			Rect scrollViewRect = inRect;
			scrollViewRect.y += 30f;
			scrollViewRect.yMax -= 30f;
			
			//Prepare line height cache
			Text.Font = GameFont.Tiny;
			TextAnchor anchor = Text.Anchor;
			Text.Anchor = TextAnchor.MiddleLeft;

			//Calculate size of rect based on content
			Rect listRect = new Rect(0f, 0f, inRect.width - 30f, (lastNumOfLines + 2) * lineHeight);

			options.Begin(inRect);
				filter = options.TextEntryLabeled("Filter: ", filter);
				filtered = !String.IsNullOrEmpty(filter);
			options.End();
			Widgets.BeginScrollView(scrollViewRect, ref scrollPos, listRect, true);
				options.Begin(listRect);
				
				//List out the removed defs first
				for (int i = 0; i < workingList.Count; i++)
				{
					string key = workingList.ElementAt(i);
					Def def = GetDef(key);
					if (def != null && (!filtered || Search(def) != 0)) 
					{
						cellPosition += lineHeight;
						++lineNumber;
						if (cellPosition > scrollPos.y - inRect.height && cellPosition < scrollPos.y + inRect.height) DrawListItem(options, def);
					}
				}

				//Gap
				options.curY = cellPosition + lineHeight;
				options.GapLine();
				cellPosition += lineHeight;

				//List out all the unremoved defs from the compiled database
				int length = allDefs.Length;
				for (int i = 0; i < length; ++i)
				{
					Def def = allDefs[i];
					if (!workingList.Contains(GetKey(def)))
					{
						if (def != null && (!filtered || Search(def) != 0)) 
						{
							cellPosition += lineHeight;
							++lineNumber;
							if (cellPosition > scrollPos.y - inRect.height && cellPosition < scrollPos.y + inRect.height) DrawListItem(options, def);
						}
					}
				}
				lastNumOfLines = lineNumber;
				lineNumber = 0;
				cellPosition = 0;
				Text.Font = GameFont.Small;
				Text.Anchor = anchor;
				options.End();
			Widgets.EndScrollView();
			
			base.DoSettingsWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "Cherry Picker";
		}

		public override void WriteSettings()
		{
			ProcessList();
			base.WriteSettings();
		}
		*/
	}

	/*
	public class ModSettings_ToggleableReadouts : ModSettings
	{
		public override void ExposeData()
		{
			if (Scribe.mode != LoadSaveMode.Saving || legacyKeys?.Count > 0 ) Scribe_Collections.Look(ref legacyKeys, "removedDefs", LookMode.Value, LookMode.Value);
			Scribe_Collections.Look(ref removedDefs, "keys", LookMode.Value);
			if (removedDefs == null) removedDefs = new HashSet<string>();

			base.ExposeData();
		}

		public static List<string> legacyKeys = new List<string>();
		public static HashSet<string> removedDefs = new HashSet<string>();
		public static Vector2 scrollPos = Vector2.zero;
		public static string filter;
	}
	*/
}
