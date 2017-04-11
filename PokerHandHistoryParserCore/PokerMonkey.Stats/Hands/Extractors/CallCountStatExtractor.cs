using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class CallCountStatExtractor : StatExtractorBase
    {
        private int _count = 0;

        public CallCountStatExtractor(string playerName, Street street) : base(playerName, street)
        {
        }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.HandActionType == HandActionType.CALL)
            {
                _count++;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.CallCount = _count;
        }
    }
}