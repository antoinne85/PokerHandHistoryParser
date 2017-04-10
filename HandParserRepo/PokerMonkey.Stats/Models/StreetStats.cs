namespace PokerMonkey.Stats.Models
{
    public class StreetStats
    {
        public bool VoluntarilyPutInPot { get; set; }
        public decimal VoluntarilyPutInPotAmount { get; set; }
        public decimal VoluntarilyPutInPotNormalizedAmount { get; set; }

        public bool Raise { get; set; }
        public decimal RaiseAmount { get; set; }
        public decimal RaiseNormalizedAmount { get; set; }
        public int BetCount { get; set; }
        public int CallCount { get; set; }
        public int RaiseCount { get; set; }
        public int CheckCount { get; set; }
        public int FoldCount { get; set; }
    }
}