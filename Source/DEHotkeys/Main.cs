using System.Reflection;
using HarmonyLib;
using Verse;

namespace DEHotkeys;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("DEHotkeys").PatchAll(Assembly.GetExecutingAssembly());
    }
}