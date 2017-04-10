using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class RaiseNormalizedAmountStatExtractor : StatExtractorBase
    {
        private readonly decimal _bigBlindAmount;
        private decimal _amountTotal;

        public RaiseNormalizedAmountStatExtractor(decimal bigBlindAmount, string playerName, Street street) : base(playerName, street)
        {
            _bigBlindAmount = bigBlindAmount;
            Value = 0;
        }

        public decimal Value { get; private set; }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.Amount < 0 && action.HandActionType == HandActionType.RAISE)
            {
                _amountTotal += -action.Amount;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.RaiseNormalizedAmount = _amountTotal / _bigBlindAmount;
        }
    }
}