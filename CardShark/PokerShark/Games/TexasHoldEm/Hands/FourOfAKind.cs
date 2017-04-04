using System;
using System.Collections.Generic;
using PokerShark.Cards;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Hands
{
	public class FourOfAKind : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"8{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"Quad {Cards[0].Value}s";
			}
		}

		public FourOfAKind(List<Card> cards) : base(cards)
		{
		}
	}
}
