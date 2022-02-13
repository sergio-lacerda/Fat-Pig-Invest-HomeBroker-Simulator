using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.InputModel;
using HomeBrokerAPI.Services;
using HomeBrokerAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBrokerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class OrdemController : Controller
    {
        private readonly IOrdemService _ordemService;

        public OrdemController(IOrdemService ordemService)
        {
            this._ordemService = ordemService;
        }

        /// <summary>
        /// Obtém e retorna os dados das ordens emitidas pelo usuário, com base em sua conta
        /// </summary>
        /// /// <param name="conta">Conta cujas ordens se deseja obter</param>        
        /// <response code="200">Retorna uma lista das ordens com sucesso</response>
        /// <response code="204">Não há dados de ordens para essa conta</response> 
        /// <response code="500">Erro Interno do Servidor. Contate o desenvolvedor.</response>
        [HttpGet("{conta}")]
        public async Task<ActionResult<IEnumerable<OrdemViewModel>>> listar([FromRoute] string conta)
        {
            var strConta = conta.Split("-");
            if (strConta.Length != 2)
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    "[Erro de Cliente: 400] Formato incorreto de Conta!"
                );

            try
            {
                var ordens = await _ordemService.listar(conta);

                if (ordens.Count == 0)
                    return NoContent();

                return Ok(ordens);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "[Erro Interno do Servidor : 500] Impossível processar a requisição. Tente novamente mais tarde!"
                );
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrdemViewModel>> inserir([FromBody] OrdemInputModel ordem)
        {
            try
            {
                var auxOrdem = await _ordemService.inserir(ordem);
                return Ok(ordem);
            }
            catch (Exception)
            {
                return UnprocessableEntity("Não foi possível registar essa ordem!");
            }            
        }

    }
}
