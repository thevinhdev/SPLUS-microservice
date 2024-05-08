using Microsoft.AspNetCore.Mvc;

namespace SPLUS.Common.Api.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
