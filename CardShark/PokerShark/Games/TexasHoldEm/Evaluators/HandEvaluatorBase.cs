using System;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace Games.TexasHoldEm.Evaluators
{
	public abstract class HandEvaluatorBase
	{
		public bool TryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand)
		{
			if (board == null)
				throw new ArgumentNullException(nameof(board));

			if (holeCards == null)
				throw new ArgumentNullException(nameof(holeCards));

			return InternalTryEvaluate(board, holeCards, out hand);
		}

		public abstract override string ToString();
		protected abstract bool InternalTryEvaluate(Board board, HoleCards holeCards, out IHoldEmHand hand);
	}
}
