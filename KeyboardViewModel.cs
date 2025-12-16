
using StardewModdingAPI;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewModdingAPI.Utilities;

namespace HotKeyViewer
{
    // Record to hold key binding, label, and custom dimensions
    public record KeyDisplay(Keybind Keybind, string Label, string Width = "64px", string Height = "64px")
    {
        public string LayoutSize => $"{Width} {Height}";
    }

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
        // Numpad Block
        public List<KeyDisplay> NumpadLeft1 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft2 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft3 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft4 { get; private set; } = new();
        public List<KeyDisplay> NumpadLeft5 { get; private set; } = new();
        public List<KeyDisplay> NumpadRight { get; private set; } = new();

        public KeyboardViewModel()
        {
            RefreshBindings();
        }

        public void RefreshBindings()
        {
            // --- Main Block ---
            FunctionRow = new List<KeyDisplay> 
            {
                Key(SButton.Escape, width: "100px"), Key(SButton.F1), Key(SButton.F2), Key(SButton.F3), Key(SButton.F4),
                Key(SButton.F5), Key(SButton.F6), Key(SButton.F7), Key(SButton.F8),
                Key(SButton.F9), Key(SButton.F10, width: "80px"), Key(SButton.F11, width: "80px"), Key(SButton.F12, width: "80px")
            };

            NumberRow = new List<KeyDisplay>
            {
                Key(SButton.OemTilde), Key(SButton.D1), Key(SButton.D2), Key(SButton.D3), Key(SButton.D4), Key(SButton.D5),
                Key(SButton.D6), Key(SButton.D7), Key(SButton.D8), Key(SButton.D9), Key(SButton.D0),
                Key(SButton.OemMinus), Key(SButton.OemPlus), Key(SButton.Back, width: "100px")
            };

            TopRow = new List<KeyDisplay>
            {
                Key(SButton.Tab, width: "100px"), Key(SButton.Q), Key(SButton.W), Key(SButton.E), Key(SButton.R), Key(SButton.T),
                Key(SButton.Y), Key(SButton.U), Key(SButton.I), Key(SButton.O), Key(SButton.P),
                Key(SButton.OemOpenBrackets), Key(SButton.OemCloseBrackets), Key(SButton.OemPipe, width: "90px")
            };

            HomeRow = new List<KeyDisplay>
            {
                Key(SButton.CapsLock, width: "110px"), Key(SButton.A), Key(SButton.S), Key(SButton.D), Key(SButton.F), Key(SButton.G),
                Key(SButton.H), Key(SButton.J), Key(SButton.K), Key(SButton.L), Key(SButton.OemSemicolon), Key(SButton.OemQuotes),
                Key(SButton.Enter, width: "140px")
            };

            BottomRow = new List<KeyDisplay>
            {
                Key(SButton.LeftShift, width: "140px"), Key(SButton.Z), Key(SButton.X), Key(SButton.C), Key(SButton.V), Key(SButton.B),
                Key(SButton.N), Key(SButton.M), Key(SButton.OemComma), Key(SButton.OemPeriod), Key(SButton.OemQuestion),
                Key(SButton.RightShift, width: "160px")
            };

            SpaceRow = new List<KeyDisplay>
            {
                Key(SButton.LeftControl, width: "110px"), Key(SButton.LeftWindows, width: "100px"), Key(SButton.LeftAlt, width: "100px"),
                Key(SButton.Space, width: "400px"), 
                Key(SButton.RightAlt, width: "100px"), Key(SButton.RightWindows, width: "100px"), Key(SButton.RightControl, width: "110px")
            };

            // --- Navigation Block ---
            SystemRow = new List<KeyDisplay>
            {
                Key(SButton.PrintScreen, width: "110px"), Key(SButton.Scroll, width: "110px"), Key(SButton.Pause, width: "110px")
            };

            NavRow1 = new List<KeyDisplay>
            {
                Key(SButton.Insert, width: "110px"), Key(SButton.Home, width: "110px"), Key(SButton.PageUp, width: "110px")
            };
            
            NavRow2 = new List<KeyDisplay>
            {
                Key(SButton.Delete, width: "110px"), Key(SButton.End, width: "110px"), Key(SButton.PageDown, width: "110px")
            };

            ArrowUpRow = new List<KeyDisplay> { Key(SButton.Up) };
            ArrowBottomRow = new List<KeyDisplay> { Key(SButton.Left), Key(SButton.Down), Key(SButton.Right) };

            // --- Numpad Block ---
            // Left Section (3 columns wide)
            NumpadLeft1 = new List<KeyDisplay> { Key(SButton.NumLock, width: "100px"), Key(SButton.Divide), Key(SButton.Multiply) };
            NumpadLeft2 = new List<KeyDisplay> { Key(SButton.NumPad7), Key(SButton.NumPad8), Key(SButton.NumPad9) };
            NumpadLeft3 = new List<KeyDisplay> { Key(SButton.NumPad4), Key(SButton.NumPad5), Key(SButton.NumPad6) };
            NumpadLeft4 = new List<KeyDisplay> { Key(SButton.NumPad1), Key(SButton.NumPad2), Key(SButton.NumPad3) };
            NumpadLeft5 = new List<KeyDisplay> { Key(SButton.NumPad0, width: "135px"), Key(SButton.Decimal) };

            // Right Section (1 column wide, containing tall keys at specific positions)
            // Note: Add and Enter on Numpad are typically 2 rows high.
            // Using approximate height to span two rows + gaps. 
            // Standard gap ~4px + Label height + Key height ~? 
            // If we assume a fixed row height, we can estimate. 64 + 64 + margin.
            // Let's use 150px for now to be safe or stick to 135px.
            NumpadRight = new List<KeyDisplay> 
            { 
                Key(SButton.Subtract), 
                Key(SButton.Add, height: "150px"), 
                Key(SButton.Enter, height: "150px") // Numpad Enter 
            };


            // Notify UI
            var props = new[] { 
                nameof(FunctionRow), nameof(NumberRow), nameof(TopRow), nameof(HomeRow), nameof(BottomRow), nameof(SpaceRow),
                nameof(SystemRow), nameof(NavRow1), nameof(NavRow2), nameof(ArrowUpRow), nameof(ArrowBottomRow),
                nameof(NumpadLeft1), nameof(NumpadLeft2), nameof(NumpadLeft3), nameof(NumpadLeft4), nameof(NumpadLeft5), nameof(NumpadRight)
            };
            foreach (var p in props) OnPropertyChanged(p);
        }

