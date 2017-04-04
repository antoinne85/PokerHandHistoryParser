using System;
using System.Collections.Generic;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public class ThreeOfAKind : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"4{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"Trip {Cards[0].Value}s ({Cards[3].Value} kicker)";
			}
		}

		public ThreeOfAKind(List<Card> cards) : base(cards)
		{
		}
	}
}
