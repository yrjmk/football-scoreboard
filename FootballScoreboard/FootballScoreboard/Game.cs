namespace FootballScoreboard
{
    public class Game
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public uint TotalScore { get; set; }

        public Game(int id, string homeTeamName, string awayTeamName)
        {
            Id = id;
            HomeTeam = new Team(homeTeamName);
            AwayTeam = new Team(awayTeamName);
        }
    }
}
