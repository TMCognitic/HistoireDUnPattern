using FinalDemo.Models;
using FinalDemo.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;
        private readonly TransientService _transientService;

        public HomeController(ILogger<HomeController> logger, SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            _logger = logger;
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        public IActionResult Index()
        {
            ViewBag.SingletonByInjection = $"Singleton by Injection HashCode : {_singletonService.GetHashCode()}";
            ViewBag.Singleton = $"Singleton HashCode : {HttpContext.RequestServices.GetService(typeof(SingletonService))?.GetHashCode()}";

            ViewBag.ScopedByInjection = $"Scoped by Injection HashCode : {_scopedService.GetHashCode()}";
            ViewBag.Scoped = $"Scoped HashCode : {HttpContext.RequestServices.GetService(typeof(ScopedService))?.GetHashCode()}";

            ViewBag.TransientByInjection = $"Transient by Injection HashCode : {_transientService.GetHashCode()}";
            ViewBag.Transient = $"Transient HashCode : {HttpContext.RequestServices.GetService(typeof(TransientService))?.GetHashCode()}";

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
