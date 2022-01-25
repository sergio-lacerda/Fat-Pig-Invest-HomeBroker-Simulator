using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            this._empresaService = empresaService;
        }

        /// <summary>
        /// Obtém e retorna uma lista com os dados das empresas cadastradas.
        /// </summary>        
        /// <response code="200">Retorna uma lista das empresas com sucesso</response>
        /// <response code="204">Não há dados de empresas para retornar</response> 
        /// <response code="500">Erro Interno do Servidor. Contate o desenvolvedor.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaViewModel>>> listar()
        {
            try
            {
                var empresas = await _empresaService.listar();

                if (empresas.Count == 0)
                    return NoContent();

                return Ok(empresas); 
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
        /// Obtém e retorna os dados de uma empresa através do seu Id (código)
        /// </summary>
        /// /// <param name="idEmpresa">Id da empresa a ser obtida</param>        
        /// <response code="200">Retorna os dados da empresa com sucesso</response>
        /// <response code="204">Não há dados da empresa para esse idEmpresa</response> 
        /// <response code="500">Erro Interno do Servidor. Contate o desenvolvedor.</response>
        [HttpGet("{idEmpresa:int}")]
        public async Task<ActionResult<EmpresaViewModel>> obterPorId([FromRoute] int idEmpresa)
        {
            try
            {
                var empresa = await _empresaService.obterPorId(idEmpresa);

                if (empresa == null)
                    return NoContent();

                return Ok(empresa);
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
