using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandHistories.Objects.GameDescription;
using HandHistories.Parser.Parsers.Factory;
using PokerMonkey.Stats;
using PokerMonkey.Stats.Hands.Extractors;
using PokerMonkey.Stats.Models;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var parserFactory = new HandHistoryParserFactoryImpl();
            var parser = parserFactory.GetFullHandHistoryParser(SiteName.PokerStars);
            var file = @"C:\GitHubProjects\PokerHandHistoryParser\HandHistories.Parser.UnitTests\SampleHandHistories\PokerStars\CashGame\Tables\Table6.txt";
            var text = File.ReadAllText(file);
            var handHistory = parser.ParseFullHandHistory(text, true);

            var extractorFactory = new StatExtractorFactory();
            var extractors = extractorFactory.CreateExtractors(handHistory).ToList();

            foreach (var action in handHistory.HandActions)
            {
                foreach (var extractor in extractors)
                {
                    extractor.ProcessAction(action);
                }
            }

            var playerStats = handHistory.Players.Where(p => !p.IsSittingOut).Select(p => new PlayerStats
            {
                Player = p.PlayerName
            }).ToList();

            foreach (var extractor in extractors)
            {
                foreach (var stat in playerStats)
                {
                    extractor.ApplyResult(stat);
                }
            }
        }
    }
}
