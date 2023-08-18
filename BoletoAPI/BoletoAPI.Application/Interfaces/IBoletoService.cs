using BoletoAPI.Application.DTOs;

namespace BoletoAPI.Application.Interfaces
{
    public interface IBoletoService
    {
        Task<string> GerarHTMLBoleto(DadosBoletoDTO dadosBoletoDTO);
    }
}