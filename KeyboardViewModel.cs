using StardewModdingAPI;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using StardewValley;

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
