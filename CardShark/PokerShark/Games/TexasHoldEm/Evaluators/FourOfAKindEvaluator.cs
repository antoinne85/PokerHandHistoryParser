using System;
using System.Collections.Generic;
using System.Linq;
using Games.TexasHoldEm.Hands;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Evaluators
{
	public class FourOfAKindEvaluator : HandEvaluatorBase
	{

		public override string ToString()
		{
			return "Four of a Kind Evaluator";
		}

		protected override bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			hand = null;
			var quads = board.Flop
							 .Concat(new List<Card> { board.Turn, board.River })
							 .Concat(holeCards.Cards)
							 .GroupBy(c => c.Value)
							 .Where(grp => grp.Count() == 4);

			if (!quads.Any())
				return false;

			var orderedCards = board.Flop
									.Concat(new List<Card> { board.Turn, board.River })
									.Concat(holeCards.Cards)
									.Except(quads.First())
									.OrderByDescending(c => c.Value);

			hand = new FourOfAKind(quads.First().Concat(orderedCards.Take(1)).ToList());
 			return true;
		}
	}
}
