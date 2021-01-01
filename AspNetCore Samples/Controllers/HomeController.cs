using AspNetCore_Samples.Classes;
using AspNetCore_Samples.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AspNetCore_Samples.Controllers
{
    [Authorize(Policy = Constants.AuthorizationPolicies.RefreshAuthRequirement)]
    public class HomeController : ParentController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SetSiteMessage(MessageType.Success, DisplayFor.FullRequest, "Test Message");
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
}
