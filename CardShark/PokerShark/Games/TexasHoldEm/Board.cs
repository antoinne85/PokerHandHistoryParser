using System;
using System.Collections.Generic;
using System.Linq;
using PokerShark.Cards;

namespace Games.TexasHoldEm
{
	public class Board
	{
		public IReadOnlyList<Card> Flop
		{
			get;
			private set;
		} = new List<Card>();

		public Card Turn
		{
			get;
			private set;
		}

		public Card River
		{
			get;
			private set;
		}

		public Board()
		{
		}

		public Board(List<Card> cards)
		{
			if (cards.Count > 5)
				throw new ArgumentException("Too many cards on the board");

			Flop = cards.Take(3).ToList();

			if (cards.Count > 3)
			{
				Turn = cards.Skip(3).First();
			}

			if (cards.Count > 4)
			{
				Turn = cards.Skip(4).First();
			}
		}

		public void DealFlop(Card cardOne, Card cardTwo, Card cardThree)
		{
			if (cardThree == null)
				throw new ArgumentNullException(nameof(cardThree));
			
			if (cardTwo == null)
				throw new ArgumentNullException(nameof(cardTwo));
			
			if (cardOne == null)
				throw new ArgumentNullException(nameof(cardOne));

			if (Flop.Any())
				throw new Exception($"{nameof(Flop)} can only be dealt once");

			Flop = new List<Card> { cardOne, cardTwo, cardThree };
		}

		public void DealTurn(Card turn)
		{
			if (turn == null)
				throw new ArgumentNullException(nameof(turn));

			if (Turn != null)
				throw new Exception($"{nameof(Turn)} can only be dealt once");

			Turn = turn;
		}

		public void DealRiver(Card river)
		{
			if (river == null)
				throw new ArgumentNullException(nameof(river));

			if (River != null)
				throw new Exception($"{nameof(River)} can only be dealt once");

			River = river;
		}

		public void Clear()
		{
			Flop = new List<Card>();
			Turn = null;
			River = null;
		}

		public override string ToString()
		{
			return $"{string.Join(string.Empty, Flop.Select(c => c.ToShortString()))} {Turn.ToShortString()} {River.ToShortString()}";
		}
	}
}
