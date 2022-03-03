using Microsoft.AspNetCore.Mvc;

namespace Clear.CloudPlatform.WebUI.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
