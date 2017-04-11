using HandHistories.Objects.Cards;

namespace PokerMonkey.Stats.Models
{
    public class PlayerStats
    {
        public string Player { get; set; }
        public StreetStats PreflopStats { get; private set; } = new StreetStats();
        public StreetStats FlopStats { get; private set; } = new StreetStats();
        public StreetStats TurnStats { get; private set; } = new StreetStats();
        public StreetStats RiverStats { get; private set; } = new StreetStats();
        public StreetStats ShowdownStats { get; private set; } = new StreetStats();

        public StreetStats GetStats(Street street)
        {
            if (street == Street.Preflop)
                return PreflopStats;
            if (street == Street.Flop)
                return FlopStats;
            if (street == Street.Turn)
                return TurnStats;
            if (street == Street.River)
                return RiverStats;
            if (street == Street.Showdown)
                return ShowdownStats;

            return null;
        }

        public void SetStats(Street street, StreetStats stats)
        {
            if (street == Street.Preflop)
                PreflopStats = stats;
            if (street == Street.Flop)
                FlopStats = stats;
            if (street == Street.Turn)
                TurnStats = stats;
            if (street == Street.River)
                RiverStats = stats;
            if (street == Street.Showdown)
                ShowdownStats = stats;
        }
    }
}