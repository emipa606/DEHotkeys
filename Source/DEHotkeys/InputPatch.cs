﻿using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace DEHotkeys;

[HarmonyPatch(typeof(Game))]
[HarmonyPatch("UpdatePlay")]
public class InputPatch
{
    //miminally altered version of DesignatorManager.CheckSelectedDesignatorValid() for use in CheckHotkey()
    private static bool CheckSelectedDesignatorValid()
    {
        if (Find.DesignatorManager.SelectedDesignator == null)
        {
            return false;
        }

        if (Find.DesignatorManager.SelectedDesignator.CanRemainSelected())
        {
            return true;
        }

        Find.DesignatorManager.Deselect();
        return false;
    }

    private static void CheckHotkey(string key, int orderNum)
    {
        if (!Input.GetKeyDown(key))
        {
            return;
        }

        var designator = DefDatabase<DesignationCategoryDef>.AllDefsListForReading[0]
            .AllResolvedDesignators[orderNum];
        if (Find.DesignatorManager.SelectedDesignator != designator)
        {
            Find.DesignatorManager.Select(designator);
            if (CheckSelectedDesignatorValid())
            {
                designator.activateSound.PlayOneShotOnCamera();
            }

            return;
        }

        SoundDefOf.CancelMode.PlayOneShotOnCamera();
        Find.DesignatorManager.Deselect();
    }

    private static void Postfix()
    {
        //if Hotkeys are enabled in the current context
        if (Find.World.renderer.wantedMode != WorldRenderMode.None || Find.MainTabsRoot.OpenTab != null &&
            (Find.MainTabsRoot.OpenTab.defName.Equals(
                    "Architect") &&
                ((MainTabWindow_Architect)Find
                    .MainTabsRoot
                    .OpenTab.TabWindow)
                .selectedDesPanel !=
                null || Find.MainTabsRoot.OpenTab.defName
                    .Equals("Inspect")))
        {
            return;
        }

        CheckHotkey("c", 0);
        CheckHotkey("x", 1);
        CheckHotkey("l", 2);
        CheckHotkey("b", 3);
        CheckHotkey("p", 4);
        CheckHotkey("y", 5);
        CheckHotkey("h", 6);
        CheckHotkey("j", 7);
        CheckHotkey("o", 8);
        CheckHotkey("n", 10);
        CheckHotkey("z", 11);
        CheckHotkey("f", 15);
        CheckHotkey("u", 16);
        CheckHotkey("i", 17);
        CheckHotkey("k", 18);
    }
}