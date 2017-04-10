using HandHistories.Objects.Actions;

namespace PokerMonkey.Stats
{
    public static class Extensions
    {
        public static bool IsBlind(this HandActionType actionType)
        {
            return actionType == HandActionType.BIG_BLIND || actionType == HandActionType.SMALL_BLIND;
        }
    }
}