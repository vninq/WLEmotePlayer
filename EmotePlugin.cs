using lstwoMODS_Core.Hacks;
using lstwoMODS_Core.UI.TabMenus;
using lstwoMODS_WobblyLife.Mods;
using ModWobblyLife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EmotePlayer
{
    public class EmotePlugin : PlayerBasedMod
    {
        //public EmoteTypee selectEmote;
        private static string[] emots = ["Happy", "Crying", "Angry", "Heart", "Thanks", "Well Done", "Follow Me", "Sorry", "Need Help", "Bye", "Clap", "Double Wave", "Dance", "Wave", "Thumbs Up", "Laugh", "Thumbs Down", "Grumpy"];
        public override string Name => "Emote Player";
        /*private readonly string[] emoteNames = new []
{
    "Happy", "Crying", "Angry", "Heart", "Thanks", "Well Done",
    "Follow Me", "Sorry", "Need Help", "Bye", "Clap",
    "Double Wave", "Dance", "Wave", "Thumbs Up"
};
*/
        public override string Description => "Play any emote";

        public override ModsWindow ModsWindow => lstwoMODS_WobblyLife.Plugin.PlayerModsWindow;

        /*[ModAction]
        public void Play(EmoteTypee selectedEmote)
        {
            switch (selectedEmote)
            {
                case EmoteTypee.Angry:
                    PlayEmotee(selectedEmote);
                    break;
                default:
                    throw new Exception("Invalid arg");
            }
        }*/
        [ModAction(Label = "Play For Selected")]
        public void PlayEmotee(EmoteTypee typee)
        {
            Player?.Character?.PlayEmote(typee.ToString());
        }

        [ModAction(Label = "Play For Everyone")]
        public void PlaForEvery(EmoteTypee typee)
        {
            foreach (var character in GameInstance.Instance.GetPlayerCharacters())
            {
                character .PlayEmote(typee.ToString());
            }
        }

        // );
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
            Laughing,
            Thumbs_Down,
            Grumpy

        }
    }
}
