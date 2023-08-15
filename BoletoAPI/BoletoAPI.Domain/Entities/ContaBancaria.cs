namespace BoletoAPI.Domain.Entities
{
    public sealed class ContaBancaria : Base
    {
        #region Propriedades

        public string Agencia { get; private set; } = string.Empty;
        public string Conta { get; private set; } = string.Empty;
        public string CarteiraPadrao { get; private set; } = string.Empty;

        #endregion Propriedades

        #region Construtores

        public ContaBancaria(string agencia, string conta, string carteiraPadrao)
        {
            ValidacaoEntidade(agencia, conta, carteiraPadrao);
        }

        #endregion Construtores

        #region Métodos

        private void ValidacaoEntidade(string agencia, string conta, string carteiraPadrao)
        {
            if (string.IsNullOrEmpty(agencia) || (agencia.Length < 4 || agencia.Length > 5))
                throw new ArgumentException($"{nameof(Agencia)} inválida: O campo deve ter um tamanho de 4 a 5 digitos.");

            if (string.IsNullOrEmpty(conta))
                throw new ArgumentException($"{nameof(Conta)} inválido: Campo obrigatório.");

            if (string.IsNullOrEmpty(carteiraPadrao))
                throw new ArgumentException($"{nameof(CarteiraPadrao)} inválido: O campo é obrigatório");

            Agencia = agencia;
            Conta = conta;
            CarteiraPadrao = carteiraPadrao;
        }

        #endregion Métodos
    }
}