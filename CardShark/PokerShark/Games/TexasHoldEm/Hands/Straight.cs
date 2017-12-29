using System;
using System.Collections.Generic;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public class Straight : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"5{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"Straight: {Cards[0].Value} to {Cards[4].Value}";
			}
		}

		public Straight(List<Card> cards) : base(cards)
		{
		}
	}
}
