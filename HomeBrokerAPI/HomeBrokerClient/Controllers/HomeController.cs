using HomeBrokerClient.Models;
using HomeBrokerClient.Models.InputModels;
using HomeBrokerClient.Models.ViewModels;
using HomeBrokerClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace HomeBrokerClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrdemService _ordemService;
        private readonly IOfertaService _ofertaService;
        private readonly ICarteiraService _carteiraService;
        private readonly IConfiguration _configuration;

        public HomeController(
                    ILogger<HomeController> logger,
                    IOrdemService ordemService,
                    IOfertaService ofertaService,
                    ICarteiraService carteiraService,
                    IConfiguration configuration
               )
        {
            _logger = logger;
            _ordemService = ordemService;
            _ofertaService = ofertaService;
            _carteiraService = carteiraService;
            _configuration = configuration;
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

        public async Task<IActionResult> Nota()
        {
            //Getting my orders
            var ordens = await listarOrdens();

            //Preparing datamodel
            var totalVendas = ordens.Where(o => o.Tipo == 'V').Sum(o => o.Total);
            var totalCompras = ordens.Where(o => o.Tipo == 'C').Sum(o => o.Total);
            var totalOper = totalCompras + totalVendas;
            var liqOperacoes = totalVendas - totalCompras;
            var taxaLiq = totalOper * 0.0275 / 100;  //0.0275%;
            var totCBLC = liqOperacoes < 0 ? liqOperacoes + taxaLiq : liqOperacoes - taxaLiq;
            var emol = totalOper * 0.005 / 100;  //0.005%
            var totBolsa = emol;
            var corret = 0.00;
            var iss = corret * 5 / 100;  //5%
            var totDespCorr = corret + iss;
            var liqNota = totCBLC + totBolsa + totDespCorr;

            NotaViewModel nota = new NotaViewModel
                {
                    NumeroNota = new Random().Next(0, 100000),
                    Pregao = DateTime.Now,
                    CodigoCliente = 696969,
                    NomeCliente = "Zuleika da Silva",
                    CpfCliente = "069.069.069-69",
                    Endereco = "Rua Suspeita, 69",
                    Bairro = "Terreno Baldio",
                    Cep = "69.069-69",
                    Municipio = "Só Deus Sabe",
                    UF = "AC",
                    Ordens = ordens,
                    VendasAVista = totalVendas,
                    ComprasAVista = totalCompras,
                    TotalOperacoes = totalOper,
                    LiquidoOperacoes = liqOperacoes,
                    TaxaLiquidacao = taxaLiq,
                    TotalCBLC = totCBLC,
                    Emolumentos = emol,
                    TotalBolsa = totBolsa,
                    Corretagem = corret,
                    ISS = iss,
                    TotalCorretagemDespesas = totDespCorr,
                    LiquidoNota = liqNota,
                    VenctoNota = DateTime.Now.AddDays(2)
            };

            //ViewData["Nota"] = nota;

            return View(nota);
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
                
        public async Task<string> enviarOrdens([FromBody] OrdemInputModel ordem)
        {            
            ordem.IdCorretora = _configuration.GetValue<int>("UsuarioLogado:IdCorretora");
            ordem.Conta = _configuration.GetValue<int>("UsuarioLogado:NumeroConta");

            var insOrdem = await _ordemService.adicionarOrdem(ordem);

            int status = (int)HttpStatusCode.OK;
                        
            if (insOrdem == null)
                status = (int)HttpStatusCode.NoContent;

            return JsonSerializer.Serialize(status);
        }
    }
}