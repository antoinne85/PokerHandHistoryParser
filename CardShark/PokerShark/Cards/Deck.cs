using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerShark.Cards
{
	public class Deck
	{
		private readonly HashSet<int> _dealtCards = new HashSet<int>();
		private Random _rnd;
		private List<Card> _cards
		{
			get;
			set;
		} = new List<Card>
			{
				new Card(Value.Ace, Suit.Clubs),
				new Card(Value.Two, Suit.Clubs),
				new Card(Value.Three, Suit.Clubs),
				new Card(Value.Four, Suit.Clubs),
				new Card(Value.Five, Suit.Clubs),
				new Card(Value.Six, Suit.Clubs),
				new Card(Value.Seven, Suit.Clubs),
				new Card(Value.Eight, Suit.Clubs),
				new Card(Value.Nine, Suit.Clubs),
				new Card(Value.Ten, Suit.Clubs),
				new Card(Value.Jack, Suit.Clubs),
				new Card(Value.Queen, Suit.Clubs),
				new Card(Value.King, Suit.Clubs),

				new Card(Value.Ace, Suit.Diamonds),
				new Card(Value.Two, Suit.Diamonds),
				new Card(Value.Three, Suit.Diamonds),
				new Card(Value.Four, Suit.Diamonds),
				new Card(Value.Five, Suit.Diamonds),
				new Card(Value.Six, Suit.Diamonds),
				new Card(Value.Seven, Suit.Diamonds),
				new Card(Value.Eight, Suit.Diamonds),
				new Card(Value.Nine, Suit.Diamonds),
				new Card(Value.Ten, Suit.Diamonds),
				new Card(Value.Jack, Suit.Diamonds),
				new Card(Value.Queen, Suit.Diamonds),
				new Card(Value.King, Suit.Diamonds),

				new Card(Value.Ace, Suit.Hearts),
				new Card(Value.Two, Suit.Hearts),
				new Card(Value.Three, Suit.Hearts),
				new Card(Value.Four, Suit.Hearts),
				new Card(Value.Five, Suit.Hearts),
				new Card(Value.Six, Suit.Hearts),
				new Card(Value.Seven, Suit.Hearts),
				new Card(Value.Eight, Suit.Hearts),
				new Card(Value.Nine, Suit.Hearts),
				new Card(Value.Ten, Suit.Hearts),
				new Card(Value.Jack, Suit.Hearts),
				new Card(Value.Queen, Suit.Hearts),
				new Card(Value.King, Suit.Hearts),

				new Card(Value.Ace, Suit.Spades),
				new Card(Value.Two, Suit.Spades),
				new Card(Value.Three, Suit.Spades),
				new Card(Value.Four, Suit.Spades),
				new Card(Value.Five, Suit.Spades),
				new Card(Value.Six, Suit.Spades),
				new Card(Value.Seven, Suit.Spades),
				new Card(Value.Eight, Suit.Spades),
				new Card(Value.Nine, Suit.Spades),
				new Card(Value.Ten, Suit.Spades),
				new Card(Value.Jack, Suit.Spades),
				new Card(Value.Queen, Suit.Spades),
				new Card(Value.King, Suit.Spades)
			};

		public Deck()
		{
			Shuffle();
		}

		public void Shuffle()
		{
			Shuffle(new List<Card>());
		}

		public void Shuffle(List<Card> omittedCards)
		{
			_dealtCards.Clear();

			foreach (var card in omittedCards)
			{
				DealCard(card);
			}

			_rnd = new Random(Guid.NewGuid().GetHashCode());
		}

		public Card NextCard()
		{
			if (_dealtCards.Count == _cards.Count)
			{
				throw new Exception("Empty deck");
			}

			int cardIndex;
			while (true)
			{
				var i = _rnd.Next(0, _cards.Count);
				if (!_dealtCards.Contains(i))
				{
					cardIndex = i;
					_dealtCards.Add(i);
					break;
				}
			}

			return _cards[cardIndex];
		}

		public void Burn()
		{
			NextCard();
		}

		public Card DealCard(Card card)
		{
			var cardFromDeck = _cards.First(c => c.Value == card.Value && c.Suit == card.Suit);
			_dealtCards.Add(_cards.IndexOf(cardFromDeck));

			return cardFromDeck;
		}
	}
}
