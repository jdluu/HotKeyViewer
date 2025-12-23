using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using System.Collections.Generic;

using HotKeyViewer.Infrastructure;

namespace HotKeyViewer.Services
{
    public class KeybindingService
    {
        private readonly IGameState _gameState;

        public KeybindingService(IGameState gameState)
        {
            _gameState = gameState;
        }

        public string? GetActionId(SButton button)
        {
            if (_gameState.Options == null) return null;

            var options = _gameState.Options;

            if (IsBound(options.menuButton, button)) return "Menu";
            if (IsBound(options.journalButton, button)) return "Journal";
            if (IsBound(options.mapButton, button)) return "Map";
            if (IsBound(options.inventorySlot1, button)) return "Slot 1";
            if (IsBound(options.inventorySlot2, button)) return "Slot 2";
            if (IsBound(options.inventorySlot3, button)) return "Slot 3";
            if (IsBound(options.moveUpButton, button)) return "Up";
            if (IsBound(options.moveLeftButton, button)) return "Left";
            if (IsBound(options.moveDownButton, button)) return "Down";
            if (IsBound(options.moveRightButton, button)) return "Right";
            if (IsBound(options.runButton, button)) return "Run";
            if (IsBound(options.actionButton, button)) return "Action";
            if (IsBound(options.useToolButton, button)) return "Tool";
            if (IsBound(options.chatButton, button)) return "Chat";
            
            return null;
        }

        public string GetActionTint(string actionId)
        {
            return actionId switch
            {
                // Movement - Dark Green
                "Up" or "Left" or "Down" or "Right" or "Run" => "#153015",
                
                // Combat/Tools - Dark Blue
                "Tool" or "Action" or "Slot 1" or "Slot 2" or "Slot 3" => "#152030",
                
                // UI - Dark Gold
                "Menu" or "Journal" or "Map" or "Chat" => "#303015",
                
                // Default - Dark Grey
                _ => "#202020"
            };
        }

        private bool IsBound(IList<InputButton> buttons, SButton button)
        {
            if (buttons == null) return false;
            
            // Avoid LINQ Any() to save allocations
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].ToSButton() == button) return true;
            }
            return false;
        }
    }
}
