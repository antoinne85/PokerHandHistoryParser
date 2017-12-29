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
	public class PairEvaluator : HandEvaluatorBase
	{
		public override string ToString()
		{
			return "Pair";
		}

		protected override bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			hand = null;
			var pairs = board.Flop
			                 .Concat(new List<Card> { board.Turn, board.River })
			                 .Concat(holeCards.Cards)
			                 .GroupBy(c => c.Value)
			                 .Where(grp => grp.Count() == 2);

			if (!pairs.Any())
				return false;

			var orderedCards = board.Flop
									.Concat(new List<Card> { board.Turn, board.River })
									.Concat(holeCards.Cards)
			                        .Except(pairs.First())
									.OrderByDescending(c => c.Value);
			    
			hand = new Pair(pairs.First().Concat(orderedCards.Take(3)).ToList());
			return true;
		}
	}
}
