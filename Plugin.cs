using BepInEx;
using System;
using UnityEngine;
using UniverseLib.Config;
using UniverseLib.UI;

namespace EmotePlayer
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VRESION)]
    public class Plugin : BaseUnityPlugin
    {
        public static UIBase? UIBase { get; private set; }
        public static EmoteUiPanel? EmoteUiPanel { get; private set; }
        private void Awake()
        {

            UniverseLibConfig config = new()
            {
                Force_Unlock_Mouse = true
            };

            UniverseLib.Universe.Init(1f, OnUIInitialized, (x, y) => { }, config);
        }

        private static void OnUIInitialized()
        {
            UIBase = UniversalUI.RegisterUI($"{PluginInfo.PLUGIN_GUID}" , UpdateUi);
            EmoteUiPanel = new EmoteUiPanel(UIBase);
            UIBase.Enabled = false;
        }

        private static void UpdateUi()
        {

        }

        public static void SetEnabled(bool enabled)
        {
            if (UIBase == null) throw new ArgumentNullException(nameof(UIBase));
            UIBase.Enabled = enabled;
            if (EmoteUiPanel == null) throw new ArgumentNullException(nameof(UIBase));
            EmoteUiPanel.SetUiActive(enabled);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                SetEnabled(!UIBase.Enabled);
            }
        }
    }
}
