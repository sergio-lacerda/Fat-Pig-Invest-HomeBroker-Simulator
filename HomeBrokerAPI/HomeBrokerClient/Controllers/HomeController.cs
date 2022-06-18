﻿using HomeBrokerClient.Models;
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
        private readonly IOfertaService _ofertaService;
        private readonly ICarteiraService _carteiraService;

        public HomeController(
                    ILogger<HomeController> logger,
                    IOrdemService ordemService,
                    IOfertaService ofertaService,
                    ICarteiraService carteiraService
               )
        {
            _logger = logger;
            _ordemService = ordemService;
            _ofertaService = ofertaService;
            _carteiraService = carteiraService;
        }

        private async Task<IEnumerable<OrdemViewModel>> listarOrdens()
        {
            var ordens = await _ordemService.listar();
            return ordens;
        }

        private async Task<IEnumerable<OfertaTabelaViewModel>> listarOfertas(string ticker)
        {
            var ofertas = await _ofertaService.listar(ticker);

            List<OfertaTabelaViewModel> tabela = new List<OfertaTabelaViewModel>();

            List<OfertaViewModel> ofertasCompra = ofertas.Where(
                    oferta => oferta.Tipo == 'C'
                ).Take(5).ToList();

            List<OfertaViewModel> ofertasVenda = ofertas.Where(
                    oferta => oferta.Tipo == 'V'
                ).Take(5).ToList();

            if (ofertasCompra.Count >= 5 && ofertasVenda.Count >= 5)
                for (int i = 0; i < 5; i++)
                    tabela.Add(new OfertaTabelaViewModel
                        {
                            Corretora_Compra =
                                ofertasCompra[i].Corretora.Length > 15 ?
                                ofertasCompra[i].Corretora.Substring(0,14) :
                                ofertasCompra[i].Corretora,                            
                            Quantidade_Compra = ofertasCompra[i].Quantidade,
                            Valor_Compra = ofertasCompra[i].Valor,
                            Corretora_Venda =
                                ofertasVenda[i].Corretora.Length > 15 ?
                                ofertasVenda[i].Corretora.Substring(0, 14) :
                                ofertasVenda[i].Corretora,
                        Quantidade_Venda = ofertasVenda[i].Quantidade,
                            Valor_Venda = ofertasVenda[i].Valor
                        }
                    );

            return tabela;
        }

        private async Task<IEnumerable<CarteiraViewModel>> listarCarteira()
        {
            var carteira = await _carteiraService.listar();
            return carteira;
        }

        public async Task<ActionResult> Index()
        {
            //Getting my orders
            var ordens = await listarOrdens();            
            ViewData["Ordens"] = ordens;

            //Getting general offers
            var ofertas = await listarOfertas("");
            ViewData["Ofertas"] = ofertas;

            //Getting my stocks
            var carteira = await listarCarteira();
            ViewData["Carteira"] = carteira;

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

        /*-------------- Partial Views -----------------*/
                
        public async Task<PartialViewResult> pvMinhasAcoes()
        {
            //Getting my stocks
            var carteira = await listarCarteira();
            ViewData["Carteira"] = carteira;
            return PartialView("_MinhasAcoesPartialView");
        }

        public async Task<PartialViewResult> pvOfertas()
        {
            //Checking for ticker parameter at Route 
            var valoresRota = HttpContext.Request.RouteValues.Values;
            string ticker = "";

            if (valoresRota.Count >= 3 && valoresRota.ElementAt(1).ToString() == "pvOfertas")
                ticker = valoresRota.ElementAt(2).ToString();

            //Getting general offers
            var ofertas = await listarOfertas(ticker);
            ViewData["Ofertas"] = ofertas;            
            return PartialView("_OfertasPartialView");
        }

        public async Task<PartialViewResult> pvOrdens()
        {
            //Getting my orders
            var ordens = await listarOrdens();
            ViewData["Ordens"] = ordens;
            return PartialView("_OrdensPartialView");
        }
    }
}