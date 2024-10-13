using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamSelector;
using TeamSelector.Models;
using TeamSelector.Models.Interface;

namespace TeamSelector_Tests;

public class TeamSelectorTests
{
    private IOperations _operationServices;
    private TeamInputInfo _input;

    [SetUp]
    public void Setup()
    {
        _operationServices = new TeamServices();

        string names = "Michael Scott  \r\nJim Halpert  \r\nPam Beesly  " +
            "\r\nDwight Schrute  \r\nLeslie Knope  \r\nRon Swanson  \r\nApril Ludgate" +
            "  \r\nAndy Dwyer  \r\nJake Peralta  \r\nRosa Diaz  \r\nCharles Boyle" +
            "  \r\nTerry Jeffords  \r\nRaymond Holt  \r\nElaine Benes  \r\nGeorge Costanza" +
            "  \r\nJerry Seinfeld  \r\nKramer  \r\nMonica Geller  \r\nRoss Geller " +
            " \r\nRachel Green  \r\nChandler Bing  \r\nJoey Tribbiani  \r\nSheldon Cooper " +
            " \r\nLeonard Hofstadter  \r\nPenny  \r\nHoward Wolowitz  \r\nRaj Koothrappali  " +
            "\r\nTim Taylor  \r\nJill Taylor  \r\nAl Borland  \r\nWill Smith  \r\nCarlton Banks" +
            "  \r\nUncle Phil  \r\nHomer Simpson  \r\nMarge Simpson  \r\nBart Simpson  " +
            "\r\nLisa Simpson  \r\nPeter Griffin  \r\nLois Griffin  \r\nStewie Griffin  " +
            "\r\nAl Bundy  \r\nPeggy Bundy  \r\nSteve Urkel  \r\nDanny Tanner  \r\nJoey Gladstone" +
            "  \r\nJesse Katsopolis  \r\nFran Fine  \r\nMax Sheffield  \r\nMary Richards " +
            " \r\nLou Grant  \r\nLucy Ricardo";

        int num = 5;

        _input = new TeamInputInfo
        {
            UnformatTeammates = names,
            NumOfTeammates = num
        };
    }

    /*----------------------------------
     * Testing: SeparateTeammateNames()
     * Best Case: Successfully take user 
     * input and parse it to FormatTeammates
     * and copy NumOfTeammates into DisplayTeam
     * Type.
     * Expect: result.FormatTeammates = List<string>
     * result.NumOfTeammates = 5
     * result type = DisplayTeam
     * --------------------------------*/

    [Test]
    public void Test_BestCase_SeparateTeammateNames_TransfersCorrectly()
    {
        // Arrange
        Setup();

        // Act
        var result = _operationServices.SeparateTeammateNames(_input);


        // Assert
        Assert.IsInstanceOf<List<string>>(result.FormatTeammates);
        Assert.AreEqual(5,_input.NumOfTeammates);
        Assert.IsInstanceOf<DisplayTeam>(result);

    }

    /*----------------------------------
     * Testing: ShuffleTeammateNames()
     * Best Case: Successfully shuffles 
     * FormTeammates.
     * Expect: after.FormatTeammates should
     * not be equal to before.FormatTeammates
     * after shuffle is performed.
     * --------------------------------*/
    [Test]
    public void Test_BestCase_ShuffleTeammateNames_ShufflesCorrectly()
    {
        // Arrange
        Setup();

        // Act
        DisplayTeam result = _operationServices.SeparateTeammateNames(_input);
        List<string> before = new List<string>(result.FormatTeammates);
        _operationServices.ShuffleTeammateNames(result);
        List<string> after = new List<string>(result.FormatTeammates);


        // Assert (Intelsense suggestion)
        Assert.AreNotEqual(after, before);

    }

    /*----------------------------------
     * Testing: ShuffleTeammateNames()
     * Confirms that the method shuffles the
     * names everytime its called.
     * Expect: first.FormatTeammates should
     * not be equal to second.FormatTeammates
     * and third.FormatTeammates isn't equal to
     * second.FormatTeamates after the shuffles 
     * is performed.
     * --------------------------------*/
    [Test]
    public void Test_BestCase_ShuffleTeammateNames_ShufflesRandomlyCorrectly()
    {
        // Arrange
        Setup();

        // Act
        DisplayTeam result = _operationServices.SeparateTeammateNames(_input);
        List<string> first = new List<string>(result.FormatTeammates);
         _operationServices.ShuffleTeammateNames(result);
        List<string> second = new List<string>(result.FormatTeammates);
         _operationServices.ShuffleTeammateNames(result);
        List<string> third = new List<string>(result.FormatTeammates);

        // Assert (Intelsense suggestion)
        Assert.That(first, Is.Not.EqualTo(second));
        Assert.That(second, Is.Not.EqualTo(third));

    }

    /*----------------------------------
     * Testing: TeamSplitter()
     * Best Case: Successfully creates a List<Team>
     * with the FormatTeammatesNames. It also assigns
     * boring team names.
     * Expect: DisplayTeam will have a full
     * list of Team types.
     * --------------------------------*/

    [Test]
    public void Test_BestCase_TeamSplitter_CreatesTeamsCorrectly()
    {
        // Arrange
        Setup();

        // Act
        DisplayTeam result = _operationServices.SeparateTeammateNames(_input);
        result = _operationServices.ShuffleTeammateNames(result);
        result = _operationServices.TeamSplitter(result);

        // Assert
        Assert.IsInstanceOf<List<Team>>(result.ListOfTeams);

    }


}