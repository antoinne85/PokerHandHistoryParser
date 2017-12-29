using System;
using System.Collections.Generic;
using System.Linq;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Evaluators
{
	public class ThreeOfAKindEvaluator : HandEvaluatorBase
	{
		public override string ToString()
		{
			return "Trips";
		}

		protected override bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			hand = null;
			var trips = board.Flop
							 .Concat(new List<Card> { board.Turn, board.River })
							 .Concat(holeCards.Cards)
							 .GroupBy(c => c.Value)
							 .Where(grp => grp.Count() == 3);

			if (!trips.Any())
				return false;

			var orderedCards = board.Flop
									.Concat(new List<Card> { board.Turn, board.River })
									.Concat(holeCards.Cards)
									.Except(trips.First())
									.OrderByDescending(c => c.Value);

			hand = new ThreeOfAKind(trips.First().Concat(orderedCards.Take(2)).ToList());
			return true;
		}
	}
}
