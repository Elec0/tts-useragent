using MelonLoader;
using HarmonyLib;
using UnityEngine.Networking;
using System.Reflection;

// Define your mod's meta registration attributes
[assembly: MelonInfo(typeof(TTSUserAgentChanger.ModCore), "TTS Custom User-Agent", "1.0.0", "Elec0")]
[assembly: MelonGame("Berserk Games", "Tabletop Simulator")]

namespace TTSUserAgentChanger
{
    public class ModCore : MelonMod
    {
        public static MelonPreferences_Category configCategory;
        public static MelonPreferences_Entry<string> userAgent;
        public override void OnInitializeMelon()
        {
            configCategory = MelonPreferences.CreateCategory("TTSUserAgentChanger", "TTS Custom User-Agent");
            userAgent = configCategory.CreateEntry("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            LoggerInstance.Msg("Custom User-Agent initialized successfully!");

            // Save immediately so the change shows up in the preferences file without having to close the game
            MelonPreferences.Save();
        }
    }

    // Intercept the UnityWebRequest execution sequence globally
    [HarmonyPatch]
    public static class UnityWebRequestPatch
    {
        // Target the standard Unity execution method for web requests
        [HarmonyTargetMethod]
        public static MethodBase TargetMethod()
        {
            return typeof(UnityWebRequest).GetMethod("SendWebRequest", BindingFlags.Public | BindingFlags.Instance);
        }

        // Apply a Prefix patch to alter the object instance data before execution
        [HarmonyPrefix]
        public static void Prefix(UnityWebRequest __instance)
        {
            if (__instance != null)
            {
                __instance.SetRequestHeader("User-Agent", ModCore.userAgent.Value);
            }
        }
    }
}
