using HomeBrokerClient.Models;
using HomeBrokerClient.Models.ViewModels;
using HomeBrokerClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeBrokerClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrdemService _ordemService;

        public HomeController(
                    ILogger<HomeController> logger,
                    IOrdemService ordemService
               )
        {
            _logger = logger;
            _ordemService = ordemService;
        }

        public async Task<IEnumerable<OrdemViewModel>> listarOrdens()
        {
            var ordens = await _ordemService.listar();
            return ordens;
        }

        public async Task<ActionResult> Index()
        {
            var ordens = await listarOrdens();
            
            ViewData["Ordens"] = ordens;
            
            return View();
        }

        public IActionResult Sobre()
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