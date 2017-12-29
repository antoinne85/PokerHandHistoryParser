using System;

namespace HandHistories.Objects.GameDescription
{
    [Flags]
    public enum TableTypeDescription : long
    {
        // General TableTypes

        Unknown = 0,

        Regular = 0x1L << 0,

        Anonymous = 0x1L << 1,

        SuperSpeed = 0x1L << 2,

        Deep = 0x1L << 3,

        Ante = 0x1L << 4,

        Cap = 0x1L << 5,

        Speed = 0x1L << 6,

        Jackpot = 0x1L << 7,

        SevenDeuceGame = 0x1L << 8,

        FiftyBigBlindsMin = 0x1L << 9,

        Shallow = 0x1L << 10,

        PushFold = 0x1L << 11,

        Zoom = 0x1L << 12,

        Strobe = 0x1L << 13,

        Rush = 0x1L << 14,

        SpeedPoker = 0x1L << 15,

        FastForward = 0x1L << 16,

        Snap = 0x1L << 17,

        Turbo = 0x1L << 18,

        HyperTurbo = 0x1L << 19,

        Slow = 0x1L << 20,

        // SNG specific tabletypes

        Rebuy = 0x1L << 21,

        NoBlindIncreases = 0x1L << 22,

        Knockout = 0x1L << 23,

        ProgressiveKnockout = 0x1L << 24,

        Fifty50 = 0x1L << 25,


        // This is an indicator for the max amount of players in the SNG according to latest PokerStars TableType descriptions
        // e.g. a HU SNG can have 2,4,16 or 32 players involved
        // Not needed for other sites ( mostly because they don't have a huge variety in SNG types )
        // Might be worth to move this to its own type, but at HHSmithy we have various internal reasons to keep it here

        P2 = 0x1L << 26,

        P4 = 0x1L << 27,

        P16 = 0x1L << 28,

        P32 = 0x1L << 29,

        P12 = 0x1L << 30,

        P18 = 0x1L << 31,

        P27 = 0x1L << 32,

        P45 = 0x1L << 33,

        P90 = 0x1L << 34,

        P180 = 0x1L << 35,

        P240 = 0x1L << 36,

        P360 = 0x1L << 37,

        P990 = 0x1L << 38,


        Any = 0x1L << 63,

        All = 0x7FFFFFFFFFFFFFFF
    }
}
