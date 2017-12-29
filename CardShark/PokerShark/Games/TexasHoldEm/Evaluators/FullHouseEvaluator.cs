using System;
using System.Collections.Generic;
using System.Linq;
using Games.TexasHoldEm.Hands;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Evaluators
{
	public class FullHouseEvaluator : HandEvaluatorBase
	{

		public override string ToString()
		{
			return "Boat";
		}

		protected override bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			hand = null;
			var orderedCards = board.Flop
									.Concat(new List<Card> { board.Turn, board.River })
									.Concat(holeCards.Cards)
									.OrderByDescending(c => c.Value)
									.ToList();

			var pairs = orderedCards.GroupBy(c => c.Value)
									.Where(grp => grp.Count() >= 2)
									.OrderByDescending(grp => grp.Count())
			                        .ThenByDescending(grp => grp.First().Value)
			                        .ToList();

			if (pairs.Count() < 2 || pairs.All(grp => grp.Count() < 3))
				return false;

			var trips = pairs[0].Take(3);
			var pair = pairs[1].Take(2);

			hand = new FullHouse(trips.Concat(pair).ToList());
			return true;
		}
	}
}
