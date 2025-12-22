namespace HotKeyViewer.Models
{
    /// <summary>
    /// Represents a user's custom key label configuration.
    /// </summary>
    public class KeyProfile
    {
        /// <summary>
        /// The display name of this profile (also used as filename).
        /// </summary>
        public string ProfileName { get; set; } = "Default";

        /// <summary>
        /// Optional author attribution for shared profiles.
        /// </summary>
        public string Author { get; set; } = "";

        /// <summary>
        /// Custom labels for each key. Key = SButton name (e.g., "F", "D1"), Value = custom label text.
        /// Empty string means use default action label.
        /// </summary>
        public Dictionary<string, string> KeyLabels { get; set; } = new();
    }
}
