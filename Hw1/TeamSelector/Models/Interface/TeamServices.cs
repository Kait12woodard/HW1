using System.Linq;
using System.Collections.Generic;

namespace TeamSelector.Models.Interface
{
    public class TeamServices : IOperations
    {
        public DisplayTeam SeparateTeammateNames(TeamInputInfo input)
        {
            DisplayTeam displayTeams = new DisplayTeam();
            displayTeams.NumOfTeammates = (int)input.NumOfTeammates;

            //if (input.UnformatTeammates.Contains("\n\n"))
            //{
            //    throw new ArgumentException("No names were enter, please try again.");
            //}

            displayTeams.FormatTeammates = input.UnformatTeammates.Split('\n').ToList();

            return displayTeams;
        }

        public DisplayTeam ShuffleTeammateNames(DisplayTeam input)
        {
            // Source: https://thomassteffen.medium.com/super-simple-array-shuffle-with-linq-167b317ba035
            Random random = new Random();
            input.FormatTeammates = input.FormatTeammates.OrderBy(x => random.Next()).ToList();
            return input;

        }

        public DisplayTeam TeamSplitter(DisplayTeam input)
        {
            List<string> temp_list = new List<string>();
            for (int i = 0; i < input.FormatTeammates.Count; i++)
            {
                if (i % input.NumOfTeammates == 0 && i != 0)
                {
                    Team newTeam = new Team();
                    newTeam.Teammates = new List<string>(temp_list);
                    newTeam.TeamName = $"Team {i/input.NumOfTeammates}";
                    input.ListOfTeams.Add(newTeam);
                    temp_list.Clear();
                }
                temp_list.Add(input.FormatTeammates[i]);
                
            }
            
            if (temp_list.Count > 0)
            {
                Team newTeam = new Team();
                newTeam.Teammates = new List<string>(temp_list);
                newTeam.TeamName = $"Team {input.ListOfTeams.Count+1}";
                input.ListOfTeams.Add(newTeam);
            }

            return input;
        }

    }
}
