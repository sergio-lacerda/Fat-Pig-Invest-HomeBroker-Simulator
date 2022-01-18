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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorretoraViewModel>>> listar()
        {
            var corretoras = await _corretoraService.listar();

            if (corretoras.Count == 0)
                return NoContent();

            return Ok(corretoras);
        }

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
