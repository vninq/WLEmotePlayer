using ShadowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniverseLib.UI;
using UniverseLib.UI.Models;
using UniverseLib.UI.Panels;

namespace EmotePlayer
{
    public class EmoteUiPanel : PanelBase
    {
        public EmoteUiPanel(UIBase owner) : base(owner){ }

        private static string[] eomts = [ "Happy", "Crying", "Angry", "Heart", "Thanks", "Well Done", "Follow Me", "Sorry", "Need Help", "Bye", "Clap", "Double Wave", "Dance", "Wave", "Thumbs Up", "Laugh", "Thumbs Down", "Grumpy" ];
        private int playerIndex = 0; //a player dropdown for later
        private int emoteIndex = 0;

        public override string Name => "Emote Player"
            ;
        public override int MinWidth => 400;

        public override int MinHeight => 500;

        public override Vector2 DefaultAnchorMin => new(0.25f, 0.25f);
        public override Vector2 DefaultAnchorMax => new(0.25f, 0.25f);
        public override bool CanDragAndResize => true;
        public override Vector2 DefaultPosition => new(MinWidth / 2, MinHeight / 2);

        // ui tings
        protected override void ConstructPanelContent() { var ui = new UIHelper(ContentRoot); ui.CreateLabel("Select a Emote"); ui.AddSpacer(6); var optionList = new List<Dropdown.OptionData>(); foreach (string emoteName in eomts) { optionList.Add(new Dropdown.OptionData(emoteName)); } ui.CreateDropdown("emote", (selected) => { emoteIndex = selected; }, "Happy").AddOptions(optionList); ui.AddSpacer(6); ui.CreateButton("Play For you", () => { Play(); }/*color: Color.yellow*/); ui.AddSpacer(6); ui.CreateButton("Play For Everyone", () => PlayFor()); } /* idk kind of bright }*//*var optionList1 = new List<Dropdown.OptionData>(); foreach (var player in players) {string playerName = player.name; ui.CreateDropdown("players", (selected) =>}, "Select Player").AddOptions(optionList1); next update will have to see*/ public void SetUiActive(bool b) {SetActive(b); } private void Play() {var player = PlayerUtils.GetMyPlayer(); string emote = eomts[emoteIndex]; player.GetPlayerCharacter().PlayEmote(emote);} private void PlayFor() {string emote = eomts[emoteIndex]; foreach (var player in GameInstance.Instance.GetPlayerCharacters()) player?.PlayEmote(emote);} protected override void OnClosePanelClicked() { Plugin.SetEnabled(false); }

    }
}
