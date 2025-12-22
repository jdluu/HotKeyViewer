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
        
        void AddSectionTitle(IManifest mod, Func<string> text, Func<string>? tooltip = null);
        
        void AddParagraph(IManifest mod, Func<string> text);
        
        void AddTextOption(IManifest mod, Func<string> getValue, Action<string> setValue, Func<string> name, Func<string>? tooltip = null, string[]? allowedValues = null, Func<string, string>? formatAllowedValue = null, string? fieldId = null);
    }
}
