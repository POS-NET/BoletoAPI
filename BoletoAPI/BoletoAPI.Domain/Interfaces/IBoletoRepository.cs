using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBoletoRepository
    {
        Task<string> RetornarHTML(DadosBoleto dadosBoleto);
    }
}