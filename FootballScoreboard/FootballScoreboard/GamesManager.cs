using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballScoreboard
{
    public class GamesManager
    {
        private Dictionary<int, Game> _games = new Dictionary<int, Game>();

        public int StartGame(string homeTeamName, string awayTeamName)
        {
            _games.Add(0, new Game(homeTeamName, awayTeamName));
            return 0;
        }

        public void UpdateGameScore(int id, uint homeScore, uint awayScore)
        {
            throw new NotImplementedException();
        }

        public void FinishGame(int id)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetSummary()
        {
            return _games.Values.ToList();
        }
    }
}
