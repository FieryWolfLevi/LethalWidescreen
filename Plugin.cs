using BepInEx;
using System;
using UnityEngine;
using HarmonyLib;

namespace LethalWidescreen
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class LethalWidescreen : BaseUnityPlugin
    {
        internal static ManualLogSource mls;
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        private static LethalWidescreen Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(PluginInfo.PLUGIN_GUID);

            mls.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            harmony.PatchAll();
        }
    }
}
