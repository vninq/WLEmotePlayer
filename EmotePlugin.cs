using lstwoMODS_Core.Hacks;
using lstwoMODS_Core.UI.TabMenus;
using lstwoMODS_WobblyLife.Mods;
using System;
using UnityEngine;

namespace EmotePlayer
{
    public class EmotePlugin : PlayerBasedMod
    {
        public override string Name => "Emote Player";

        public override string Description => "Play any emote";

        public override ModsWindow ModsWindow => lstwoMODS_WobblyLife.Plugin.PlayerModsWindow;

        [ModAction(Label = "Play")]
        public void PlayEmotee(EmoteTypee type)
        {
            var emote = type.ToString().Replace("_", " ");
            Player?.Character?.PlayEmote(emote);
        }

        [ModAction(Label = "Play For Everyone")]
        public void PlaForEvery(EmoteTypee type)
        {
            foreach (var character in GameInstance.Instance.GetPlayerCharacters())
            {
                var emote = type.ToString().Replace("_", " ");
                character.PlayEmote(emote);
            }
        }

        public enum EmoteTypee
        {
            Happy,
            Crying,
            Angry,
            Heart,
            Thanks,
            Well_Done,
            Follow_Me,
            Sorry,
            Need_Help,
            Bye,
            Clap,
            Double_Wave,
            Wave,
            Dance,
            Thumbs_Up,
            Laugh,
            Thumbs_Down,
            Grumpy
        }
    }
}
