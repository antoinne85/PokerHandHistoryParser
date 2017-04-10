using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class FoldCountStatExtractor : StatExtractorBase
    {
        private int _count = 0;

        public FoldCountStatExtractor(string playerName, Street street) : base(playerName, street)
        {
        }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.HandActionType == HandActionType.FOLD)
            {
                _count++;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.FoldCount = _count;
        }
    }
}