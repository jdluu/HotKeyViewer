using StardewModdingAPI;
namespace HotKeyViewer.Infrastructure
{
    public static class AssetPathHelper
    {
        /// <summary>
        /// Generates a fully qualified asset key for the content pipeline (e.g., "Mods/MyMod.UI/Views/KeyboardOverlay").
        /// </summary>
        public static string GetAssetKey(IManifest manifest, string assetName)
        {
            return $"Mods/{manifest.UniqueID}/{assetName}";
        }

        /// <summary>
        /// Generates the base prefix for asset keys (e.g., "Mods/MyMod.UI").
        /// </summary>
        public static string GetAssetPrefix(IManifest manifest)
        {
            return $"Mods/{manifest.UniqueID}";
        }
    }
}
