using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoletoAPI.Apresentation.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoletosController : ControllerBase
    {
        private readonly IBoletoService _boletoService;

        public BoletosController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpPost]
        public async Task<IActionResult> GetBoleto(DadosBoletoDTO dadosBoletoDTO)
        {
            var gerarHTMLBoleto = await _boletoService.GerarHTMLBoleto(dadosBoletoDTO);
            return Ok(gerarHTMLBoleto);
        }
    }
}