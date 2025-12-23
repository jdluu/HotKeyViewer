using System;
using StardewModdingAPI;
using HotKeyViewer.Infrastructure;

namespace HotKeyViewer.Services
{
    internal class GmcmIntegration
    {
        private readonly IModHelper _helper;
        private readonly IModManifest _manifest;
        private readonly ProfileService _profileService;
        private readonly Func<ModConfig> _getConfig;
        private readonly Action<ModConfig> _setConfig;

        public GmcmIntegration(
            IModHelper helper,
            IModManifest manifest,
            ProfileService profileService,
            Func<ModConfig> getConfig,
            Action<ModConfig> setConfig)
        {
            _helper = helper;
            _manifest = manifest;
            _profileService = profileService;
            _getConfig = getConfig;
            _setConfig = setConfig;
        }

        public void Register()
        {
            var configMenu = _helper.ModRegistry.GetApi<IGenericModConfigMenuApi>(ModConstants.GmcmId);
            if (configMenu == null) return;

            configMenu.Register(
                _manifest,
                reset: () => _setConfig(new ModConfig()),
                save: () =>
                {
                    var config = _getConfig();
                    _helper.WriteConfig(config);
                    _profileService.SaveCurrentProfile();
                }
            );

            // --- General Settings ---
            configMenu.AddSectionTitle(_manifest, () => "General");

            configMenu.AddKeybind(
                _manifest,
                name: () => "Toggle Overlay",
                tooltip: () => "Press this key to toggle the keyboard overlay.",
                getValue: () => _getConfig().ToggleKey,
                setValue: value => _getConfig().ToggleKey = value
            );

            // --- Profile Selection ---
            configMenu.AddSectionTitle(_manifest, () => "Profile");

            configMenu.AddTextOption(
                _manifest,
                name: () => "Current Profile",
                tooltip: () => "Name of the active key label profile.",
                getValue: () => _profileService.CurrentProfileName,
                setValue: name => _profileService.LoadProfile(name)
            );
        }
    }
}
