using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Base;

public class ApiControllerBase : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
