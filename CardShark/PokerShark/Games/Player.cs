using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerShark.Cards;
using PokerShark.Games.TexasHoldEm.Hands;
using PokerShark.Hands;

namespace PokerShark.Games
{
	public class Player
	{
		public HoleCards HoleCards
		{
			get;
			private set;
		}

		public IHoldEmHand Hand
		{
			get;
			set;
		}

		public string Name
		{
			get;
			private set;
		}

		public bool Winner
		{
			get;
			set;
		}

		public Player(string name)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			Name = name;
		}

		public void DealTo(Card card1, Card card2)
		{
			HoleCards = new HoleCards(new List<Card> { card1, card2 });
		}

		public void Reset()
		{
			HoleCards = null;
			Hand = null;
			Winner = false;
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			builder.AppendLine(Name);
			builder.AppendLine($"{string.Join(string.Empty, HoleCards.Cards.Select(c => c.ToShortString()))}");
			var decorator = string.Empty;
			if (Winner)
			{
				decorator = "**";
			}
			
			builder.AppendLine($"{decorator}{Hand.Description}{decorator}");
			return builder.ToString();
		}
	}
}
