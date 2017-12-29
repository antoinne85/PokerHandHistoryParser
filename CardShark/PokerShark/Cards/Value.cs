using System;
namespace PokerShark.Cards
{
	public enum Value
	{
		None = 0,

		[ShortName("2")]
		Two = 10,

		[ShortName("3")]
		Three = 11,

		[ShortName("4")]
		Four = 12,

		[ShortName("5")]
		Five = 13,

		[ShortName("6")]
		Six = 14,

		[ShortName("7")]
		Seven = 15,

		[ShortName("8")]
		Eight = 16,

		[ShortName("9")]
		Nine = 17,

		[ShortName("T")]
		Ten = 18,

		[ShortName("J")]
		Jack = 19,

		[ShortName("Q")]
		Queen = 20,

		[ShortName("K")]
		King = 21,

		[ShortName("A")]
		Ace = 22,
	}
}

