using AccessControlService.Application.Users.Queries.GetUsers;
using AccessControlService.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestPresentation.Models;

namespace TestPresentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var request = new GetUserListQuery
            {
                Query = null
            };
            var vm = await _mediator.Send(request);
            return View(vm);
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