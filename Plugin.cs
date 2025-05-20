using BepInEx;
using System;
using UnityEngine;

namespace iiMenu
{
    [System.ComponentModel.Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Set console title
            Console.Title = "Roman Menu // Build " + PluginInfo.Version;
        }

        private void Start()
        {
            LoadMenu();
        }

        // For SharpMonoInjector usage
        private static void LoadMenu()
        {
            Console.Title = "Roman Menu // Build " + PluginInfo.Version;

            Patches.Menu.ApplyHarmonyPatches();

            GameObject Loader = new GameObject("iiMenu_Loader");
            Loader.AddComponent<UI.Main>();
            Loader.AddComponent<Notifications.NotifiLib>();
            Loader.AddComponent<Classes.CoroutineManager>();

            DontDestroyOnLoad(Loader);
        }
    }
}
