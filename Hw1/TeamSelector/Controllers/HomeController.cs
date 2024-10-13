using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TeamSelector.Models;
using TeamSelector.Models.Interface;

namespace TeamSelector.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //Links MovieServices to be used
    private readonly IOperations _operationServices = new TeamServices();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    //sets up page and waits for input
    [HttpGet]
    public IActionResult TeamView()
    {
        return View();
        
    }
    //separates teammates names, shuffles them and stores them into teams
    [HttpPost]
    public IActionResult TeamDisplayView(TeamInputInfo storeinfo)
    {
        if (ModelState.IsValid)
        {
            DisplayTeam processedInfo = new DisplayTeam();
            processedInfo = _operationServices.SeparateTeammateNames(storeinfo);
            processedInfo = _operationServices.ShuffleTeammateNames(processedInfo);
            processedInfo = _operationServices.TeamSplitter(processedInfo);
            return View(processedInfo);
        }
        else
        {
            return View("TeamView", storeinfo);
        }

    }

    [HttpGet]
    public IActionResult Form()
    {
        return View("TeamVIew");
    }
}

