using BoletoAPI.Domain.Entities;
using FluentAssertions;

namespace BoletoAPI.Domain.Tests
{
    public class EnderecoTest
    {
        [Theory(DisplayName = "Endereço com dados válidos")]
        [InlineData("78149-218", "Rua Santa Mônica", "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ConstrutorEndereco_PassarDadosValidos_RetornaSucesso(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Endereço com CEP vazio ou nulo")]
        [InlineData(null, "Rua Santa Mônica", "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarCEPVazioNulo_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo CEP deve conter 9 digitos");
        }

        [Theory(DisplayName = "Endereço com CEP diferente de 9")]
        [InlineData("123", "Rua Santa Mônica", "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarCEPDiferenteDe9_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo CEP deve conter 9 digitos");
        }

        [Theory(DisplayName = "Endereço com logradouro vazio ou nulo")]
        [InlineData("12402-010", null, "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarLogradouroVazioOuNulo_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Logradouro teve ter no mínimo 10 e no máximo 100 caracteres.");
        }

        [Theory(DisplayName = "Endereço com logradouro com valor menor que 10")]
        [InlineData("12402-010", "teste", "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarLogradouroValorMenor10_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Logradouro teve ter no mínimo 10 e no máximo 100 caracteres.");
        }

        [Theory(DisplayName = "Endereço com logradouro com valor maior que 100")]
        [InlineData("12402-010", "testetestetestetestetes tetesteteste testetestet estetestete stetestetes tetestetesteteste stetestetes tetestetesteteste", "123", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarLogradouroValorMaior10_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Logradouro teve ter no mínimo 10 e no máximo 100 caracteres.");
        }

        [Theory(DisplayName = "Endereço com número com valor null ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", null, "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarNumeroValorNullOuVazio_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Numero deve conter até 5 digitos.");
        }

        [Theory(DisplayName = "Endereço com número com valor maior que 5")]
        [InlineData("12402-010", "Rua Santa Mônica", "123456", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassaNumeroValorMaiorQue5_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Numero deve conter até 5 digitos.");
        }

        [Theory(DisplayName = "Endereço com bairro com valor nulo ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", null, "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarBairroValorNuloOuVazio_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Bairro deve ser até 50 caracteres.");
        }

        [Theory(DisplayName = "Endereço bairro com valor maior que 50")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", "bairro bairro bairro bairro bairro bairro bairro bairro bairro bairro bairro bairro bairro ", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarBairroMaiorQue50_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Bairro deve ser até 50 caracteres.");
        }

        [Theory(DisplayName = "Endereço cidade com valor nulo ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", "Rua Vicência Cotinha de Carvalho Valadares", null, "MT")]
        public void ContrutorEndereco_PassarCidadeNulaOuVazia_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Cidade deve ser até 50 caracteres.");
        }

        [Theory(DisplayName = "Endereço cidade com valor maior que 50")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", "Rua Vicência Cotinha de Carvalho Valadares", "Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida Aparecida ", "MT")]
        public void ContrutorEndereco_PassarCidadeComValorMaiorQue50_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Cidade deve ser até 50 caracteres.");
        }

        [Theory(DisplayName = "Endereço estado com valor nulo ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", "Rua Vicência Cotinha de Carvalho Valadares", "Pindamonhangaba", null)]
        public void ContrutorEndereco_PassarEstadoNullOuVazio_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Estado deve conter 2 digitos.");
        }

        [Theory(DisplayName = "Endereço estado com valor maior que 2")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", "Rua Vicência Cotinha de Carvalho Valadares", "Aparecida", "São")]
        public void ContrutorEndereco_PassarEstadoComValorMaiorQue2_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Estado deve conter 2 digitos.");
        }

    }
}
