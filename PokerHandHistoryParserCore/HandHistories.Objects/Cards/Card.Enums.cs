using System;

namespace HandHistories.Objects.Cards
{
    public partial struct Card
    {
        #region EnumLookups
        static CardValueEnum[] rankParseLookup = initRankParseLookup();

        private static CardValueEnum[] initRankParseLookup()
        {
            CardValueEnum[] ranks = new CardValueEnum[128];
            ranks['A'] = CardValueEnum._A;
            ranks['a'] = CardValueEnum._A;
            ranks['K'] = CardValueEnum._K;
            ranks['k'] = CardValueEnum._K;
            ranks['Q'] = CardValueEnum._Q;
            ranks['q'] = CardValueEnum._Q;
            ranks['J'] = CardValueEnum._J;
            ranks['j'] = CardValueEnum._J;
            ranks['T'] = CardValueEnum._T;
            ranks['t'] = CardValueEnum._T;
            for (int i = 2; i <= 9; i++)
            {
                ranks[i.ToString()[0]] = (CardValueEnum)i;
            }
            return ranks;
        }

        static SuitEnum[] suitParseLookup = initSuitParseLookup();

        private static SuitEnum[] initSuitParseLookup()
        {
            SuitEnum[] suits = new SuitEnum[128];
            suits['C'] = SuitEnum.Clubs;
            suits['c'] = SuitEnum.Clubs;
            suits['D'] = SuitEnum.Diamonds;
            suits['d'] = SuitEnum.Diamonds;
            suits['H'] = SuitEnum.Hearts;
            suits['h'] = SuitEnum.Hearts;
            suits['S'] = SuitEnum.Spades;
            suits['s'] = SuitEnum.Spades;
            return suits;
        }
        #endregion

        #region Enums
        enum CardValueEnum : byte
        {
            Unknown = 0,
            _2 = 2,
            _3 = 3,
            _4 = 4,
            _5 = 5,
            _6 = 6,
            _7 = 7,
            _8 = 8,
            _9 = 9,
            _T = 0xA,
            _J = 0xB,
            _Q = 0xC,
            _K = 0xD,
            _A = 0xE,
        }

        enum SuitEnum : byte
        {
            Unknown = 0,
            Clubs = 0x10,
            Diamonds = 0x20,
            Hearts = 0x30,
            Spades = 0x40,
        }

        enum CardEnum : byte
        {
            Unknown = 0,

            _2c = SuitEnum.Clubs | CardValueEnum._2,
            
            _3c = SuitEnum.Clubs | CardValueEnum._3,
            
            _4c = SuitEnum.Clubs | CardValueEnum._4,
            
            _5c = SuitEnum.Clubs | CardValueEnum._5,
            
            _6c = SuitEnum.Clubs | CardValueEnum._6,
            
            _7c = SuitEnum.Clubs | CardValueEnum._7,
            
            _8c = SuitEnum.Clubs | CardValueEnum._8,
            
            _9c = SuitEnum.Clubs | CardValueEnum._9,
            
            _Tc = SuitEnum.Clubs | CardValueEnum._T,
            
            _Jc = SuitEnum.Clubs | CardValueEnum._J,
            
            _Qc = SuitEnum.Clubs | CardValueEnum._Q,
            
            _Kc = SuitEnum.Clubs | CardValueEnum._K,
            
            _Ac = SuitEnum.Clubs | CardValueEnum._A,
            
            _2s = SuitEnum.Spades | CardValueEnum._2,
            
            _3s = SuitEnum.Spades | CardValueEnum._3,
            
            _4s = SuitEnum.Spades | CardValueEnum._4,
            
            _5s = SuitEnum.Spades | CardValueEnum._5,
            
            _6s = SuitEnum.Spades | CardValueEnum._6,
            
            _7s = SuitEnum.Spades | CardValueEnum._7,
            
            _8s = SuitEnum.Spades | CardValueEnum._8,
            
            _9s = SuitEnum.Spades | CardValueEnum._9,
            
            _Ts = SuitEnum.Spades | CardValueEnum._T,
            
            _Js = SuitEnum.Spades | CardValueEnum._J,
            
            _Qs = SuitEnum.Spades | CardValueEnum._Q,
            
            _Ks = SuitEnum.Spades | CardValueEnum._K,
            
            _As = SuitEnum.Spades | CardValueEnum._A,
            
            _2h = SuitEnum.Hearts | CardValueEnum._2,
            
            _3h = SuitEnum.Hearts | CardValueEnum._3,
            
            _4h = SuitEnum.Hearts | CardValueEnum._4,
            
            _5h = SuitEnum.Hearts | CardValueEnum._5,
            
            _6h = SuitEnum.Hearts | CardValueEnum._6,
            
            _7h = SuitEnum.Hearts | CardValueEnum._7,
            
            _8h = SuitEnum.Hearts | CardValueEnum._8,
            
            _9h = SuitEnum.Hearts | CardValueEnum._9,
            
            _Th = SuitEnum.Hearts | CardValueEnum._T,
            
            _Jh = SuitEnum.Hearts | CardValueEnum._J,
            
            _Qh = SuitEnum.Hearts | CardValueEnum._Q,
            
            _Kh = SuitEnum.Hearts | CardValueEnum._K,
            
            _Ah = SuitEnum.Hearts | CardValueEnum._A,
            
            _2d = SuitEnum.Diamonds | CardValueEnum._2,
            
            _3d = SuitEnum.Diamonds | CardValueEnum._3,
            
            _4d = SuitEnum.Diamonds | CardValueEnum._4,
            
            _5d = SuitEnum.Diamonds | CardValueEnum._5,
            
            _6d = SuitEnum.Diamonds | CardValueEnum._6,
            
            _7d = SuitEnum.Diamonds | CardValueEnum._7,
            
            _8d = SuitEnum.Diamonds | CardValueEnum._8,
            
            _9d = SuitEnum.Diamonds | CardValueEnum._9,
            
            _Td = SuitEnum.Diamonds | CardValueEnum._T,
            
            _Jd = SuitEnum.Diamonds | CardValueEnum._J,
            
            _Qd = SuitEnum.Diamonds | CardValueEnum._Q,
            
            _Kd = SuitEnum.Diamonds | CardValueEnum._K,
            
            _Ad = SuitEnum.Diamonds | CardValueEnum._A,
        }
        #endregion
    }
}
