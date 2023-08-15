namespace BoletoAPI.Domain.Entities
{
    public sealed class Endereco : Base
    {
        #region Propriedades

        public string CEP { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        #endregion Propriedades

        #region Contrutores

        public Endereco(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            ValidacaoEntidade(cep, logradouro, numero, bairro, cidade, estado);
        }

        #endregion Contrutores

        #region Métodos

        private void ValidacaoEntidade(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            if (string.IsNullOrWhiteSpace(cep) || (cep.Length != 9))
                throw new ArgumentException($"O campo {nameof(CEP)} deve conter 9 digitos");

            if (string.IsNullOrWhiteSpace(logradouro) || (logradouro.Length < 10 || logradouro.Length > 100))
                throw new ArgumentException($"O campo {nameof(Logradouro)} teve ter no mínimo 10 e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(numero) || numero.Length > 5)
                throw new ArgumentException($"O campo {nameof(Numero)} deve conter até 5 digitos.");

            if (string.IsNullOrWhiteSpace(bairro) || bairro.Length > 50)
                throw new ArgumentException($"O campo {nameof(Bairro)} deve ser até 50 caracteres.");

            if (string.IsNullOrWhiteSpace(cidade) || cidade.Length > 50)
                throw new ArgumentException($"O campo {nameof(Cidade)} deve ser até 50 caracteres.");

            if (string.IsNullOrWhiteSpace(estado) || estado.Length != 2)
                throw new ArgumentException($"O campo {nameof(Estado)} deve conter 2 digitos.");

            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        #endregion Métodos
    }
}