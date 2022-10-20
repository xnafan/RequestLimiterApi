using ApiClientWebsite.ApiServiceClient;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceClient _serviceClient;

        public HomeController(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public IActionResult Index()
        {
            string? result = "";
            try
            {
                result = _serviceClient.GetData();
                
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return View((object?)result);

        }
    }
}