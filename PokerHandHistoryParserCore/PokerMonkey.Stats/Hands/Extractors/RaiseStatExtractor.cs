using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class RaiseStatExtractor : StatExtractorBase
    {
        public RaiseStatExtractor(string playerName, Street street) : base(playerName, street)
        {
        }

        public bool Value { get; private set; }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.Amount < 0 && action.HandActionType == HandActionType.RAISE)
            {
                Value = true;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.Raise = Value;
        }
    }
}