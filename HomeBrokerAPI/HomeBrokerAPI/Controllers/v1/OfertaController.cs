using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Services;
using HomeBrokerAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeBrokerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OfertaController : Controller
    {
        private readonly IOfertaService _ofertaService;

        public OfertaController(IOfertaService ofertaService)
        {
            this._ofertaService = ofertaService;
        }

        [HttpGet("{ticker}")]
        public async Task<ActionResult<IEnumerable<OfertaViewModel>>> listar([FromRoute]string ticker)
        {
            var ofertas = await _ofertaService.listar(ticker);

            if (ofertas == null)
                return NoContent();

            return Ok(ofertas);
        }
    }
}
