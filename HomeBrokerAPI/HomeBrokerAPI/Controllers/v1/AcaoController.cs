﻿using System;
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

        /// <summary>
        /// Obtém e retorna os dados de uma ação, com base em seu ticker
        /// </summary>
        /// /// <param name="ticker">Código (Ticker) da ação cujos dados se deseja obter</param>        
        /// <response code="200">Retorna os dados de uma ação com sucesso</response>
        /// <response code="204">Não há dados de ação para esse ticker</response> 
        [HttpGet("{ticker}")]
        public async Task<ActionResult<AcaoViewModel>> obterPorTicker([FromRoute] string ticker)
        {
            var acao = await _acaoService.obterPorTicker(ticker);

            if (acao == null)
                return NoContent();

            return Ok(acao);
        }
    }
}
