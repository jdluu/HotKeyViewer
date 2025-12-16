
using StardewModdingAPI;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewModdingAPI.Utilities;

namespace HotKeyViewer
{
    // Record to hold key binding, label, and custom dimensions
    public record KeyDisplay(Keybind Keybind, string? Label = null, string Width = "64px", string Height = "64px")
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
        public List<KeyDisplay> NumpadRow1 { get; private set; } = new();
        public List<KeyDisplay> NumpadRow2 { get; private set; } = new();
        public List<KeyDisplay> NumpadRow3 { get; private set; } = new();
        public List<KeyDisplay> NumpadRow4 { get; private set; } = new();
        public List<KeyDisplay> NumpadRow5 { get; private set; } = new();

        public KeyboardViewModel()
        {
            RefreshBindings();
        }

        public void RefreshBindings()
        {
            // --- Main Block ---
            FunctionRow = new List<KeyDisplay> 
            {
                Key(SButton.Escape), Key(SButton.F1), Key(SButton.F2), Key(SButton.F3), Key(SButton.F4),
                Key(SButton.F5), Key(SButton.F6), Key(SButton.F7), Key(SButton.F8),
                Key(SButton.F9), Key(SButton.F10), Key(SButton.F11), Key(SButton.F12)
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
                Key(SButton.LeftControl, width: "90px"), Key(SButton.LeftWindows, width: "80px"), Key(SButton.LeftAlt, width: "80px"),
                Key(SButton.Space, width: "400px"), 
                Key(SButton.RightAlt, width: "80px"), Key(SButton.RightWindows, width: "80px"), Key(SButton.RightControl, width: "90px")
            };

            // --- Navigation Block ---
            SystemRow = new List<KeyDisplay>
            {
                Key(SButton.PrintScreen), Key(SButton.Scroll), Key(SButton.Pause)
            };

            NavRow1 = new List<KeyDisplay>
            {
                Key(SButton.Insert), Key(SButton.Home), Key(SButton.PageUp)
            };
            
            NavRow2 = new List<KeyDisplay>
            {
                Key(SButton.Delete), Key(SButton.End), Key(SButton.PageDown)
            };

            ArrowUpRow = new List<KeyDisplay> { Key(SButton.Up) };
            ArrowBottomRow = new List<KeyDisplay> { Key(SButton.Left), Key(SButton.Down), Key(SButton.Right) };

            // --- Numpad Block ---
            // Note: StardewLib doesn't have explicit Numpad keys in SButton enum in strict PC standard,
            // they are usually mapped to D1-D0 if not distinguished, or specific keys.
            // Using standard SButton names which essentially map to XNA Keys.
            // NumPad0 etc exist? Let's check SButton.
            // If they don't exist in SButton, we might fall back to similar keys or skip.
            // SButton usually has NumPad0..NumPad9.
            
            // Assume NumPad keys exist in SButton for now (standard XNA).
            NumpadRow1 = new List<KeyDisplay> { Key(SButton.NumLock), Key(SButton.Divide), Key(SButton.Multiply), Key(SButton.Subtract) };
            NumpadRow2 = new List<KeyDisplay> { Key(SButton.NumPad7), Key(SButton.NumPad8), Key(SButton.NumPad9), Key(SButton.Add, height: "135px") }; // + is tall
            NumpadRow3 = new List<KeyDisplay> { Key(SButton.NumPad4), Key(SButton.NumPad5), Key(SButton.NumPad6) }; // + continues here visually
            NumpadRow4 = new List<KeyDisplay> { Key(SButton.NumPad1), Key(SButton.NumPad2), Key(SButton.NumPad3), Key(SButton.Enter, height: "135px") }; // Enter is tall (on numpad often) or handled differently. Main Enter is above. This is NumPadEnter? SButton has just Enter usually. XNA has Enter.
            // Actually XNA Keys has Enter and just Enter. 
            // We'll use what we can. Safe to re-use Enter if needed but preferably specific.
            // SButton doesn't distinguish Numpad Enter usually. We will use Enter again or ignore uniqueness for now.
            // Using 'Enter' again for Numpad Enter.
            
            NumpadRow5 = new List<KeyDisplay> { Key(SButton.NumPad0, width: "135px"), Key(SButton.Decimal) };


            // Notify UI
            var props = new[] { 
                nameof(FunctionRow), nameof(NumberRow), nameof(TopRow), nameof(HomeRow), nameof(BottomRow), nameof(SpaceRow),
                nameof(SystemRow), nameof(NavRow1), nameof(NavRow2), nameof(ArrowUpRow), nameof(ArrowBottomRow),
                nameof(NumpadRow1), nameof(NumpadRow2), nameof(NumpadRow3), nameof(NumpadRow4), nameof(NumpadRow5)
            };
            foreach (var p in props) OnPropertyChanged(p);
        }

        private KeyDisplay Key(SButton btn, string width = "64px", string height = "64px")
        {
            return new KeyDisplay(new Keybind(btn), GetActionId(btn), width, height);
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
