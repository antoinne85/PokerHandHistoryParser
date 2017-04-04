using System;
using System.Collections.Generic;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public class TwoPair : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"3{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"Two pair: {Cards[0].Value}s and {Cards[2].Value}s ({Cards[4].Value} kicker)";
			}
		}

		public TwoPair(List<Card> cards) : base(cards)
		{
		}
	}
}
