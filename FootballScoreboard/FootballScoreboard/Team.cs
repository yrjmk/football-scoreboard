namespace FootballScoreboard
{
    public class Team
    {
        public string Name { get; set; }
        public uint Score { get; set; }

        public Team(string name)
        {
            Name = name;
            Score = 0;
        }
    }
}
