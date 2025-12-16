using StardewModdingAPI;

namespace HotKeyViewer
{
    public class ModConfig
    {
        public SButton ToggleKey { get; set; } = SButton.F1;

        // Future config for colors, etc.
        public string KeyMap { get; set; } = "Default";
    }
}
