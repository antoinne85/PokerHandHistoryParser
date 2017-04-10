using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class BetCountStatExtractor : StatExtractorBase
    {
        private int _count = 0;

        public BetCountStatExtractor(string playerName, Street street) : base(playerName, street)
        {
        }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.HandActionType == HandActionType.BET)
            {
                _count++;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.BetCount = _count;
        }
    }
}