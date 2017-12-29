using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class VpipNormalizedAmountStatExtractor : StatExtractorBase
    {
        private readonly decimal _bigBlindAmount;
        private decimal _amountTotal;

        public VpipNormalizedAmountStatExtractor(decimal bigBlindAmount, string playerName, Street street) : base(playerName, street)
        {
            _bigBlindAmount = bigBlindAmount;
            Value = 0;
        }

        public decimal Value { get; private set; }

        protected override void ProcessActionInternal(HandAction action)
        {
            if (action.Amount < 0 && !Extensions.IsBlind(action.HandActionType))
            {
                _amountTotal += -action.Amount;
                Value = _amountTotal / _bigBlindAmount;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.VoluntarilyPutInPotNormalizedAmount = Value;
        }
    }
}