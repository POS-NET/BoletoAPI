using BoletoAPI.Domain.Entities;
using FluentAssertions;
using System.Drawing;

namespace BoletoAPI.Domain.Tests
{
    public class BoletoTest
    {

        [Theory(DisplayName = "Dados do boleto válido")]
        [InlineData("4316", "2023-08-12", "109", 20.00, "2023-08-12", "2023-08-12")]
        public void ConstrutorBoleto_PassarDadosValidos_RetornaSucesso(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento)
        {
            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento);
            action.Should().NotThrow();
        }

        [InlineData(null, "2023-08-12", "109", 20.00, "2023-08-12", "2023-08-12")]
        [InlineData("", "2023-08-12", "109", 20.00, "2023-08-12", "2023-08-12")]
        [Theory(DisplayName = "Dados do boleto nulo ou vazio")]
        public void ConstrutorBoleto_PassarNossoNumeroNuloOuVazio_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento)
        {
            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento);
            action.Should().Throw<ArgumentException>().WithMessage("NossoNumero inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", null, 20.00, "2023-08-12", "2023-08-12")]
        [InlineData("4316", "2023-08-12", "", 20.00, "2023-08-12", "2023-08-12")]
        [Theory(DisplayName = "Dados do boleto nulo ou vazio")]
        public void ConstrutorBoleto_PassarNumeroDocumentoNuloOuVazio_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento)
        {
            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento);
            action.Should().Throw<ArgumentException>().WithMessage("NumeroDocumento inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", "138", 20.00, "2023-08-12", "2023-08-12")]
        [Theory(DisplayName = "Dados do boleto nulo ou vazio")]
        public void ConstrutorBoleto_PassarDataInvalida_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento)
        {
            vencimento = DateTime.MinValue;

            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento);
            action.Should().Throw<ArgumentException>().WithMessage($"Vencimento inválido: Data {vencimento} não esta no formato correto.");
        }

        [InlineData("4316", "2023-08-12", "138", 0.00, "2023-08-12", "2023-08-12")]
        [Theory(DisplayName = "Dados do boleto com valor menor que 10 ")]
        public void ConstrutorBoleto_PassarValorMenorQue10_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento)
        {
            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento);
            action.Should().Throw<ArgumentException>().WithMessage($"Valor deve ser maior do que R$ 10,00.");
        }

        [InlineData("4316", "2023-08-12", "109", 20.00, "2023-08-12", "2023-08-12")]
        [Theory(DisplayName = "Dados do boleto inválido, data emissão inválida")]
        public void ContrutorBoleto_PassarDataEmissaoInvalida_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento)
        {
            dataEmissao = DateTime.MinValue;

            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento);
            action.Should().Throw<ArgumentException>().WithMessage($"DataEmissao inválido: Data {dataEmissao} não esta no formato correto.");
        }

        [InlineData("4316", "2023-08-12", "109", 20.00, "2023-08-12", "2023-08-12")]
        [Theory(DisplayName = "Dados do boleto inválido, data emissão inválida")]
        public void ContrutorBoleto_PassarDataProcessamentoInvalida_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento)
        {
            dataProcessamento = DateTime.MinValue;

            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento);
            action.Should().Throw<ArgumentException>().WithMessage($"DataProcessamento inválido: Data {dataProcessamento} não esta no formato correto.");
        }
    }
}
