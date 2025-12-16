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
        private IViewDrawable? _overlay = null!;
        private KeyboardViewModel _viewModel = new();
        private ModConfig _config = null!;

        public override void Entry(IModHelper helper)
        {
            _config = helper.ReadConfig<ModConfig>();

            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.Input.ButtonPressed += OnButtonPressed;
            helper.Events.Display.RenderedHud += OnRenderedHud;
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

            // Create the drawable
            _overlay = _viewEngine.CreateDrawableFromAsset($"Mods/{ModManifest.UniqueID}/Views/KeyboardOverlay");
            _overlay.Context = _viewModel;
        }

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsPlayerFree) return;

            if (e.Button == _config.ToggleKey)
            {
                _viewModel.IsVisible = !_viewModel.IsVisible;
            }
        }

        private void OnRenderedHud(object? sender, RenderedHudEventArgs e)
        {
            if (_overlay != null && _viewModel.IsVisible)
            {
                // Draw centered
                var viewport = Game1.uiViewport;
                // Measure logic if needed, but IViewDrawable handles layout inside its bounds.
                // We'll give it the full screen size
                _overlay.MaxSize = new Vector2(viewport.Width, viewport.Height);
                _overlay.Draw(e.SpriteBatch, Vector2.Zero);
            }
        }
    }
}
