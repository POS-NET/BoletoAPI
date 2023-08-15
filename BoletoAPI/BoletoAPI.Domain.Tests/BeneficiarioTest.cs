
using BoletoAPI.Domain.Entities;
using FluentAssertions;

namespace BoletoAPI.Domain.Tests
{
    public class BeneficiarioTest
    {
        [Theory(DisplayName = "Dados do beneficiario válidos")]
        [InlineData("1245", "1", "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        public void ConstrutorBeneficiario_PassarDadosValidos_RetornaSucesso(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().NotThrow();
        }

        [InlineData(null, "1", "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [InlineData("", "1", "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com código nulo ou vazio")]
        public void ConstrutorBeneficiario_PassarCodigoValorNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("Codigo inválido: Campo obrigatório."); ;
        }

        [InlineData("1245", null, "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [InlineData("1245", "", "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com código DV nulo ou vazio")]
        public void ConstrutorBeneficiario_PassarCodigoDVValorNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("CodigoDV inválido: Campo obrigatório."); ;
        }

        [InlineData("1245", "1", null, "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [InlineData("1245", "1", "", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com código formatado nulo ou vazio")]
        public void ConstrutorBeneficiario_PassarCodigoFormatadoValorNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("CodigoFormatado inválido: Campo obrigatório."); ;
        }

        [InlineData("1245", "1", "25", null, "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [InlineData("1245", "1", "25", "", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com código transmissao nulo ou vazio")]
        public void ConstrutorBeneficiario_PassarCodigoTransmissaoValorNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("CodigoTransmissao inválido: Campo obrigatório."); ;
        }

        [InlineData("1245", "1", "25", "11", null, "Jorge Antonio Santos", "Observações de teste")]
        [InlineData("1245", "1", "25", "11", "", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com CPF/CNPJ nulo ou vazio")]
        public void ConstrutorBeneficiario_PassarCPFCNPJValorNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("CPFCNPJ inválido: Utilize 11 dígitos para CPF ou 14 para CNPJ."); ;
        }

        [InlineData("1245", "1", "25", "11", "778.310.986-15123456", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com CPF/CNPJ maior que 14")]
        public void ConstrutorBeneficiario_PassarCPFCNPJMaiorQue14_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("CPFCNPJ inválido: Utilize 11 dígitos para CPF ou 14 para CNPJ."); ;
        }

        [InlineData("1245", "1", "25", "11", "778.310.986-15", null, "Observações de teste")]
        [InlineData("1245", "1", "25", "11", "778.310.986-15", "", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com nome vazio ou nulo")]
        public void ConstrutorBeneficiario_PassarNomeVazioOuNulo_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Nome é inválido, precisa ser pelo menos de 10 a 100 caracteres."); ;
        }

        [InlineData("1245", "1", "25", "11", "778.310.986-15", "Thi", "Observações de teste")]
        [InlineData("1245", "1", "25", "11", "778.310.986-15", "João João João João João João João João João João João João João João João João João João João Joãos ", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com nome menor do que 9 e maior que 100")]
        public void ConstrutorBeneficiario_PassarNomeMenorQue10EMaiorQue100_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Nome é inválido, precisa ser pelo menos de 10 a 100 caracteres."); ;
        }

        [InlineData("1245", "1", "25", "11", "778.310.986-15", "João Teste", null)]
        [InlineData("1245", "1", "25", "11", "778.310.986-15", "João Teste", "")]
        [Theory(DisplayName = "Dados do beneficiario com observações null ou vazio")]
        public void ConstrutorBeneficiario_PassarObservacoesNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Observacoes é inválido, campo obrigatório."); ;
        }


    }
}
