using BepInEx;
using System;
using UnityEngine;
using UniverseLib.Config;
using UniverseLib.UI;

namespace WLEmotePlayer
{
    [BepInPlugin("EmotePlayer", "emoteplayer", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static UIBase UIBase { get; private set; }
        public static MainPanel MainPanel { get; private set; }
        public static Plugin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            UniverseLibConfig config = new UniverseLibConfig()
            {
                Force_Unlock_Mouse = true
            };

            UniverseLib.Universe.Init(1f, OnUIInitialized, (x, y) => { }, config);

            Logger.LogInfo("Plugin EmotePlayer is loaded!");
        }


        private static void OnUIInitialized()
        {
            UIBase = UniversalUI.RegisterUI("vninq.emoteplayer", UIUpdate);

            MainPanel = new MainPanel(UIBase);

            UIBase.Enabled = false;
        }

        public static void UIUpdate()
        {

        }

        public static void SetUIEnabled(bool enabled)
        {
            if (UIBase == null) throw new ArgumentNullException(nameof(UIBase));
            UIBase.Enabled = enabled;
            if (MainPanel == null) throw new ArgumentNullException(nameof(UIBase));
            MainPanel._SetActive(enabled);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                SetUIEnabled(!UIBase.Enabled);
            }
        }

    }
}
