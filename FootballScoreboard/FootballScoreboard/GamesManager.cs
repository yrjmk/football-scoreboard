﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballScoreboard
{
    public class GamesManager
    {
        private Dictionary<int, Game> _games = new Dictionary<int, Game>();

        public int StartGame(string homeTeamName, string awayTeamName)
        {
            int id = GetUniqueId();
            _games.Add(id, new Game(id, homeTeamName, awayTeamName));
            return id;
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

        private int GetUniqueId()
        {
            if (_games.Count == 0)
                return 1;

            int maxId = _games.Keys.Max();
            return maxId + 1;
        }
    }
}
