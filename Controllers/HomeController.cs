using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MultiLanguge.Models;

namespace MultiLanguge.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<HomeController> stringLocalizer;

    public HomeController(ILogger<HomeController> logger,IStringLocalizer<HomeController> _stringLocalizer)
    {
        _logger = logger;
        stringLocalizer = _stringLocalizer;
    }

    public IActionResult Index()
    {
        ViewBag.MyTitle = stringLocalizer["Title"];
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

    [HttpPost]
    public IActionResult ChangeLanguge(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(7)
            }
            );
        return LocalRedirect(returnUrl);
    }

}
