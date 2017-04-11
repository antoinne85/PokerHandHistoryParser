using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class RaiseCountStatExtractor : StatExtractorBase
    {
        private int _count = 0;

        public RaiseCountStatExtractor(string playerName, Street street) : base(playerName, street)
        {
        }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.HandActionType == HandActionType.RAISE)
            {
                _count++;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.RaiseCount = _count;
        }
    }
}