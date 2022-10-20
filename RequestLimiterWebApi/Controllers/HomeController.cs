using Microsoft.AspNetCore.Mvc;

namespace RequestCounterWebApi.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult<string> Index()
        {
            return Ok("Thanks for visiting");
        }
    }
}
