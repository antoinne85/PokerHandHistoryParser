using System;

namespace HandHistories.Objects.GameDescription
{    
    public class GameDescriptor
    {
        public GameDescriptor() : this(PokerFormat.Unknown, 
                                       SiteName.Unknown,
                                       GameType.Unknown,
                                       Limit.AllLimit(),
                                       TableType.FromTableTypeDescriptions(),
                                       SeatType.AllSeatType())         
        {

        }

        public GameDescriptor(SiteName siteName,
                              GameType gameType,
                              Limit limit,
                              TableType tableType,
                              SeatType seatType)
            : this(PokerFormat.CashGame, siteName, gameType, limit, tableType, seatType)         
        {

        }

        public GameDescriptor(SiteName siteName,
                              GameType gameType,
                              Buyin buyin,
                              TableType tableType,
                              SeatType seatType)
            : this(PokerFormat.SitAndGo, siteName, gameType, buyin, tableType, seatType)
        {
            
        }

        public GameDescriptor(PokerFormat pokerFormat,
                              SiteName siteName,
                              GameType gameType,
                              Limit limit,
                              TableType tableType,
                              SeatType seatType)
        {
            PokerFormat = pokerFormat;
            Site = siteName;
            GameType = gameType;
            Limit = limit;
            TableType = tableType;
            SeatType = seatType;
        }

        public GameDescriptor(PokerFormat pokerFormat,
                              SiteName siteName,
                              GameType gameType,
                              Buyin buyin,
                              TableType tableType,
                              SeatType seatType)
        {
            PokerFormat = pokerFormat;
            Site = siteName;
            GameType = gameType;
            Buyin = buyin;
            TableType = tableType;
            SeatType = seatType;
        }
        public PokerFormat PokerFormat { get; set; }

        public SiteName Site { get; set; }

        public GameType GameType { get; set; }

        public Limit Limit { get; set; }

        public Buyin Buyin { get; set; }

        public SeatType SeatType { get; set; }

        public TableType TableType { get; set; }
        
        public override bool Equals(object obj)
        {
            GameDescriptor descriptor = obj as GameDescriptor;
            if (descriptor == null) return false;
            return (descriptor.ToString().Equals(this.ToString()));
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}.{3}.{4}", Site, GameType, Limit, TableType, SeatType);
        }
    }
}
