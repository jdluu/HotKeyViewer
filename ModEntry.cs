using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewUI.Framework;
using HotKeyViewer.Infrastructure;
using HotKeyViewer.Services;
using HotKeyViewer.Features.Overlay;

namespace HotKeyViewer
{
    internal sealed class ModEntry : Mod
    {
        private ModConfig _config = null!;
        
        // Services
        private AssetManager _assetManager = null!;
        private GmcmIntegration _gmcmIntegration = null!;
        private IViewEngine _viewEngine = null!;
        private GameState _gameState = null!;
        private KeybindingService _keybindingService = null!;
        private ProfileService _profileService = null!;
        private KeyboardViewModel _viewModel = null!;
        private OverlayService _overlayService = null!;

        public override void Entry(IModHelper helper)
        {
            _config = helper.ReadConfig<ModConfig>();

            // Pass 1: Extract Asset Logic
            _assetManager = new AssetManager(helper, ModManifest);

            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        }

        private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            _viewEngine = Helper.ModRegistry.GetApi<IViewEngine>(ModConstants.StardewUiId)
                ?? throw new InvalidOperationException("StardewUI not found");

            // 1. Register the views and sprites directory BEFORE enabling other features
            _viewEngine.RegisterViews(AssetPathHelper.GetAssetKey(ModManifest, "Views"), ModConstants.ViewsDir);
            _viewEngine.RegisterSprites(AssetPathHelper.GetAssetKey(ModManifest, "assets"), ModConstants.AssetsDir);

            // 2. Initialize dependencies
            _gameState = new GameState();
            _keybindingService = new KeybindingService(_gameState);
            _profileService = new ProfileService(Helper, Monitor);
            _viewModel = new KeyboardViewModel(_keybindingService, _profileService);

            // 3. Initialize Feature Services with relative file path
            _overlayService = new OverlayService(Helper, _viewEngine, _config, _viewModel, ModConstants.OverlayViewPath);

            // 4. Register GMCM
            _gmcmIntegration = new GmcmIntegration(
                Helper,
                ModManifest,
                _profileService,
                getConfig: () => _config,
                setConfig: (newConfig) => _config = newConfig
            );
            _gmcmIntegration.Register();

            // 5. Enable hot reloading for development
            _viewEngine.EnableHotReloadingWithSourceSync();
        }
    }
}
