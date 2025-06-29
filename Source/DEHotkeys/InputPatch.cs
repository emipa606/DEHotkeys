using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace DEHotkeys;

[HarmonyPatch(typeof(Game), nameof(Game.UpdatePlay))]
public class InputPatch
{
    //miminally altered version of DesignatorManager.CheckSelectedDesignatorValid() for use in CheckHotkey()
    private static bool checkSelectedDesignatorValid()
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

    private static void checkHotkey(string key, int orderNum)
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
            if (checkSelectedDesignatorValid())
            {
                designator.activateSound.PlayOneShotOnCamera();
            }

            return;
        }

        SoundDefOf.CancelMode.PlayOneShotOnCamera();
        Find.DesignatorManager.Deselect();
    }

    public static void Postfix()
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

        checkHotkey("c", 0);
        checkHotkey("x", 1);
        checkHotkey("l", 2);
        checkHotkey("b", 3);
        checkHotkey("p", 4);
        checkHotkey("y", 5);
        checkHotkey("h", 6);
        checkHotkey("j", 7);
        checkHotkey("o", 8);
        checkHotkey("n", 10);
        checkHotkey("z", 11);
        checkHotkey("f", 15);
        checkHotkey("u", 16);
        checkHotkey("i", 17);
        checkHotkey("k", 18);
    }
}