
using StardewModdingAPI;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Utilities;
using HotKeyViewer.Services;
using System.Collections.ObjectModel;

namespace HotKeyViewer
{
    // Class to hold key binding, label, and custom dimensions
    public class KeyDisplay
    {
        public SButton Key { get; }
        public Keybind Keybind { get; }
        public string FaceText { get; }
        public string Label { get; }
        public string Width { get; } = "80px";
        public string Height { get; } = "80px";
        public string Tint { get; } = "#FFFFFF";

        private readonly Action<SButton> _onClick;

        public string LayoutSize => $"{Width} {Height}";

        public KeyDisplay(SButton key, Keybind keybind, string faceText, string label, Action<SButton> onClick, string width = "80px", string height = "80px", string tint = "#FFFFFF")
        {
            Key = key;
            Keybind = keybind;
            FaceText = faceText;
            Label = label;
            _onClick = onClick;
            Width = width;
            Height = height;
            Tint = tint;
        }

        public void Click()
        {
            _onClick?.Invoke(Key);
        }
    }

    public class KeyboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly KeybindingService _keybindingService;
        private readonly ProfileService? _profileService;

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
                    if (value) RefreshBindings();
                }
            }
        }

        // --- Edit Mode State ---
        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    OnPropertyChanged(nameof(IsEditing));
                }
            }
        }

        private SButton _editingKey;
        public SButton EditingKey
        {
            get => _editingKey;
            set
            {
                if (_editingKey != value)
                {
                    _editingKey = value;
                    OnPropertyChanged(nameof(EditingKey));
                    OnPropertyChanged(nameof(EditingKeyName));
                }
            }
        }

        public string EditingKeyName => _editingKey.ToString();

        private string _editText = "";
        public string EditText
        {
            get => _editText;
            set
            {
                if (_editText != value)
                {
                    _editText = value;
                    OnPropertyChanged(nameof(EditText));
                }
            }
        }

        // Main Block
        public ObservableCollection<KeyDisplay> FunctionRow { get; } = new(); // Esc, F1-F12
        public ObservableCollection<KeyDisplay> NumberRow { get; } = new();
        public ObservableCollection<KeyDisplay> TopRow { get; } = new();
        public ObservableCollection<KeyDisplay> HomeRow { get; } = new();
        public ObservableCollection<KeyDisplay> BottomRow { get; } = new();
        public ObservableCollection<KeyDisplay> SpaceRow { get; } = new();

        // Navigation Block
        public ObservableCollection<KeyDisplay> SystemRow { get; } = new(); // PrtScn...
        public ObservableCollection<KeyDisplay> NavRow1 { get; } = new(); // Ins...
        public ObservableCollection<KeyDisplay> NavRow2 { get; } = new(); // Del...
        public ObservableCollection<KeyDisplay> ArrowUpRow { get; } = new();
        public ObservableCollection<KeyDisplay> ArrowBottomRow { get; } = new();

        // Numpad Block
        public ObservableCollection<KeyDisplay> NumpadLeft1 { get; } = new();
        public ObservableCollection<KeyDisplay> NumpadLeft2 { get; } = new();
        public ObservableCollection<KeyDisplay> NumpadLeft3 { get; } = new();
        public ObservableCollection<KeyDisplay> NumpadLeft4 { get; } = new();
        public ObservableCollection<KeyDisplay> NumpadLeft5 { get; } = new();
        public ObservableCollection<KeyDisplay> NumpadRight { get; } = new();

        public KeyboardViewModel(KeybindingService keybindingService, ProfileService? profileService = null)
        {
            _keybindingService = keybindingService;
            _profileService = profileService;
            RefreshBindings();
        }

        public void RefreshBindings()
        {
            // --- Main Block ---
            ResetCollection(FunctionRow, new[] 
            {
                Key(SButton.Escape, width: 120), Key(SButton.F1), Key(SButton.F2), Key(SButton.F3), Key(SButton.F4),
                Key(SButton.F5), Key(SButton.F6), Key(SButton.F7), Key(SButton.F8),
                Key(SButton.F9), Key(SButton.F10, width: 100), Key(SButton.F11, width: 100), Key(SButton.F12, width: 100)
            });

            ResetCollection(NumberRow, new[]
            {
                Key(SButton.OemTilde), Key(SButton.D1), Key(SButton.D2), Key(SButton.D3), Key(SButton.D4),
                Key(SButton.D5), Key(SButton.D6), Key(SButton.D7), Key(SButton.D8), Key(SButton.D9),
                Key(SButton.D0), Key(SButton.OemMinus), Key(SButton.OemPlus), Key(SButton.Back, width: 160)
            });

            ResetCollection(TopRow, new[]
            {
                Key(SButton.Tab, width: 120), Key(SButton.Q), Key(SButton.W), Key(SButton.E), Key(SButton.R),
                Key(SButton.T), Key(SButton.Y), Key(SButton.U), Key(SButton.I), Key(SButton.O),
                Key(SButton.P), Key(SButton.OemOpenBrackets), Key(SButton.OemCloseBrackets), Key(SButton.OemPipe, width: 120)
            });

            ResetCollection(HomeRow, new[]
            {
                Key(SButton.CapsLock, width: 140), Key(SButton.A), Key(SButton.S), Key(SButton.D), Key(SButton.F),
                Key(SButton.G), Key(SButton.H), Key(SButton.J), Key(SButton.K), Key(SButton.L),
                Key(SButton.OemSemicolon), Key(SButton.OemQuotes), Key(SButton.Enter, width: 180)
            });

            ResetCollection(BottomRow, new[]
            {
                Key(SButton.LeftShift, width: 200), Key(SButton.Z), Key(SButton.X), Key(SButton.C), Key(SButton.V),
                Key(SButton.B), Key(SButton.N), Key(SButton.M), Key(SButton.OemComma), Key(SButton.OemPeriod),
                Key(SButton.OemQuestion), Key(SButton.RightShift, width: 220)
            });

            ResetCollection(SpaceRow, new[]
            {
                Key(SButton.LeftControl, width: 120), Key(SButton.LeftWindows), Key(SButton.LeftAlt),
                Key(SButton.Space, width: 500),
                Key(SButton.RightAlt), Key(SButton.RightWindows), Key(SButton.RightControl, width: 120)
            });

            // --- Navigation Block ---
            ResetCollection(SystemRow, new[] { Key(SButton.PrintScreen, width: 110), Key(SButton.Scroll, width: 110), Key(SButton.Pause, width: 110) });
            ResetCollection(NavRow1, new[] { Key(SButton.Insert, width: 110), Key(SButton.Home, width: 110), Key(SButton.PageUp, width: 110) });
            ResetCollection(NavRow2, new[] { Key(SButton.Delete, width: 110), Key(SButton.End, width: 110), Key(SButton.PageDown, width: 110) });
            
            ResetCollection(ArrowUpRow, new[] { Key(SButton.Up) });
            ResetCollection(ArrowBottomRow, new[] { Key(SButton.Left), Key(SButton.Down), Key(SButton.Right) });

            // --- Numpad Block ---
            ResetCollection(NumpadLeft1, new[] { Key(SButton.NumLock, width: 125), Key(SButton.Divide), Key(SButton.Multiply) });
            ResetCollection(NumpadLeft2, new[] { Key(SButton.NumPad7), Key(SButton.NumPad8), Key(SButton.NumPad9) });
            ResetCollection(NumpadLeft3, new[] { Key(SButton.NumPad4), Key(SButton.NumPad5), Key(SButton.NumPad6) });
            ResetCollection(NumpadLeft4, new[] { Key(SButton.NumPad1), Key(SButton.NumPad2), Key(SButton.NumPad3) });
            ResetCollection(NumpadLeft5, new[] { Key(SButton.NumPad0, width: 168), Key(SButton.Decimal) });

            // Right Section
            ResetCollection(NumpadRight, new[] 
            { 
                Key(SButton.Subtract), 
                Key(SButton.Add, height: 220), 
                Key(SButton.Enter, height: 220) // Numpad Enter 
            });
        }

        private const float BaseScale = 0.8f; // Scale down to 80% to fit 1080p screens

        private void ResetCollection(ObservableCollection<KeyDisplay> collection, IEnumerable<KeyDisplay> items)
        {
            collection.Clear();
            foreach (var item in items) collection.Add(item);
        }

        private KeyDisplay Key(SButton btn, float width = 80, float height = 100)
        {
            // Check for custom profile label first, then fall back to action ID
            string customLabel = _profileService?.GetLabel(btn) ?? "";
            string actionId = _keybindingService.GetActionId(btn) ?? "";
            string displayLabel = !string.IsNullOrEmpty(customLabel) ? customLabel : actionId;
            string tint = _keybindingService.GetActionTint(actionId);

            return new KeyDisplay(
                btn,
                new Keybind(SButton.None), 
                GetKeyLabel(btn), 
                displayLabel, 
                OnKeyClick,
                $"{(width * BaseScale):0.##}px", 
                $"{(height * BaseScale):0.##}px", 
                tint
            );
        }

        private string GetKeyLabel(SButton btn)
        {
            return btn switch
            {
                SButton.OemTilde => "`",
                SButton.D1 => "1",
                SButton.D2 => "2",
                SButton.D3 => "3",
                SButton.D4 => "4",
                SButton.D5 => "5",
                SButton.D6 => "6",
                SButton.D7 => "7",
                SButton.D8 => "8",
                SButton.D9 => "9",
                SButton.D0 => "0",
                SButton.OemMinus => "-",
                SButton.OemPlus => "+",
                SButton.Back => "Back",
                SButton.Tab => "Tab",
                SButton.OemOpenBrackets => "[",
                SButton.OemCloseBrackets => "]",
                SButton.OemPipe => "\\",
                SButton.CapsLock => "Caps",
                SButton.OemSemicolon => ";",
                SButton.OemQuotes => "'",
                SButton.Enter => "Enter",
                SButton.LeftShift => "Shift",
                SButton.OemComma => ",",
                SButton.OemPeriod => ".",
                SButton.OemQuestion => "/",
                SButton.RightShift => "Shift",
                SButton.LeftControl => "Ctrl",
                SButton.LeftWindows => "Win",
                SButton.LeftAlt => "Alt",
                SButton.Space => "Space",
                SButton.RightAlt => "Alt",
                SButton.RightWindows => "Win",
                SButton.RightControl => "Ctrl",
                SButton.PrintScreen => "PrtSc",
                SButton.Scroll => "Scroll",
                SButton.Pause => "Pause",
                SButton.Insert => "Ins",
                SButton.Home => "Home",
                SButton.PageUp => "PgUp",
                SButton.Delete => "Del",
                SButton.End => "End",
                SButton.PageDown => "PgDn",
                SButton.Up => "^",
                SButton.Left => "<",
                SButton.Down => "v",
                SButton.Right => ">",
                SButton.NumLock => "Num",
                SButton.Divide => "/",
                SButton.Multiply => "*",
                SButton.Subtract => "-",
                SButton.Add => "+",
                SButton.Decimal => ".",
                SButton.NumPad0 => "0",
                SButton.NumPad1 => "1",
                SButton.NumPad2 => "2",
                SButton.NumPad3 => "3",
                SButton.NumPad4 => "4",
                SButton.NumPad5 => "5",
                SButton.NumPad6 => "6",
                SButton.NumPad7 => "7",
                SButton.NumPad8 => "8",
                SButton.NumPad9 => "9",
                SButton.F1 => "F1",
                SButton.F2 => "F2",
                SButton.F3 => "F3",
                SButton.F4 => "F4",
                SButton.F5 => "F5",
                SButton.F6 => "F6",
                SButton.F7 => "F7",
                SButton.F8 => "F8",
                SButton.F9 => "F9",
                SButton.F10 => "F10",
                SButton.F11 => "F11",
                SButton.F12 => "F12",
                SButton.Escape => "Esc",
                _ => btn.ToString()
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // --- Click Handlers for Edit Mode ---
        
        /// <summary>
        /// Called when a key is clicked. Opens the edit popup.
        /// </summary>
        public void OnKeyClick(SButton key)
        {
            EditingKey = key;
            EditText = _profileService?.GetLabel(key) ?? "";
            IsEditing = true;
        }

        /// <summary>
        /// Called when Confirm button is clicked. Saves the label and closes popup.
        /// </summary>
        public void OnConfirmEdit()
        {
            if (_profileService != null && EditingKey != SButton.None)
            {
                _profileService.SetLabel(EditingKey, EditText);
                _profileService.SaveCurrentProfile();
                RefreshBindings();
            }
            IsEditing = false;
        }

        /// <summary>
        /// Called when Cancel button is clicked. Closes popup without saving.
        /// </summary>
        public void OnCancelEdit()
        {
            IsEditing = false;
        }
    }
}
