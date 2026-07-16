using ShadowLib;
using System;
using UnityEngine;
using UniverseLib.UI;

namespace WLEmotePlayer
{
    public class MainPanel : UniverseLib.UI.Panels.PanelBase
    {
        //emots
        public string emoteHappy = "Happy";
        public string emoteSad = "Crying";
        public string emoteAngry = "Angry";
        public string emoteHeart = "Heart";
        public MainPanel(UIBase owner) : base(owner) { }
        public override string Name => "Emote Player";
        public override int MinWidth => 500;
        public override int MinHeight => 600;
        public override Vector2 DefaultAnchorMin => new Vector2(0.5f, 0.5f);
        public override Vector2 DefaultAnchorMax => new Vector2(0.5f, 0.5f);
        public override Vector2 DefaultPosition => new Vector2((float)(-(float)MinWidth / 2), (MinHeight / 2));
        public override bool CanDragAndResize => true;

        public static PlayerCharacter GetMyCharacter()
        {
            if (UnitySingleton<GameInstance>.Instance.GetGamemode() == null)
            {
                return null;
            }
            else
            {
                foreach (PlayerCharacter playerCharacter in UnitySingleton<GameInstance>.Instance.GetPlayerCharacters())
                {
                    if (playerCharacter.networkObject.IsOwner())
                    {
                        return playerCharacter;
                    }
                }
                return null;
            }
        }

        // ui stuff
        protected override void ConstructPanelContent()
        {
            var ui = new UIHelper(ContentRoot);

            ui.AddSpacer(5);
            ui.CreateLabel("Playable Emotes");
            ui.AddSpacer(6);
            ui.CreateButton("Happy", () => PlayEmoteHappy(), "playEmoteB");
            ui.AddSpacer(3);
            ui.CreateButton("Angry", () => PlayEmoteAngry(), "playEmoteB");
            ui.AddSpacer(3);
            ui.CreateButton("Sad", () => PlayEmoteSad(), "playEmoteB");
            ui.AddSpacer(3);
            ui.CreateButton("Heart", () => PlayEmoteHeart(), "playEmoteB");
        }

        public void PlayEmoteAngry()
        {
            var playerCharacter = GetMyCharacter();
            if (playerCharacter != null)
            {
                playerCharacter.PlayEmote(emoteAngry);
            }

        }

        public void PlayEmoteHappy()
        {
            var playerCharacter = GetMyCharacter();
            if (playerCharacter != null)
            {
                playerCharacter.PlayEmote(emoteHappy);
            }
        }

        public void PlayEmoteSad()
        {
            var playerCharacter = GetMyCharacter();
            if (playerCharacter != null)
            {
                playerCharacter.PlayEmote(emoteSad);
            }
        }

        public void PlayEmoteHeart()
        {
            var playerCharacter = GetMyCharacter();
            if (playerCharacter != null)
            {
                playerCharacter.PlayEmote(emoteHeart);
            }
        }

        public void _SetActive(bool b)
        {
            SetActive(b);
        }

        protected override void OnClosePanelClicked()
        {
            Plugin.SetUIEnabled(false);
        }

    }
}
