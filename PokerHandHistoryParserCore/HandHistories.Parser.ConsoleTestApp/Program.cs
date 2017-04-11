using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using HandHistories.Objects.GameDescription;
using HandHistories.Parser.Parsers.Factory;
using HandHistories.Parser.Parsers.FastParser.Base;

namespace HandHistories.Parser.ConsoleTestApp
{
	internal class Program
	{
		public static void Main(string[] args)
		{
            //var parserFactory = new HandHistoryParserFactoryImpl();
            //var parser = parserFactory.GetFullHandHistoryParser(SiteName.PokerStars);
            //var file = @"C:\GitHubProjects\PokerHandHistoryParser\HandHistories.Parser.UnitTests\SampleHandHistories\PokerStars\CashGame\Tables\Table6.txt";
            //var text = File.ReadAllText(file);
            //var handHistory = parser.ParseFullHandHistory(text, true);

            //var extractorFactory = new StatExtractorFactory();
            //var extractors = extractorFactory.CreateExtractors(handHistory).ToList();

            //foreach (var action in handHistory.HandActions)
            //{
            //    foreach (var extractor in extractors)
            //    {
            //        extractor.ProcessAction(action);
            //    }
            //}

            //var playerStats = handHistory.Players.Where(p => !p.IsSittingOut).Select(p => new PlayerStats
            //{
            //    Player = p.PlayerName
            //}).ToList();

            //foreach (var extractor in extractors)
            //{
            //    foreach (var stat in playerStats)
            //    {
            //        extractor.ApplyResult(stat);
            //    }
            //}

            IHandHistoryParserFactory factory = new HandHistoryParserFactoryImpl();
            var handParser = factory.GetFullHandHistoryParser(SiteName.PokerStars);

            try
            {
            	var handText = File.ReadAllText(@"/Users/daveo/Projects/PokerMonkey/Hand History Files/PokerStars (Converted from Ignition)/FullRing/BovadaHandHistory_Holdem_NL_201703121143447916611.txt");

            	int parsedHands = 0;
            	Stopwatch SW = new Stopwatch();
            	SW.Start();

            	HandHistoryParserFastImpl fastParser = handParser as HandHistoryParserFastImpl;

            	var hands = fastParser.SplitUpMultipleHandsToLines(handText);
            	foreach (var hand in hands)
            	{
            		var parsedHand = fastParser.ParseFullHandHistory(hand, true);
            		parsedHands++;
            	}

            	SW.Stop();

            	Console.WriteLine("Parsed " + parsedHands + " hands." + Math.Round(SW.Elapsed.TotalMilliseconds, 2) + "ms");
            }
            catch (Exception ex)
            {
            	Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace, "Error");
            }
        }
	}
}