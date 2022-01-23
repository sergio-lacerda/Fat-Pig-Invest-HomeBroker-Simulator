using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Services;
using HomeBrokerAPI.ViewModels;
using Microsoft.AspNetCore.Http;
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
        /// <response code="500">Erro Interno do Servidor. Contate o desenvolvedor.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorretoraViewModel>>> listar()
        {
            try
            {
                var corretoras = await _corretoraService.listar();

                if (corretoras.Count == 0)
                    return NoContent();

                return Ok(corretoras);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "[Erro Interno do Servidor : 500] Impossível processar a requisição. Tente novamente mais tarde!"
                );
            }
            
        }

        /// <summary>
        /// Obtém e retorna os dados de uma corretora através do seu Id (código)
        /// </summary>
        /// /// <param name="idCorretora">Id da corretora a ser obtida</param>        
        /// <response code="200">Retorna os dados da corretora com sucesso</response>
        /// <response code="204">Não há dados da corretora para esse idCorretora</response>
        /// <response code="500">Erro Interno do Servidor. Contate o desenvolvedor.</response>
        [HttpGet("{idCorretora:int}")]
        public async Task<ActionResult<CorretoraViewModel>> obterPorId([FromRoute] int idCorretora)
        {
            try
            {
                var corretora = await _corretoraService.obterPorId(idCorretora);

                if (corretora == null)
                    return NoContent();

                return Ok(corretora);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "[Erro Interno do Servidor : 500] Impossível processar a requisição. Tente novamente mais tarde!"
                );
            }            
        }
    }
}
