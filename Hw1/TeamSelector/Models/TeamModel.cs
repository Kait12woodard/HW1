
namespace TeamSelector.Models;

public class Team
{
    public List<string> Teammates { get; set; }

    public string TeamName { get; set; }

    public Team()
    {
        Teammates = new List<string>();
        TeamName = "";
    }
}
