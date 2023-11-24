using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace LethalWidescreen.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("OnEnable")]
        private static void OnEnable()
        {
            GameObject ingamePlayerHud = GameObject.Find("Panel");

            RectTransform panelRectTransform = ingamePlayerHud.GetComponent<RectTransform>();

            panelRectTransform.anchorMin = new Vector2(0, 0);
            panelRectTransform.anchorMax = new Vector2(1, 1);

            panelRectTransform.pivot = new Vector2(0, 1);

            panelRectTransform.anchoredPosition = Vector2.zero;

            panelRectTransform.sizeDelta = Vector2.zero;
            
            ManualLogSource mls = LethalWidescreen.mls;


            float xScaleFactor = Screen.width / (Screen.height * (16f / 9f));
            mls.LogInfo("!!! " + xScaleFactor + " set to xScaleFactor!");


            panelRectTransform.localScale = new Vector3(xScaleFactor+0.1f, 1f, 1f);
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void LateUpdate(PlayerControllerB __instance)
        {
            Camera camera = __instance.gameplayCamera;
            __instance.targetFOV = camera.fieldOfView * 1.25f;
        }
    }
}
