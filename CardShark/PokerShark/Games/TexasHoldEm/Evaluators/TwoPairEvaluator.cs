using System;
using System.Collections.Generic;
using System.Linq;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Evaluators
{
	public class TwoPairEvaluator : HandEvaluatorBase
	{
		public override string ToString()
		{
			return "Two pair";
		}

		protected override bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			hand = null;
			var pairs = board.Flop
							 .Concat(new List<Card> { board.Turn, board.River })
							 .Concat(holeCards.Cards)
							 .GroupBy(c => c.Value)
							 .Where(grp => grp.Count() == 2)
			                 .OrderByDescending(grp => grp.First().Value);

			if (pairs.Count() < 2)
				return false;

			var orderedCards = board.Flop
									.Concat(new List<Card> { board.Turn, board.River })
									.Concat(holeCards.Cards)
									.Except(pairs.Take(2).SelectMany(c => c))
									.OrderByDescending(c => c.Value);

			hand = new TwoPair(pairs.Take(2).SelectMany(c => c).Concat(orderedCards.Take(1)).ToList());
			return true;
		}
	}
}
