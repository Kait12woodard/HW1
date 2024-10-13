using System;

namespace TeamSelector.Models.Interface
{
    public interface IOperations
    {
        //Designed for taking a list of names separating on "\n". Returns formatted list of names
        DisplayTeam SeparateTeammateNames(TeamInputInfo input);
        //Designed for shuffling the Teammates names. Returns same formatted list but shuffled
        DisplayTeam ShuffleTeammateNames(DisplayTeam input);
        //Designed to take shuffled list of names and curate teams. Returns w/ list of teams
        DisplayTeam TeamSplitter(DisplayTeam input);
    }
}
