using StardewModdingAPI;
using StardewValley;

namespace HotKeyViewer.Infrastructure
{
    public class GameState : IGameState
    {
        public Options? Options => Game1.options;

        public bool IsPlayerFree => Context.IsPlayerFree;
    }
}
