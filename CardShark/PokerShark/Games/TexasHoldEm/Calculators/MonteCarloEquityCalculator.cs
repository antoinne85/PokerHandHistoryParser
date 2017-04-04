using System;
using System.Linq;
using Games.TexasHoldEm;
using Games.TexasHoldEm.Evaluators;
using PokerShark.Cards;
using PokerShark.Games;

namespace PokerShark.Games.TexasHoldEm.Calculators
{
	public class MonteCarloEquityCalculator
	{
		private readonly HandEvaluator _evaluator;
		private readonly Deck _deck;
		private readonly Board _board;
		private const int _runCount = 20000;

		public MonteCarloEquityCalculator()
		{
			_evaluator = new HandEvaluator();
			_deck = new Deck();
			_board = new Board();
		}

		public void Run(params Player[] players)
		{
			var stats = players.ToDictionary(p => p.Name, p => new Stat());

			for (int i = 0; i < _runCount; i++)
			{
				_board.Clear();
				_deck.Shuffle(players.SelectMany(p => p.HoleCards.Cards).ToList());

				_deck.Burn();
				_board.DealFlop(_deck.NextCard(), _deck.NextCard(), _deck.NextCard());

				_deck.Burn();
				_board.DealTurn(_deck.NextCard());

				_deck.Burn();
				_board.DealRiver(_deck.NextCard());

				foreach (var player in players)
				{
					player.Hand = _evaluator.Evaluate(_board, player.HoleCards);
				}

				var rankings = players.OrderByDescending(p => p.Hand.Value).ToList();

				var highHand = rankings.First().Hand.Value;
				var winners = rankings.Where(p => p.Hand.Value == highHand).ToList();

				if (winners.Count > 1)
				{
					foreach (var player in winners)
					{
						stats[player.Name].Chop++;
					}
				}
				else
				{
					stats[winners.Single().Name].Won++;
				}

				foreach (var player in rankings.Except(winners))
				{
					stats[player.Name].Lost++;
				}
			}

			foreach (var player in players)
			{
				var wonPct = ((double)stats[player.Name].Won / _runCount) * 100;
				var chopPct = ((double)stats[player.Name].Chop / _runCount) * 100;

				Console.WriteLine($"{player.HoleCards.ToString()}  {wonPct}%" 
				                  + (stats[player.Name].Chop > 0 ? $" Chop: {chopPct}%" : string.Empty));
			}
		}

		private class Stat
		{
			public int Won
			{
				get;
				set;
			}

			public int Lost
			{
				get;
				set;
			}

			public int Chop
			{
				get;
				set;
			}
		}
	}
}
