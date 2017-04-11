using System.Collections.Generic;
using System.Linq;
using HandHistories.Objects.Cards;
using PokerMonkey.Stats.Models;

namespace PokerMonkey.Stats.Series
{
    public abstract class SeriesStatExtractorBase
    {
        public PlayerStats Aggregate(IEnumerable<PlayerStats> inputs)
        {
            var streets = new[] {Street.Preflop, Street.Flop, Street.Turn, Street.River, Street.Showdown};
            var result = new PlayerStats();
            foreach (var street in streets)
            {
                var streetStats = inputs.Select(i => i.GetStats(street));
                var aggregate = Aggregate(streetStats);
                result.SetStats(street, aggregate);
            }

            return result;
        }

        public abstract StreetStats Aggregate(IEnumerable<StreetStats> stats);
    }
}
