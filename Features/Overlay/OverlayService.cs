using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewUI.Framework;
using StardewValley;
using System;
using HotKeyViewer.Infrastructure;

namespace HotKeyViewer.Features.Overlay
{
    public class OverlayService : IDisposable
    {
        private readonly IModHelper _helper;
        private readonly IViewEngine _viewEngine;
        private readonly ModConfig _config;
        private readonly KeyboardViewModel _viewModel;
        private readonly string _viewsPath;

        private string? _cachedMarkup;
        private IMenuController? _activeMenuController;

        public OverlayService(
            IModHelper helper, 
            IViewEngine viewEngine, 
            ModConfig config, 
            KeyboardViewModel viewModel,
            string viewsPath)
        {
            _helper = helper;
            _viewEngine = viewEngine;
            _config = config;
            _viewModel = viewModel;
            _viewsPath = viewsPath;

            _helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsPlayerFree) return;

            if (e.Button == _config.ToggleKey)
            {
                ToggleMenu();
            }
        }

        public void ToggleMenu()
        {
            // Safety: Check if our menu was replaced externally (e.g. by another mod or game event)
            if (_activeMenuController != null && Game1.activeClickableMenu != _activeMenuController.Menu)
            {
                _activeMenuController = null;
            }

            if (_activeMenuController != null)
            {
                _activeMenuController.Close();
                _activeMenuController = null;
            }
            else
            {
                try 
                {
                    if (_cachedMarkup == null)
                    {
                        // Read SML directly from file to bypass asset system issues
                        string smlPath = System.IO.Path.Combine(_helper.DirectoryPath, _viewsPath);
                        if (!System.IO.File.Exists(smlPath))
                        {
                            // Fallback or error log
                            return;
                        }
                        _cachedMarkup = System.IO.File.ReadAllText(smlPath);
                    }

                    _activeMenuController = _viewEngine.CreateMenuControllerFromMarkup(_cachedMarkup, _viewModel);
                    
                    // Cleanup on close
                    _activeMenuController.Closed += () => 
                    {
                        if (_activeMenuController?.Menu == Game1.activeClickableMenu)
                            _activeMenuController = null;
                    };
                    
                    Game1.activeClickableMenu = _activeMenuController.Menu;
                }
                catch (Exception)
                {
                    // Log error safely if possible, or just fail silently to avoid crashing game
                    _activeMenuController = null;
                }
            }
        }

        public void Dispose()
        {
            _helper.Events.Input.ButtonPressed -= OnButtonPressed;
        }
    }
}
