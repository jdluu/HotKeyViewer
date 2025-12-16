using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewUI.Framework;
using StardewValley;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HotKeyViewer
{
    internal sealed class ModEntry : Mod
    {
        private IViewEngine _viewEngine = null!;
        private IMenuController? _activeMenuController = null;
        private KeyboardViewModel _viewModel = new();
        private ModConfig _config = null!;

        public override void Entry(IModHelper helper)
        {
            _config = helper.ReadConfig<ModConfig>();

            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            _viewEngine = Helper.ModRegistry.GetApi<IViewEngine>("focustense.StardewUI")
                ?? throw new InvalidOperationException("StardewUI not found");

            // Register GMCM
            var configMenu = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu != null)
            {
                configMenu.Register(
                    ModManifest,
                    reset: () => _config = new ModConfig(),
                    save: () => Helper.WriteConfig(_config)
                );

                configMenu.AddKeybind(
                    ModManifest,
                    name: () => "Toggle Overlay",
                    tooltip: () => "Press this key to toggle the keyboard overlay.",
                    getValue: () => _config.ToggleKey,
                    setValue: value => _config.ToggleKey = value
                );
            }

            // Register the views directory (assets/views)
            _viewEngine.RegisterViews($"Mods/{ModManifest.UniqueID}/Views", "assets/views");

            // Enable hot reloading for development
            _viewEngine.EnableHotReloadingWithSourceSync();
        }

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsPlayerFree) return;

            if (e.Button == _config.ToggleKey)
            {
                ToggleMenu();
            }
        }

        private void ToggleMenu()
        {
            if (_activeMenuController != null)
            {
                _activeMenuController.Close();
                _activeMenuController = null;
            }
            else
            {
                _activeMenuController = _viewEngine.CreateMenuControllerFromAsset($"Mods/{ModManifest.UniqueID}/Views/KeyboardOverlay", _viewModel);
                
                // Cleanup on close
                _activeMenuController.Closed += () => _activeMenuController = null;
                
                Game1.activeClickableMenu = _activeMenuController.Menu;
            }
        }
    }
}
