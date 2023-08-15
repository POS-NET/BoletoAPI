using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBoleto
    {
        Task<string> RetornarHTML(DadosBoleto dadosBoleto);
    }
}