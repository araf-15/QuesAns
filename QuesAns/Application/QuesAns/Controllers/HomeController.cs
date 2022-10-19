using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuesAns.Models;
using QuesAns.Models.AccountModels;
using QuesAns.Services.Contracts;
using QuesAnsLib.Services.Implementations;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuesAns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly ICashService<string, UserVM> _iCashService;

        public HomeController(ILogger<HomeController> logger,
                              IEmailService emailService,
                              ICashService<string, UserVM> iCashService)
        {
            _logger = logger;
            _emailService = emailService;
            _iCashService = iCashService;
        }

        public async Task<IActionResult> Index()
        {
            var model = Startup.AutofacContainer.Resolve<UserVM>();
            try
            {
                model.LoadExistingUserToCash();
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load data");
                return View();
            }
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
