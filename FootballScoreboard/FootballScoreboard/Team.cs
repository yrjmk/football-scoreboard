using System;

namespace FootballScoreboard
{
    public class Team
    {
        public string Name { get; private set; }
        public uint Score { get; private set; }

        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name can not be empty.");

            Name = name;
            Score = 0;
        }

        public void UpdateScore(uint score)
        {
            Score = score;
        }
    }
}
