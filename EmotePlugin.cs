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
        public override string Name => "Emote Player";

        public override string Description => "Play any emote";

        public override ModsWindow ModsWindow => lstwoMODS_WobblyLife.Plugin.PlayerModsWindow;


        [ModAction(Label = "Play For Selected")]
        public void PlayEmotee(EmoteType typee)
        {
            Player?.Character?.PlayEmote(typee.ToString());
        }

        [ModAction(Label = "Play For Everyone")]
        public void PlaForEvery(EmoteType typee)
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
