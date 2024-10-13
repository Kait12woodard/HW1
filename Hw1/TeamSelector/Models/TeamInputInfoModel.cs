
using System.ComponentModel.DataAnnotations;

namespace TeamSelector.Models;

public class TeamInputInfo
{
    [Required(ErrorMessage = "No names were enter, please try again.")]
    [RegularExpression(@"^(?![\s\n]*$)[a-zA-Z,.\-_'\s]*$", 
        ErrorMessage = "Only letters and , . - _ ' are permitted. Rememeber one name per line and " +
        "no extra emptylines. Please try again.")]
    public string UnformatTeammates { get; set; }
    [Required(ErrorMessage = "Please select a number between 2 and 10.")]
    [Range(2, 10, ErrorMessage = "Please pick the amount of teammates between 2 and 10.")]
    public int? NumOfTeammates { get; set; }

    public TeamInputInfo()
    {
        UnformatTeammates = "";
        NumOfTeammates = 0;
    }

}
