using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        /// <summary>
        /// Essa endpoint tem como finalidade de processar o layout do boleto do banco por tipo do banco.
        /// </summary>
        /// <remarks>
        /// **Importante:** Para consultar quais bancos estão homologado na lib do Boleto .NET CORE é imeportante que seja consultado no link: https://github.com/BoletoNet/BoletoNetCore
        ///
        /// Exemplo de corpo da requisição:
        /// 
        ///     {
        ///
        ///     "nossoNumero": "123456",
        ///     "vencimento": "2023-08-27T04:06:53.390Z",
        ///     "campoLivre": "123456",
        ///     "valor": 15.00,
        ///     "dataEmissao": "2023-08-27T04:06:53.390Z",
        ///     "dataProcessamento": "2023-08-27T04:06:53.390Z",
        ///     "tipoBanco": "Itau",
        ///     "numeroDocumento": "159",
        ///     "sacadoDTO": {
        ///       "nome": "Vicente Thales Gabriel Jesus",
        ///       "cpf": "552.050.440-71",
        ///       "enderecoDTO": {
        ///         "enderecoId": 0,
        ///         "cep": "29309-648",
        ///         "logradouro": "Escadaria Alphel Silva Madeira",
        ///         "numero": "724",
        ///         "bairro": "Rubem Braga",
        ///         "cidade": "Cachoeiro de Itapemirim",
        ///         "estado": "ES"
        ///       }
        ///     },
        ///     "beneficiarioDTO": {
        ///       "codigo": "11",
        ///       "codigoDV": "1",
        ///       "codigoFormatado": "1",
        ///       "codigoTransmissao": "1",
        ///       "cpfcnpj": "77065456000164",
        ///       "nome": "Sophie e Samuel Financeira Ltda",
        ///       "observacoes": "Teste de observações",
        ///       "contaBancariaDTO": {
        ///         "agencia": "6287",
        ///         "conta": "95116",
        ///         "carteiraPadrao": "109"
        ///       }
        ///      }
        ///     }   
        /// 
        /// </remarks>
        /// <param name="dadosBoletoDTO">Propriedades DTOs que devem ser preenchidas para consumo do boleto</param>
        /// <returns>Retorna o layout do boleto.</returns>
        [ProducesResponseType(typeof(DadosBoletoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> GetBoleto(DadosBoletoDTO dadosBoletoDTO)
        {
            var gerarHTMLBoleto = await _boletoService.GerarHTMLBoleto(dadosBoletoDTO);

            if (gerarHTMLBoleto == null)
                return BadRequest(gerarHTMLBoleto);

            return Ok(gerarHTMLBoleto);
        }
    }
}