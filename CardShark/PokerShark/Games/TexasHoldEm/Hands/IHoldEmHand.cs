using System.Collections.Generic;
using PokerShark.Cards;

namespace PokerShark.Hands
{
	public interface IHoldEmHand
	{
		long Value { get; }
		string Description { get; }
		List<Card> Cards { get; }
	}
}
