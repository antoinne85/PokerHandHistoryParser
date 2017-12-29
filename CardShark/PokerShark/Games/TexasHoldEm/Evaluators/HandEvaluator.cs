using System;
using System.Collections.Generic;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Evaluators;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Evaluators
{
	public class HandEvaluator
	{
		private readonly List<HandEvaluatorBase> _evaluators = new List<HandEvaluatorBase>
		{
			new StraightFlushEvaluator(),
			new FourOfAKindEvaluator(),
			new FullHouseEvaluator(),
			new FlushEvaluator(),
			new StraightEvaluator(),
			new ThreeOfAKindEvaluator(),
			new TwoPairEvaluator(),
			new PairEvaluator(),
			new HighCardEvaluator()
		};

		public IHoldEmHand Evaluate(Board board, HoleCards holeCards)
		{
			foreach (var evaluator in _evaluators)
			{
				IHoldEmHand hand;
				if (evaluator.TryEvaluate(board, holeCards, out hand)){
					return hand;
				}
			}

			throw new Exception("Unable to evaluate to a legal poker hand");
		}
	}
}