        private KeyDisplay Key(SButton btn, string width = "64px", string height = "64px")
        {
            return new KeyDisplay(new Keybind(btn), GetActionId(btn) ?? "", width, height);
        }

        private string? GetActionId(SButton button)
        {
            if (Game1.options == null) return null;

            if (IsBound(Game1.options.menuButton, button)) return "Menu";
            if (IsBound(Game1.options.journalButton, button)) return "Journal";
            if (IsBound(Game1.options.mapButton, button)) return "Map";
            if (IsBound(Game1.options.inventorySlot1, button)) return "Slot 1";
            if (IsBound(Game1.options.inventorySlot2, button)) return "Slot 2";
            if (IsBound(Game1.options.inventorySlot3, button)) return "Slot 3";
            if (IsBound(Game1.options.moveUpButton, button)) return "Up";
            if (IsBound(Game1.options.moveLeftButton, button)) return "Left";
            if (IsBound(Game1.options.moveDownButton, button)) return "Down";
            if (IsBound(Game1.options.moveRightButton, button)) return "Right";
            if (IsBound(Game1.options.runButton, button)) return "Run";
            if (IsBound(Game1.options.actionButton, button)) return "Action";
            if (IsBound(Game1.options.useToolButton, button)) return "Tool";
            if (IsBound(Game1.options.chatButton, button)) return "Chat";
            
            return null;
        }

        private bool IsBound(List<InputButton> buttons, SButton button)
        {
            return buttons != null && buttons.Any(b => b.ToSButton() == button);
        }
         
        private bool IsBound(InputButton[] buttons, SButton button)
        {
             return buttons != null && buttons.Any(b => b.ToSButton() == button);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
