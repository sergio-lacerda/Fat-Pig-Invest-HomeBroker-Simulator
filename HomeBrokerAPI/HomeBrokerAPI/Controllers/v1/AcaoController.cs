using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Services;
using HomeBrokerAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeBrokerAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AcaoController : Controller
    {
        private readonly IAcaoService _acaoService;

        public AcaoController(IAcaoService acaoService)
        {
            this._acaoService = acaoService;
        }

        [HttpGet("{ticker}")]
        public async Task<ActionResult<AcaoViewModel>> obterPorTicker([FromRoute] string ticker)
        {
            var acao = await _acaoService.obterPorTicker(ticker);

            if (acao == null)
                return NoContent();

            return Ok(acao);
        }

        [HttpGet("PrecoMedio/{ticker}")]
        public async Task<ActionResult<double>> precoMedio([FromRoute] string ticker)
        {
            var preco = await _acaoService.precoMedio(ticker);
            return Ok(preco);
        }
    }
}
