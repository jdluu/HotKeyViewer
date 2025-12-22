using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewUI.Framework;
using StardewValley;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HotKeyViewer.Infrastructure;
using HotKeyViewer.Services;
using HotKeyViewer.Features.Overlay;

namespace HotKeyViewer
{
    internal sealed class ModEntry : Mod
    {
        private IViewEngine _viewEngine = null!;
        private ModConfig _config = null!;
        private GameState _gameState = null!;
        private KeybindingService _keybindingService = null!;
        private KeyboardViewModel _viewModel = null!;
        private OverlayService _overlayService = null!;

        public override void Entry(IModHelper helper)
        {
            _config = helper.ReadConfig<ModConfig>();

            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.Content.AssetRequested += OnAssetRequested;
        }

        private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            _viewEngine = Helper.ModRegistry.GetApi<IViewEngine>("focustense.StardewUI")
                ?? throw new InvalidOperationException("StardewUI not found");

            // 1. Register the views and sprites directory BEFORE enabling other features
            _viewEngine.RegisterViews($"Mods/{ModManifest.UniqueID}/Views", "assets/views");
            _viewEngine.RegisterSprites($"Mods/{ModManifest.UniqueID}/assets", "assets");

            // 2. Initialize dependencies
            _gameState = new GameState();
            _keybindingService = new KeybindingService(_gameState);
            _viewModel = new KeyboardViewModel(_keybindingService);

            // 3. Initialize Feature Services with relative file path
            string layoutViewPath = "assets/views/KeyboardOverlay.sml";
            _overlayService = new OverlayService(Helper, _viewEngine, _config, _viewModel, layoutViewPath);

            // 4. Register GMCM
            RegisterGmcm();

            // 5. Enable hot reloading for development
            _viewEngine.EnableHotReloadingWithSourceSync();
        }

        private void RegisterGmcm()
        {
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
        }

        private void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale?.IsEquivalentTo($"Mods/{ModManifest.UniqueID}/Views/KeyboardOverlay") == true)
            {
                e.LoadFromModFile<string>("assets/views/KeyboardOverlay.sml", AssetLoadPriority.Medium);
            }
            else if (e.NameWithoutLocale?.IsEquivalentTo($"Mods/{ModManifest.UniqueID}/assets/white") == true)
            {
                e.LoadFromModFile<Texture2D>("assets/white.png", AssetLoadPriority.Medium);
            }
        }
    }
}
