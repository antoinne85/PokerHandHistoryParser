using HandHistories.Objects.Cards;

namespace HandHistories.Objects.Actions
{
    public class WinningsAction : HandAction
    {
        public int PotNumber { get; private set; }

        public WinningsAction(string playerName, 
                              HandActionType handActionType, 
                              decimal amount,                               
                              int potNumber,
                              int actionNumber = 0) : base(playerName, handActionType, amount, Street.Showdown, actionNumber)
        {
            PotNumber = potNumber;
        }

        public override string ToString()
        {
            return base.ToString() + "-Pot" + PotNumber;
        }
    }
}