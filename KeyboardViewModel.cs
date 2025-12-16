using StardewModdingAPI;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewModdingAPI.Utilities;

namespace HotKeyViewer
{
    public class KeyboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public List<Keybind> Row1 { get; } = new()
        {
            new(SButton.D1), new(SButton.D2), new(SButton.D3), new(SButton.D4), new(SButton.D5)
        };

        public List<Keybind> Row2 { get; } = new()
        {
            new(SButton.Q), new(SButton.W), new(SButton.E), new(SButton.R), new(SButton.T), new(SButton.Y)
        };

        public List<Keybind> Row3 { get; } = new()
        {
            new(SButton.A), new(SButton.S), new(SButton.D), new(SButton.F), new(SButton.G), new(SButton.H)
        };

        // Helper to trigger property changes
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // This could be extended to return key states (pressed, bound command, etc.)
        public Color GetKeyColor(string keyName)
        {
            // Placeholder: Return specific color if key is bound, else default
            return Color.White;
        }
    }
}
