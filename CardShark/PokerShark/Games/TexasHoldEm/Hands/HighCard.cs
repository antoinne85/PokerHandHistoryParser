using System.Collections.Generic;
using PokerShark.Cards;
using System.Linq;

namespace PokerShark.Hands
{
	public class HighCard : FiveCardHand
	{
		public override long Value
		{
			get
			{
				return long.Parse($"1{base.Value}");
			}
		}

		public override string Description
		{
			get
			{
				return $"{Cards[0].Value} High";
			}
		}

		public HighCard(List<Card> cards) : base(cards)
		{
		}
	}
}
