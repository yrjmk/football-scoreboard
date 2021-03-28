using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FootballScoreboard.UnitTests
{
    public class ScoreboardTests
    {
        private GamesManager _gamesManager;

        private readonly List<(string homeName, string awayName, uint homeScore, uint awayScore)>
            _testSource = new List<(string, string, uint, uint)>
                {
                    ("Mexico", "Canada", 0, 5),
                    ("Spain" , "Brazil", 10 , 2),
                    ("Germany" , "France", 2 , 2),
                    ("Uruguay" , "Italy", 6 , 6),
                    ("Argentina" , "Australia", 3 , 1)
                };

        private readonly List<(string homeName, string awayName, uint homeScore, uint awayScore)>
            _getSummaryExpectedResult = new List<(string, string, uint, uint)>
                {
                    ("Uruguay" , "Italy", 6 , 6),
                    ("Spain" , "Brazil", 10 , 2),
                    ("Mexico", "Canada", 0, 5),
                    ("Argentina" , "Australia", 3 , 1),
                    ("Germany" , "France", 2 , 2)   
                };

        [SetUp]
        public void Setup()
        {
            _gamesManager = new GamesManager();
        }

        [Test]
        public void StartGame_SingleGame_SetZeroScore()
        {
            int id = _gamesManager.StartGame("Home Team", "Away Team");
            Game game = _gamesManager.GetSummary().Find(x => x.Id == id);

            Assert.Multiple(() =>
               {
                   Assert.Zero(game.HomeTeam.Score);
                   Assert.Zero(game.AwayTeam.Score);
               });
        }

        [Test]
        public void StartGame_MultipleGames_ReturnsUniqueId()
        {
            List<int> ids = new List<int>();

            foreach (var source in _testSource)
            {
                ids.Add(_gamesManager.StartGame(source.homeName, source.awayName));
            }

            Assert.That(ids, Is.Unique);
        }

        [Test]
        public void StartGame_WithNoTeamNames_ThrowsArgumentException(
            [Values(null, "", " ")] string homeTeam,
            [Values(null, "", " ")] string awayTeam)
        {
            Assert.Throws<ArgumentException>(
                () => _gamesManager.StartGame(homeTeam, awayTeam));
        }

        [Test]
        public void UpdateGameScore_ExistingGame_UpdatesScore(
            [Values(0, 1, 2)] uint homeScore,
            [Values(3, 4, 5)] uint awayScore)
        {
            int id = _gamesManager.StartGame("Home Team", "Away Team");

            _gamesManager.UpdateGameScore(id, homeScore, awayScore);
            Game game = _gamesManager.GetSummary().Find(x => x.Id == id);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(homeScore, game.HomeTeam.Score);
                Assert.AreEqual(awayScore, game.AwayTeam.Score);
                Assert.AreEqual(homeScore + awayScore, game.TotalScore);
            });
        }

        [Test]
        public void UpdateGameScore_AbsentGame_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() =>
                _gamesManager.UpdateGameScore(5, 2, 3));
        }

        [Test]
        public void FinishGame_ExistingGame_RemovesGame()
        {
            int id = _gamesManager.StartGame("Home Team", "Away Team");

            _gamesManager.FinishGame(id);

            Game game = _gamesManager.GetSummary().FirstOrDefault(x => x.Id == id);
            Assert.IsNull(game);
        }

        [Test]
        public void FinishGame_AbsentGame_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() =>
                 _gamesManager.FinishGame(4));
        }

        [Test]
        public void GetSummary_NoGames_ReturnsEmptyList()
        {
            List<Game> games = _gamesManager.GetSummary();
            Assert.Zero(games.Count);
        }

        [Test]
        public void GetSummary_HaveGames_ReturnsGamesListOrderedByTotalScoreAndStartDate()
        {
            foreach (var source in _testSource)
            {
                int id = _gamesManager.StartGame(source.homeName, source.awayName);
                _gamesManager.UpdateGameScore(id, source.homeScore, source.awayScore);
            }

            var _getSummaryResult =
                _gamesManager.GetSummary()
                    .Select(x => new Tuple<string, string, uint, uint>
                        (x.HomeTeam.Name, x.AwayTeam.Name, x.HomeTeam.Score, x.AwayTeam.Score))
                    .ToList();

            CollectionAssert.AreEqual(_getSummaryExpectedResult, _getSummaryResult);
        }
    }
}