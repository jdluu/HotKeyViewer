using System;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace HotKeyViewer
{
    /// <summary>The API provided by the Generic Mod Config Menu mod.</summary>
    public interface IGenericModConfigMenuApi
    {
        void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);
        void AddKeybind(IManifest mod, Func<SButton> getValue, Action<SButton> setValue, Func<string> name, Func<string>? tooltip = null, string? fieldId = null);
    }
}
