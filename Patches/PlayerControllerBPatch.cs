using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
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

            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            panelRectTransform.sizeDelta = new Vector2(screenWidth / 8, screenHeight / 8);

            panelRectTransform.anchoredPosition = new Vector2(0, 0);
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void LateUpdate(PlayerControllerB __instance)
        {
            Camera camera = __instance.gameplayCamera;
            camera.fieldOfView = __instance.targetFOV*1.33f;
        }
    }
}
