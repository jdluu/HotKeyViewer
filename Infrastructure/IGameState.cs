using StardewValley;

namespace HotKeyViewer.Infrastructure
{
    public interface IGameState
    {
        Options? Options { get; }
        bool IsPlayerFree { get; }
    }
}
