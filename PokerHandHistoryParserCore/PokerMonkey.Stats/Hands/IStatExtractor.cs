using HandHistories.Objects.Actions;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands
{
    public interface IStatExtractor
    {
        void ProcessAction(HandAction action);
        void ApplyResult(PlayerStats stats);
    }
}