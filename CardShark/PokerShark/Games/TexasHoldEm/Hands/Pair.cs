using System;
using System.Collections.Generic;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public class Pair : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"2{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"Pair of {Cards[0].Value}s ({Cards[2].Value} kicker)";
			}
		}

		public Pair(List<Card> cards) : base(cards)
		{
		}
	}
}
