namespace BoletoAPI.Domain.Entities
{
    public sealed class Sacado : Base
    {
        #region Propriedades

        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        // Propriedades de navegação
        public Endereco? Endereco { get; set; }

        #endregion Propriedades

        #region Construtores

        public Sacado(string nome, string cpf)
        {
            ValidacaoEntidade(nome, cpf);
        }

        #endregion Construtores

        #region Métodos

        private void ValidacaoEntidade(string nome, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException($"Campo {nameof(Nome)} é obrigatório");

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 14)
                throw new ArgumentException($"O campo {nameof(Cpf)} deve ter 14 digitos");

            Nome = nome;
            Cpf = cpf;
        }

        #endregion Métodos
    }
}