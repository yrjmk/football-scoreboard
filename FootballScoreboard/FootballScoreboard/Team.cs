namespace FootballScoreboard
{
    public class Team
    {
        public string Name { get; private set; }
        public uint Score { get; private set; }

        public Team(string name)
        {
            Name = name;
            Score = 0;
        }

        public void UpdateScore(uint score)
        {
            Score = score;
        }
    }
}
