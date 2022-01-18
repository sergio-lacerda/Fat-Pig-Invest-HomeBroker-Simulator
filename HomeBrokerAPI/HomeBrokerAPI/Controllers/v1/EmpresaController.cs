using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HomeBrokerAPI.Services;
using HomeBrokerAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeBrokerAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            this._empresaService = empresaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaViewModel>>> listar()
        {
            var empresas = await _empresaService.listar();

            if (empresas.Count == 0)
                return NoContent();

            return Ok(empresas);            
        }

        [HttpGet("{idEmpresa:int}")]
        public async Task<ActionResult<EmpresaViewModel>> obterPorId([FromRoute] int idEmpresa)
        {
            var empresa = await _empresaService.obterPorId(idEmpresa);

            if (empresa == null)
                return NoContent();

            return Ok(empresa);
        }

    }
}
