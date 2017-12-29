using System;
using System.Collections.Generic;
using System.Linq;
using Games.TexasHoldEm;
using Games.TexasHoldEm.Evaluators;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace PokerShark.Games.TexasHoldEm.Evaluators
{
	public class StraightFlushEvaluator : HandEvaluatorBase
	{
		private List<Value> _legalStraights = new List<Value>
		{
			Value.Ace,
			Value.King,
			Value.Queen,
			Value.Jack,
			Value.Ten,
			Value.Nine,
			Value.Eight,
			Value.Seven,
			Value.Six,
			Value.Five,
			Value.Four,
			Value.Three,
			Value.Two,
			Value.Ace
		};

		public override string ToString()
		{
			return "Straight Flush";
		}

		protected override bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			hand = null;
			var orderedCards = board.Flop
									.Concat(new List<Card> { board.Turn, board.River })
									.Concat(holeCards.Cards)
									.OrderByDescending(c => c.Value)
									.ToList();

			var flush = orderedCards.GroupBy(c => c.Suit)
									.Where(grp => grp.Count() >= 5)
			                        .ToList();

			if (!flush.Any())
				return false;

			orderedCards = flush.First().ToList();

			// Aces should play high or low
			if (orderedCards.Any(c => c.Value == Value.Ace))
			{
				var aces = orderedCards
					.Where(c => c.Value == Value.Ace)
					.Select(c => new Card(c.Value, c.Suit))
					.ToList();

				orderedCards.AddRange(aces);
			}

			// Pull out each five card subset and check if it's a legal straight
			for (int i = 0; i < orderedCards.Count - 5; i++)
			{
				var cardsToCheck = orderedCards.Skip(i).Take(5).ToList();
				if (IsLegalStraight(cardsToCheck))
				{
					hand = new StraightFlush(cardsToCheck);
					return true;
				}
			}
			return false;
		}

		private bool IsLegalStraight(List<Card> cards)
		{
			var i = _legalStraights.FindIndex(v => v == cards.First().Value);
			foreach (var card in cards)
			{
				if (i >= _legalStraights.Count || card.Value != _legalStraights[i])
				{
					return false;
				}

				i++;
			}

			return true;
		}
	}
}
