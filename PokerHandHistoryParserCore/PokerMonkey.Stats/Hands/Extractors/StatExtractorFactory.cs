using System.Collections.Generic;
using System.Linq;
using HandHistories.Objects.Cards;
using HandHistories.Objects.Hand;

namespace PokerMonkey.Stats.Hands.Extractors
{
    public class StatExtractorFactory
    {
        public IEnumerable<IStatExtractor> CreateExtractors(HandHistory history)
        {
            var players = history.Players.Where(p => !p.IsSittingOut).Select(p => p.PlayerName);

            var streets = new[] { Street.Preflop, Street.Flop, Street.Turn, Street.River };
            foreach (var player in players)
            {
                foreach (var street in streets)
                {
                    yield return new VpipStatExtractor(player, street);
                    yield return new VpipAmountStatExtractor(player, street);
                    yield return new VpipNormalizedAmountStatExtractor(history.GameDescription.Limit.BigBlind, player, street);

                    yield return new RaiseStatExtractor(player, street);
                    yield return new RaiseAmountStatExtractor(player, street);
                    yield return new RaiseNormalizedAmountStatExtractor(history.GameDescription.Limit.BigBlind, player, street);

                    yield return new BetCountStatExtractor(player, street);
                    yield return new FoldCountStatExtractor(player, street);
                    yield return new RaiseCountStatExtractor(player, street);
                    yield return new CheckCountStatExtractor(player, street);
                    yield return new CallCountStatExtractor(player, street);
                }
            }
        }
    }
}