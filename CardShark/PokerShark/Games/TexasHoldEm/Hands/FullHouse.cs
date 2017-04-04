using System.Collections.Generic;
using PokerShark.Cards;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Hands
{
	public class FullHouse : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"7{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"Full House: {Cards[0].Value}s full of {Cards[4].Value}s";
			}
		}

		public FullHouse(List<Card> cards) : base(cards)
		{
		}
	}
}
