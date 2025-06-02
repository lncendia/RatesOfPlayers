using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RatesOfPlayers.Infrastructure.Web.Home.Models;

namespace RatesOfPlayers.Infrastructure.Web.Home.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}