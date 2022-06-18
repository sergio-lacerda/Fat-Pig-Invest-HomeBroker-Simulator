using HomeBrokerAPI.Services;
using HomeBrokerAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarteiraController : Controller
    {
        private readonly ICarteiraService _carteiraService;

        public CarteiraController(ICarteiraService carteiraService)
        {
            this._carteiraService = carteiraService;
        }

        /// <summary>
        /// Obtém e retorna os dados das ações da carteira do usuário, com base em sua conta
        /// </summary>
        /// /// <param name="conta">Conta cujas ações (carteira) se deseja obter</param>        
        /// <response code="200">Retorna uma lista das ações (carteira) com sucesso</response>
        /// <response code="204">Não há dados de ações (carteira) para essa conta</response> 
        /// <response code="500">Erro Interno do Servidor. Contate o desenvolvedor.</response>
        [HttpGet("{conta}")]
        public async Task<ActionResult<IEnumerable<CarteiraViewModel>>> listar([FromRoute] string conta)
        {
            var strConta = conta.Split("-");
            if (strConta.Length != 2)
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    "[Erro de Cliente: 400] Formato incorreto de Conta!"
                );

            try
            {
                var acoes = await _carteiraService.listar(conta);

                if (acoes.Count == 0)
                    return NoContent();

                return Ok(acoes);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "[Erro Interno do Servidor : 500] Impossível processar a requisição. Tente novamente mais tarde!"
                );
            }
        }
    }
}
