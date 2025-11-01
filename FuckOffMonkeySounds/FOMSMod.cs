using System.Reflection;
using BepInEx;
using HarmonyLib;

// soz for removing melon loader support, just dont know how to do it
// sincerely, hansolo1000falcon

namespace FuckOffMonkeySounds
{
    [BepInPlugin("luna.fuckoffmonkeysounds", "FuckOffMonkeySounds", "1.1.0")]
    public class FOMSMod : BaseUnityPlugin
    {
        private void Start()
        {
            Harmony harmony = new Harmony("luna.fuckoffmonkeysounds");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(VRRig), "PostTick")]
    internal static class RigPatch
    {
        private static void Prefix(VRRig __instance) => __instance.replacementVoiceLoudnessThreshold = float.MaxValue;
    }
}