using System.Linq;
using System.Collections.Generic;
using Games.TexasHoldEm;
using Games.TexasHoldEm.Evaluators;
using PokerShark.Cards;
using PokerShark.Games;
using System;

namespace CardShark
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var evaluator = new HandEvaluator();
			var deck = new Deck();

			var players = new List<Player>{
				new Player("Player 1"),
				new Player("Player 2"),
				new Player("Player 3"),
				new Player("Player 4"),
				new Player("Player 5"),
				new Player("Player 6")
			};

			var board = new Board();

			while (true)
			{
				deck.Burn();
				board.DealFlop(deck.NextCard(), deck.NextCard(), deck.NextCard());

				deck.Burn();
				board.DealTurn(deck.NextCard());

				deck.Burn();
				board.DealRiver(deck.NextCard());

				//board.DealFlop(deck.DealCard(new Card(Value.Nine, Suit.Clubs)),
				//			   deck.DealCard(new Card(Value.Jack, Suit.Clubs)),
				//			   deck.DealCard(new Card(Value.Seven, Suit.Clubs)));
				//board.DealTurn(deck.DealCard(new Card(Value.Ten, Suit.Clubs)));
				//board.DealRiver(deck.DealCard(new Card(Value.Eight, Suit.Clubs)));

				//players[0].Reset();
				//players[0].DealTo(deck.DealCard(new Card(Value.Queen, Suit.Clubs)),
				//                  deck.DealCard(new Card(Value.Eight, Suit.Hearts)));

				//players[1].Reset();
				//players[1].DealTo(deck.DealCard(new Card(Value.Six, Suit.Clubs)),
				//                  deck.DealCard(new Card(Value.Jack, Suit.Hearts)));

				//players[2].Reset();
				//players[2].DealTo(deck.DealCard(new Card(Value.Three, Suit.Spades)),
				//                  deck.DealCard(new Card(Value.King, Suit.Hearts)));

				//players[3].Reset();
				//players[3].DealTo(deck.DealCard(new Card(Value.King, Suit.Spades)),
				//                  deck.DealCard(new Card(Value.Nine, Suit.Hearts)));

				//players[4].Reset();
				//players[4].DealTo(deck.DealCard(new Card(Value.King, Suit.Clubs)),
				//                  deck.DealCard(new Card(Value.Five, Suit.Hearts)));

				//players[5].Reset();
				//players[5].DealTo(deck.DealCard(new Card(Value.Ten, Suit.Spades)),
				//                  deck.DealCard(new Card(Value.Four, Suit.Hearts)));

				//for (int i = 0; i < 2; i++)
				//{
				for (int j = 0; j < players.Count; j++)
				{
					players[j].DealTo(deck.NextCard(), deck.NextCard());
				}
				//}

				foreach (var player in players)
				{
					player.Hand = evaluator.Evaluate(board, player.HoleCards);
				}

				var rankings = players.OrderByDescending(p => p.Hand.Value).ToList();
				var highHand = rankings.First().Hand.Value;
				var winners = rankings.Where(p => p.Hand.Value == highHand).ToList();

				foreach (var winner in winners)
				{
					winner.Winner = true;
				}

				var rareHand = false;
				Console.WriteLine(board);
				Console.WriteLine();
				foreach (var player in players)
				{
					Console.WriteLine(player);
					if (player.Hand.Description.Contains("Straight Flush") ||
						player.Hand.Description.Contains("Royal Flush") ||
						player.Hand.Description.Contains("Quad") ||
						winners.Count > 1)
						rareHand = true;
				}

				Console.WriteLine("_____________________");
				Console.WriteLine();

				foreach (var player in players)
				{
					player.Reset();
				}
				board.Clear();
				deck.Shuffle();

				if (rareHand)
					Console.ReadKey();
			}

			//var calculator = new MonteCarloEquityCalculator();

			//var player1 = new Player("Player 1");
			//var player2 = new Player("Player 2");

			//player1.Reset();
			//player1.DealTo(new Card(Value.Ace, Suit.Clubs), new Card(Value.King, Suit.Clubs));

			//player2.Reset();
			//player2.DealTo(new Card(Value.Ace, Suit.Hearts), new Card(Value.King, Suit.Diamonds));

			//calculator.Run(player1, player2);
			//Console.ReadKey();
		}
	}
}
