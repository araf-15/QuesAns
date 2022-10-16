using Autofac;
using QuesAns.Models;
using QuesAns.Models.AccountModels;
using QuesAns.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuesAns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            //var model = Startup.AutofacContainer.Resolve<UserEmailOptionsModel>();
            //await model.SendTestEmail(model);

            return View();

            //var model = Startup.AutofacContainer.Resolve<IndexModel>();
            //try
            //{
            //    //model.Add();
            //    //model.GetAllProducts();
            //    model.Name = "Aser";
            //    //model.AddProduct();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Failed in test method");
            //}
            //return View(model);
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
