# Emote-Player

its kanda uselsses but its good for spammnig people with emotes  `f4` to open it.

# build it yourself 

just if you want to add something

```bash
dotnet build -c Release
```
> [!NOTE]
> cross play update will break the mod.

because on the EOS build every ``MonoBehaviour`` sitting in the DDOL (DontDestroyOnLoad) scene on frame 0 (including bepInExs plugin object) gets moved into an empty bootstrap scene and destroyed before ``Start()`` evenruns so the plugin never reached ``Start()`` or ``Update()`` so setting the
```C#
HideManagerGameObject = true 
```
in the ``BepInEx.cfg`` will fix it

The mod requires
[ShadowLib](https://github.com/lstwo/ShadowLib/releases)

join my discord if you have any mod ideas (https://discord.gg/U8uS8dpfN)

put the EmotePlayer.dll in ``plugins``

<img width="783" height="436" alt="Screenshot 2026-08-13 120315" src="https://github.com/user-attachments/assets/e2922f39-ab3b-4e47-8e90-d6afa9a0e5f5" />


im probbably gonna discontinue this sense im adding it to lstwomods idk when 

last update but i have added a dropdown and all emots
have fun(;
