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
	public class HighCardEvaluator : HandEvaluatorBase
	{
		public override string ToString()
		{
			return "High card";
		}

		protected override bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			var orderedCards = board.Flop
									.Concat(new List<Card> { board.Turn, board.River })
									.Concat(holeCards.Cards)
									.OrderByDescending(c => c.Value);

			hand = new HighCard(orderedCards.Take(5).ToList());
			return true;
		}
	}
}
