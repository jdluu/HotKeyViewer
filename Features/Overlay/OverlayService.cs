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
            if (_activeMenuController != null)
            {
                _activeMenuController.Close();
                _activeMenuController = null;
            }
            else
            {
                _activeMenuController = _viewEngine.CreateMenuControllerFromAsset(_viewsPath, _viewModel);
                
                // Cleanup on close
                _activeMenuController.Closed += () => _activeMenuController = null;
                
                Game1.activeClickableMenu = _activeMenuController.Menu;
            }
        }

        public void Dispose()
        {
            _helper.Events.Input.ButtonPressed -= OnButtonPressed;
        }
    }
}
