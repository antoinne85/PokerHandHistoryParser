using System;
namespace PokerShark.Cards
{
	public class Card
	{
		public Suit Suit
		{
			get;
			private set;
		}

		public Value Value
		{
			get;
			private set;
		}

		public Card(Value value, Suit suit)
		{
			if (value == Value.None) throw new ArgumentException(nameof(value));
			if (suit == Suit.None) throw new ArgumentException(nameof(suit));

			Value = value;
			Suit = suit;
		}

		public override string ToString()
		{
			return $"{Value} of {Suit}";
		}

		public string ToShortString()
		{
			return $"{GetShortName(typeof(Value), Value.ToString())}{GetShortName(typeof(Suit), Suit.ToString())}";
			                                   	
		}

		private string GetShortName(Type @enum, string memberName)
		{
			var attributes = @enum.GetMember(memberName)[0]
										 .GetCustomAttributes(typeof(ShortNameAttribute), false);
			return ((ShortNameAttribute)attributes[0]).ShortName;
		}
	}
}
