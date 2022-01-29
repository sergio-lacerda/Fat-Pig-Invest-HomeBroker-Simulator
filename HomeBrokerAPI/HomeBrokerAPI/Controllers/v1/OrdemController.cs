using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("{conta}")]
        public async Task<ActionResult<IEnumerable<OrdemViewModel>>> listar([FromRoute] string conta)
        {
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
    }
}
