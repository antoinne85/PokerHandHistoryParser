using System;
namespace PokerShark.Cards
{
	public enum Suit
	{
		None = 0,

		[ShortName("c")]
		Clubs = 1,

		[ShortName("d")]
		Diamonds = 2,

		[ShortName("h")]
		Hearts = 3, 

		[ShortName("s")]
		Spades = 4
	}
}
