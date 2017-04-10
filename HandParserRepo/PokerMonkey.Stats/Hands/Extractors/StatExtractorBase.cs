using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public abstract class StatExtractorBase : IStatExtractor
    {
        public string PlayerName { get; }
        public Street Street { get; }

        public StatExtractorBase(string playerName, Street street)
        {
            PlayerName = playerName;
            Street = street;
        }

        public void ProcessAction(HandAction action)
        {
            if (action.PlayerName == PlayerName && action.Street == Street)
            {
                ProcessActionInternal(action);
            }
        }

        protected abstract void ProcessActionInternal(HandAction action);

        public void ApplyResult(PlayerStats stats)
        {
            if (stats.Player == PlayerName)
            {
                var streetStats = stats.GetStats(Street);
                ApplyResultInternal(streetStats);
            }
        }

        protected abstract void ApplyResultInternal(StreetStats stats);
    }
}