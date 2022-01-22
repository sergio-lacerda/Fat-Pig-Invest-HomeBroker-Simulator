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
    public class CorretoraController : Controller
    {
        private readonly ICorretoraService _corretoraService;

        public CorretoraController(ICorretoraService corretoraService)
        {
            this._corretoraService = corretoraService;
        }

        /// <summary>
        /// Obtém e retorna uma lista com os dados das corretoras cadastradas.
        /// </summary>        
        /// <response code="200">Retorna uma lista das corretoras com sucesso</response>
        /// <response code="204">Não há dados de corretoras para retornar</response> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorretoraViewModel>>> listar()
        {
            var corretoras = await _corretoraService.listar();

            if (corretoras.Count == 0)
                return NoContent();

            return Ok(corretoras);
        }

        /// <summary>
        /// Obtém e retorna os dados de uma corretora através do seu Id (código)
        /// </summary>
        /// /// <param name="idCorretora">Id da corretora a ser obtida</param>        
        /// <response code="200">Retorna os dados da corretora com sucesso</response>
        /// <response code="204">Não há dados da corretora para esse idCorretora</response> 
        [HttpGet("{idCorretora:int}")]
        public async Task<ActionResult<CorretoraViewModel>> obterPorId([FromRoute] int idCorretora)
        {
            var corretora = await _corretoraService.obterPorId(idCorretora);

            if (corretora == null)
                return NoContent();

            return Ok(corretora);
        }
    }
}
