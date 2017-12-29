using System;
using System.Collections.Generic;
using System.Linq;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public abstract class FiveCardHand : IHoldEmHand
	{
		public List<Card> Cards { get; }

		public virtual long Value
		{
			get
			{
				return long.Parse(string.Join(string.Empty, Cards.Select(c => ((int)c.Value).ToString())));
			}
		}

		public abstract string Description { get; }

		public FiveCardHand(List<Card> cards)
		{
			if (cards == null)
				throw new ArgumentNullException(nameof(cards));

			if (cards.Count != 5)
				throw new ArgumentException("Invalid number of cards");

			Cards = new List<Card>(cards);
		}
	}
}
