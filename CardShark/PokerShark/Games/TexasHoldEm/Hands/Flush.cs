using System;
using System.Collections.Generic;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public class Flush : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"6{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"Flush ({Cards[0].Value} high)";
			}
		}

		public Flush(List<Card> cards) : base(cards)
		{
		}
	}
}
