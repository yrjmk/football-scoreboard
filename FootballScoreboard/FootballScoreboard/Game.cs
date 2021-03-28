namespace FootballScoreboard
{
    public class Game
    {
        public int Id { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team AwayTeam { get; private set; }
        public uint TotalScore => HomeTeam.Score + AwayTeam.Score;

        public Game(int id, string homeTeamName, string awayTeamName)
        {
            Id = id;
            HomeTeam = new Team(homeTeamName);
            AwayTeam = new Team(awayTeamName);
        }

        public void UpdateScore(uint homeScore, uint awayScore)
        {
            HomeTeam.UpdateScore(homeScore);
            AwayTeam.UpdateScore(awayScore);
        }
    }
}
