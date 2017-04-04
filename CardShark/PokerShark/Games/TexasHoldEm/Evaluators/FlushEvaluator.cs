using System;
using System.Collections.Generic;
using System.Linq;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Evaluators
{
	public class FlushEvaluator : HandEvaluatorBase
	{

		public override string ToString()
		{
			return "Flush";
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
			                        .Where(grp => grp.Count() >= 5);

			if (!flush.Any())
				return false;

			hand = new Flush(flush.First().Take(5).ToList());
			return true;
		}
	}
}
