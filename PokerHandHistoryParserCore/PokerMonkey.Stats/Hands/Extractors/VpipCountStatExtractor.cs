using HandHistories.Objects.Actions;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class VpipStatExtractor : StatExtractorBase
    {
        public VpipStatExtractor(string playerName, Street street) : base(playerName, street)
        {
        }

        public bool Value { get; private set; }

        protected override void ProcessActionInternal(HandAction action)
        {

            if (action.Amount < 0 && !Extensions.IsBlind(action.HandActionType))
            {
                Value = true;
            }
        }

        protected override void ApplyResultInternal(StreetStats stats)
        {
            stats.VoluntarilyPutInPot = Value;
        }
    }
}