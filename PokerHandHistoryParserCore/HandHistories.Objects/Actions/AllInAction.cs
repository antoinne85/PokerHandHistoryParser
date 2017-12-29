using HandHistories.Objects.Cards;

namespace HandHistories.Objects.Actions
{
    public class AllInAction : HandAction
    {        
        public bool IsRaiseAllIn { get; private set; }

        public AllInAction(string playerName,
                           decimal amount,
                           Street street,
                           bool isRaiseAllIn,
                           int actionNumber = 0)
            : base(playerName, HandActionType.RAISE, amount, street, true, actionNumber)
        {
            IsRaiseAllIn = isRaiseAllIn;
            if (!isRaiseAllIn)
            {
                HandActionType = Actions.HandActionType.BET;
            }
        }
    }
}