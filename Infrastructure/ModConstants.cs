namespace HotKeyViewer.Infrastructure
{
    public static class ModConstants
    {
        // Asset Paths (Local files)
        public const string AssetsDir = "assets";
        public const string ViewsDir = "assets/views";
        public const string OverlayViewPath = "assets/views/KeyboardOverlay.sml";
        public const string WhitePixelPath = "assets/white.png";

        // Asset Keys (Game Content Pipeline)
        // These are suffixes; the prefix is usually Mods/{UniqueID}/
        public const string OverlayViewKey = "Views/KeyboardOverlay";
        public const string WhitePixelKey = "assets/white.png"; // Stays in assets root in pipeline

        // External Mod IDs
        public const string StardewUiId = "focustense.StardewUI";
        public const string GmcmId = "spacechase0.GenericModConfigMenu";
    }
}
