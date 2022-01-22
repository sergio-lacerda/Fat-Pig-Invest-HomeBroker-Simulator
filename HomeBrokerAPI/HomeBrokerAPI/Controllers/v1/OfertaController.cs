﻿using System;
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

        /// <summary>
        /// Obtém e retorna o book de ofertas (ordens de compras e vendas) para uma ação, com base em seu ticker
        /// </summary>
        /// /// <param name="ticker">Código (Ticker) da ação cujas ofertas se deseja obter</param>        
        /// <response code="200">Retorna uma lista de ofertas (book) com sucesso</response>
        /// <response code="204">Não há dados da ofertas para esse ticker</response> 
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
