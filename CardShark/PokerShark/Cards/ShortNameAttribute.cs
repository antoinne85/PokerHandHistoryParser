using System;
namespace PokerShark
{
	public class ShortNameAttribute : Attribute
	{
		public string ShortName
		{
			get;
			private set;
		}

		public ShortNameAttribute(string shortName)
		{
			if (shortName == null) throw new ArgumentException(nameof(shortName));

			ShortName = shortName;
		}
	}
}
