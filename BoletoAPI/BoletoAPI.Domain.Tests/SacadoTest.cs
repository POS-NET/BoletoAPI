
using BoletoAPI.Domain.Entities;
using FluentAssertions;

namespace BoletoAPI.Domain.Tests
{
    public class SacadoTest
    {
        [Theory(DisplayName = "Contrutores com dados válidos")]
        [InlineData("Bento Ruan Freitas", "745.187.253-01")]
        public void Empresa_PassarValidacaoValida_RetornarDadosConstrutor(string nome, string cpf)
        {
            Action action = () => new Sacado(nome, cpf);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Construtor com nome invalido")]
        [InlineData(null, "637.341.869-35")]
        public void ConstrutorSacado_PassarValorNulo_RetornarException(string nome, string cpf)
        {
            Action action = () => new Sacado(nome, cpf);
            action.Should().Throw<ArgumentException>().WithMessage("Campo Nome é obrigatório");
        }

        [Theory(DisplayName = "Contrutor com CPF inválido")]
        [InlineData("Pietro Bernardo Luan Melo", null)]
        public void ContrutorSacado_PassarCPFNulo_RetornaException(string nome, string cpf)
        {
            Action action = () => new Sacado(nome, cpf);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Cpf deve ter 14 digitos");
        }

        [Theory(DisplayName = "Contrutor com CPF diferente de 14")]
        [InlineData("Gabriela Letícia Marlene Melo", "5849491597515975")]
        public void ContrutorSacado_PassarCPFComValorDiferenteDe14_RetornaException(string nome, string cpf)
        {
            Action action = () => new Sacado(nome, cpf);
            action.Should().Throw<ArgumentException>().WithMessage("O campo Cpf deve ter 14 digitos");
        }

    }
}
