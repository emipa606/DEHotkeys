using System.Reflection;
using HarmonyLib;
using Verse;

namespace DEHotkeys;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        var harmony = new Harmony("DEHotkeys");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}