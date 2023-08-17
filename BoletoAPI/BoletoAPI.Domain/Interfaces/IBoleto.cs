using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBoleto
    {
        string RetornarHTML(DadosBoleto dadosBoleto);
    }
}