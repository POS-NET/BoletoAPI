using BoletoAPI.Domain.Entities;
using FluentAssertions;

namespace BoletoAPI.Domain.Tests
{
    public class ContaBancariaTest
    {
        [Theory(DisplayName = "Conta bancária com dados válidos")]
        [InlineData("4316", "33180-2", "109")]
        public void ConstrutorContaBancaria_PassarDadosValidos_RetornaSucesso(string agencia, string conta, string carteiraPadrao)
        {
            Action action = () => new ContaBancaria(agencia, conta, carteiraPadrao);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Conta bancária com agencia vazio ou nulo")]
        [InlineData(null, "33180-2", "109")]
        public void ContrutorEndereco_PassarAgenciaVazioNulo_RetornarException(string agencia, string conta, string carteiraPadrao)
        {
            Action action = () => new ContaBancaria(agencia, conta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("Agencia inválida: O campo deve ter um tamanho de 4 a 5 digitos.");
        }

        [InlineData("258456", "33180-2", "109")]
        [InlineData("000", "33180-2", "109")]
        [Theory(DisplayName = "Conta bancária com agencia maior que 5 e menor que 4")]
        public void ContrutorEndereco_PassarAgenciaComValorMaiorQue5EMenorQue4_RetornarException(string agencia, string conta, string carteiraPadrao)
        {
            Action action = () => new ContaBancaria(agencia, conta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("Agencia inválida: O campo deve ter um tamanho de 4 a 5 digitos.");
        }

        [InlineData("0000", null, "109")]
        [Theory(DisplayName = "Conta bancária com conta nula ou vazia")]
        public void ContrutorEndereco_PassarContaComValorNullouVazio_RetornarException(string agencia, string conta, string carteiraPadrao)
        {
            Action action = () => new ContaBancaria(agencia, conta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("Conta inválido: Campo obrigatório.");
        }

        [InlineData("0000", "33180", null)]
        [Theory(DisplayName = "Conta bancária com conta nula ou vazia")]
        public void ContrutorEndereco_PassarCarteiraPadraoComValorNullouVazio_RetornarException(string agencia, string conta, string carteiraPadrao)
        {
            Action action = () => new ContaBancaria(agencia, conta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("CarteiraPadrao inválido: O campo é obrigatório");
        }
    }
}
