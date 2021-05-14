using Microsoft.AspNetCore.Mvc;

namespace LiteSmallConference.Api.Controllers
{
    public class ZEsDeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
