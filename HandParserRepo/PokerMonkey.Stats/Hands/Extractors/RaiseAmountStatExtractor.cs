using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class RaiseAmountStatExtractor : StatExtractorBase
    {
        public RaiseAmountStatExtractor(string playerName, Street street) : base(playerName, street)
        {
            Value = 0;
        }

        public decimal Value { get; private set; }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.Amount < 0 && action.HandActionType == HandActionType.RAISE)
            {
                Value += -action.Amount;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.RaiseAmount = Value;
        }
    }
}