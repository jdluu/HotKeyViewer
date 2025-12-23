using StardewModdingAPI;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework.Graphics;
using HotKeyViewer.Infrastructure;

namespace HotKeyViewer.Services
{
    internal class AssetManager
    {
        private readonly IModManifest _manifest;

        public AssetManager(IModHelper helper, IModManifest manifest)
        {
            _manifest = manifest;
            helper.Events.Content.AssetRequested += OnAssetRequested;
        }

        private void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale?.IsEquivalentTo(AssetPathHelper.GetAssetKey(_manifest, ModConstants.OverlayViewKey)) == true)
            {
                e.LoadFromModFile<string>(ModConstants.OverlayViewPath, AssetLoadPriority.Medium);
            }
            else if (e.NameWithoutLocale?.IsEquivalentTo(AssetPathHelper.GetAssetKey(_manifest, ModConstants.WhitePixelKey)) == true)
            {
                e.LoadFromModFile<Texture2D>(ModConstants.WhitePixelPath, AssetLoadPriority.Medium);
            }
        }
    }
}
