using System.Text.Json;
using StardewModdingAPI;
using HotKeyViewer.Models;

namespace HotKeyViewer.Services
{
    /// <summary>
    /// Manages custom key label profiles - load, save, and query operations.
    /// </summary>
    public class ProfileService
    {
        private readonly IModHelper _helper;
        private readonly IMonitor _monitor;
        private readonly string _profilesPath;
        
        private KeyProfile _currentProfile;

        public string CurrentProfileName => _currentProfile.ProfileName;
        public string CurrentAuthor => _currentProfile.Author;

        public ProfileService(IModHelper helper, IMonitor monitor)
        {
            _helper = helper;
            _monitor = monitor;
            
            // Use SMAPI's data folder to avoid StardewUI hot-reload watcher issues
            // This stores profiles in %AppData%/StardewValley/Mods/HotKeyViewer/ (separate from mod files)
            string dataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "StardewValley", "Mods", "HotKeyViewer"
            );
            _profilesPath = Path.Combine(dataPath, "profiles");
            
            // Ensure profiles directory exists
            if (!Directory.Exists(_profilesPath))
            {
                Directory.CreateDirectory(_profilesPath);
            }
            
            // Load default profile or create empty one
            _currentProfile = LoadProfile("Default") ?? CreateDefaultProfile();
        }

        /// <summary>
        /// Get the custom label for a key, or empty string if not set.
        /// </summary>
        public string GetLabel(SButton key)
        {
            string keyName = key.ToString();
            return _currentProfile.KeyLabels.TryGetValue(keyName, out string? label) ? label : "";
        }

        /// <summary>
        /// Set a custom label for a key.
        /// </summary>
        public void SetLabel(SButton key, string label)
        {
            string keyName = key.ToString();
            if (string.IsNullOrWhiteSpace(label))
            {
                _currentProfile.KeyLabels.Remove(keyName);
            }
            else
            {
                _currentProfile.KeyLabels[keyName] = label;
            }
        }

        /// <summary>
        /// Get list of available profile names.
        /// </summary>
        public List<string> GetAvailableProfiles()
        {
            var profiles = new List<string>();
            
            if (!Directory.Exists(_profilesPath))
                return profiles;
                
            foreach (var file in Directory.GetFiles(_profilesPath, "*.json"))
            {
                profiles.Add(Path.GetFileNameWithoutExtension(file));
            }
            
            return profiles;
        }

        /// <summary>
        /// Load a profile by name.
        /// </summary>
        public KeyProfile? LoadProfile(string name)
        {
            string filePath = Path.Combine(_profilesPath, $"{name}.json");
            
            if (!File.Exists(filePath))
            {
                _monitor.Log($"Profile '{name}' not found at {filePath}", LogLevel.Debug);
                return null;
            }
            
            try
            {
                string json = File.ReadAllText(filePath);
                var profile = JsonSerializer.Deserialize<KeyProfile>(json);
                
                if (profile != null)
                {
                    _currentProfile = profile;
                    _monitor.Log($"Loaded profile: {name}", LogLevel.Info);
                }
                
                return profile;
            }
            catch (Exception ex)
            {
                _monitor.Log($"Error loading profile '{name}': {ex.Message}", LogLevel.Error);
                return null;
            }
        }

        /// <summary>
        /// Save the current profile.
        /// </summary>
        public void SaveCurrentProfile()
        {
            SaveProfile(_currentProfile);
        }

        /// <summary>
        /// Save a profile to disk.
        /// </summary>
        public void SaveProfile(KeyProfile profile)
        {
            string filePath = Path.Combine(_profilesPath, $"{profile.ProfileName}.json");
            
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(profile, options);
                File.WriteAllText(filePath, json);
                _monitor.Log($"Saved profile: {profile.ProfileName}", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _monitor.Log($"Error saving profile '{profile.ProfileName}': {ex.Message}", LogLevel.Error);
            }
        }

        /// <summary>
        /// Create a new empty profile with a given name.
        /// </summary>
        public void CreateNewProfile(string name, string author = "")
        {
            _currentProfile = new KeyProfile
            {
                ProfileName = name,
                Author = author,
                KeyLabels = new Dictionary<string, string>()
            };
            SaveCurrentProfile();
        }

        private KeyProfile CreateDefaultProfile()
        {
            var profile = new KeyProfile
            {
                ProfileName = "Default",
                Author = "",
                KeyLabels = new Dictionary<string, string>()
            };
            SaveProfile(profile);
            return profile;
        }
    }
}
