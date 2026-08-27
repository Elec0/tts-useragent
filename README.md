# Tabletop Simulator Custom UserAgent
Custom UserAgent for Tabletop SImulator

Download from releases: https://github.com/Elec0/tts-useragent/releases

# Installing
1. Install MelonLoader: https://melonwiki.xyz/#/?id=requirements
2. Pick version `0.7.3`
3. Once installed, navigate to your TabletopSimulator install location
4. **IMPORTANT** If `version.dll` is present, rename it to `winhttp.dll`
   * If you don't: MelonLoader isn't going to load and you won't see the console pop up
5. Put `TTS-UserAgentMod.dll` inside `Tabletop Simulator/Mods/`
6. Run TTS

# Configuring
You should change your UserAgent to be correct for your system and usecase.

In `Tabletop Simulator/UserData/MelonPreferences.cfg`, you should see this entry
```ini
[TTSUserAgentChanger]
UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36"
```

# Building
* Class Library (.NET Framework)
* .NET Framework v4.8
* Add references
  * `Tabletop Simulator\MelonLoader\net472\0Harmony.dll`
  * `Tabletop Simulator\MelonLoader\net472\MelonLoader.dll`
  * `Tabletop Simulator\Tabletop Simulator_Data\Managed\UnityEngine.dll`
  * `Tabletop Simulator\Tabletop Simulator_Data\Managed\UnityEngine.UnityWebRequestModule.dll`
