
using StardewModdingAPI;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Utilities;
using HotKeyViewer.Services;

namespace HotKeyViewer
{
    // Record to hold key binding, label, and custom dimensions
    public record KeyDisplay(Keybind Keybind, string FaceText, string Label, string Width = "80px", string Height = "80px", string Tint = "#FFFFFF")
    {
        public string LayoutSize => $"{Width} {Height}";
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

        // Main Block
        public List<KeyDisplay> FunctionRow { get; private set; } = new(); // Esc, F1-F12
        public List<KeyDisplay> NumberRow { get; private set; } = new();
        public List<KeyDisplay> TopRow { get; private set; } = new();
        public List<KeyDisplay> HomeRow { get; private set; } = new();
        public List<KeyDisplay> BottomRow { get; private set; } = new();
        public List<KeyDisplay> SpaceRow { get; private set; } = new();

        // Navigation Block
        public List<KeyDisplay> SystemRow { get; private set; } = new(); // PrtScn...
        public List<KeyDisplay> NavRow1 { get; private set; } = new(); // Ins...
        public List<KeyDisplay> NavRow2 { get; private set; } = new(); // Del...
        public List<KeyDisplay> ArrowUpRow { get; private set; } = new();
        public List<KeyDisplay> ArrowBottomRow { get; private set; } = new();

        // Numpad Block
        public List<KeyDisplay> NumpadLeft1 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft2 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft3 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft4 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft5 { get; private set; } = new();
        public List<KeyDisplay> NumpadRight { get; private set; } = new();

        public KeyboardViewModel(KeybindingService keybindingService, ProfileService? profileService = null)
        {
            _keybindingService = keybindingService;
            _profileService = profileService;
            RefreshBindings();
        }

        public void RefreshBindings()
        {
            // --- Main Block ---
            FunctionRow = new List<KeyDisplay> 
            {
                Key(SButton.Escape, width: 120), Key(SButton.F1), Key(SButton.F2), Key(SButton.F3), Key(SButton.F4),
                Key(SButton.F5), Key(SButton.F6), Key(SButton.F7), Key(SButton.F8),
                Key(SButton.F9), Key(SButton.F10, width: 100), Key(SButton.F11, width: 100), Key(SButton.F12, width: 100)
            };

            NumberRow = new List<KeyDisplay>
            {
                Key(SButton.OemTilde), Key(SButton.D1), Key(SButton.D2), Key(SButton.D3), Key(SButton.D4), Key(SButton.D5),
                Key(SButton.D6), Key(SButton.D7), Key(SButton.D8), Key(SButton.D9), Key(SButton.D0),
                Key(SButton.OemMinus), Key(SButton.OemPlus), Key(SButton.Back, width: 135)
            };

            TopRow = new List<KeyDisplay>
            {
                Key(SButton.Tab, width: 130), Key(SButton.Q), Key(SButton.W), Key(SButton.E), Key(SButton.R), Key(SButton.T),
                Key(SButton.Y), Key(SButton.U), Key(SButton.I), Key(SButton.O), Key(SButton.P),
                Key(SButton.OemOpenBrackets), Key(SButton.OemCloseBrackets), Key(SButton.OemPipe, width: 110)
            };

            HomeRow = new List<KeyDisplay>
            {
                Key(SButton.CapsLock, width: 140), Key(SButton.A), Key(SButton.S), Key(SButton.D), Key(SButton.F), Key(SButton.G),
                Key(SButton.H), Key(SButton.J), Key(SButton.K), Key(SButton.L), Key(SButton.OemSemicolon), Key(SButton.OemQuotes),
                Key(SButton.Enter, width: 180)
            };

            BottomRow = new List<KeyDisplay>
            {
                Key(SButton.LeftShift, width: 175), Key(SButton.Z), Key(SButton.X), Key(SButton.C), Key(SButton.V), Key(SButton.B),
                Key(SButton.N), Key(SButton.M), Key(SButton.OemComma), Key(SButton.OemPeriod), Key(SButton.OemQuestion),
                Key(SButton.RightShift, width: 200)
            };

            SpaceRow = new List<KeyDisplay>
            {
                Key(SButton.LeftControl, width: 135), Key(SButton.LeftWindows, width: 120), Key(SButton.LeftAlt, width: 120),
                Key(SButton.Space, width: 500), 
                Key(SButton.RightAlt, width: 120), Key(SButton.RightWindows, width: 120), Key(SButton.RightControl, width: 135)
            };

            // --- Navigation Block ---
            SystemRow = new List<KeyDisplay>
            {
                Key(SButton.PrintScreen, width: 135), Key(SButton.Scroll, width: 135), Key(SButton.Pause, width: 135)
            };

            NavRow1 = new List<KeyDisplay>
            {
                Key(SButton.Insert, width: 135), Key(SButton.Home, width: 135), Key(SButton.PageUp, width: 135)
            };
            
            NavRow2 = new List<KeyDisplay>
            {
                Key(SButton.Delete, width: 135), Key(SButton.End, width: 135), Key(SButton.PageDown, width: 135)
            };

            ArrowUpRow = new List<KeyDisplay> { Key(SButton.Up) };
            ArrowBottomRow = new List<KeyDisplay> { Key(SButton.Left), Key(SButton.Down), Key(SButton.Right) };

            // --- Numpad Block ---
            // Left Section (3 columns wide)
            NumpadLeft1 = new List<KeyDisplay> { Key(SButton.NumLock, width: 125), Key(SButton.Divide), Key(SButton.Multiply) };
            NumpadLeft2 = new List<KeyDisplay> { Key(SButton.NumPad7), Key(SButton.NumPad8), Key(SButton.NumPad9) };
            NumpadLeft3 = new List<KeyDisplay> { Key(SButton.NumPad4), Key(SButton.NumPad5), Key(SButton.NumPad6) };
            NumpadLeft4 = new List<KeyDisplay> { Key(SButton.NumPad1), Key(SButton.NumPad2), Key(SButton.NumPad3) };
            NumpadLeft5 = new List<KeyDisplay> { Key(SButton.NumPad0, width: 168), Key(SButton.Decimal) };

            // Right Section
            NumpadRight = new List<KeyDisplay> 
            { 
                Key(SButton.Subtract), 
                Key(SButton.Add, height: 220), 
                Key(SButton.Enter, height: 220) // Numpad Enter 
            };


            // Notify UI
            var props = new[] { 
                nameof(FunctionRow), nameof(NumberRow), nameof(TopRow), nameof(HomeRow), nameof(BottomRow), nameof(SpaceRow),
                nameof(SystemRow), nameof(NavRow1), nameof(NavRow2), nameof(ArrowUpRow), nameof(ArrowBottomRow),
                nameof(NumpadLeft1), nameof(NumpadLeft2), nameof(NumpadLeft3), nameof(NumpadLeft4), nameof(NumpadLeft5), nameof(NumpadRight)
            };
            foreach (var p in props) OnPropertyChanged(p);
        }

        private const float BaseScale = 0.8f; // Scale down to 80% to fit 1080p screens

        private KeyDisplay Key(SButton btn, float width = 80, float height = 100)
        {
            // Check for custom profile label first, then fall back to action ID
            string customLabel = _profileService?.GetLabel(btn) ?? "";
            string actionId = _keybindingService.GetActionId(btn) ?? "";
            string displayLabel = !string.IsNullOrEmpty(customLabel) ? customLabel : actionId;
            string tint = _keybindingService.GetActionTint(actionId);

            return new KeyDisplay(
                new Keybind(SButton.None), 
                GetKeyLabel(btn), 
                displayLabel, 
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
    }
}
