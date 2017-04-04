using System;
using System.Collections.Generic;
using System.Linq;
using PokerShark.Cards;

namespace PokerShark.Games.TexasHoldEm.Hands
{
	public class HoleCards
	{
		public IReadOnlyList<Card> Cards
		{
			get;
		}
		public HoleCards(List<Card> cards)
		{
			if (cards == null)
				throw new ArgumentNullException(nameof(cards));

			if (cards.Count != 2)
				throw new ArgumentException("Wrong number of hole cards");

			Cards = cards;
		}

		public override string ToString()
		{
			return $"{string.Join(string.Empty, Cards.Select(c => c.ToShortString()))}";
		}
	}
}
