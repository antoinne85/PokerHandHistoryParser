using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class CheckCountStatExtractor : StatExtractorBase
    {
        private int _count = 0;

        public CheckCountStatExtractor(string playerName, Street street) : base(playerName, street)
        {
        }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.HandActionType == HandActionType.CHECK)
            {
                _count++;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.CheckCount = _count;
        }
    }
}