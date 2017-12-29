using System;
using System.Collections.Generic;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public class StraightFlush : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"9{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return Cards[0].Value == PokerShark.Cards.Value.Ace 
					           ? $"Royal Flush ({Cards[0].Suit})" 
					           : $"Straight Flush: {Cards[0].ToShortString()} to {Cards[4].ToShortString()}";
			}
		}

		public StraightFlush(List<Card> cards) : base(cards)
		{
		}
	}
}
