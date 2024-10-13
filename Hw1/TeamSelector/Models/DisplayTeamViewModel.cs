namespace TeamSelector.Models
{
    public class DisplayTeam
    {
        public List<string> FormatTeammates { get; set; }
        public List<Team> ListOfTeams { get; set; }
        public int NumOfTeammates { get; set; }

        public DisplayTeam()
        {
            FormatTeammates = new List<string>();
            ListOfTeams = new List<Team>();
            NumOfTeammates = 0;
        }
    }

}
