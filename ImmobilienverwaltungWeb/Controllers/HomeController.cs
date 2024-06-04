using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ImmobilienverwaltungWeb.Models;
using ImmobilienverwaltungWeb.Repositories;

namespace ImmobilienverwaltungWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ImmobilienRepository repo = new ImmobilienRepository();
        List<Immobilien> myImmobilien = repo.GetAllImmobiliens();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}