namespace BoletoAPI.Domain.Entities
{
    public sealed class DadosBoleto : Base
    {
        #region Propriedades

        public string NossoNumero { get; private set; } = string.Empty;
        public DateTime Vencimento { get; private set; } = DateTime.MinValue;
        public string NumeroDocumento { get; private set; } = string.Empty;
        public string? CampoLivre { get; private set; }
        public decimal Valor { get; private set; } = decimal.Zero;
        public DateTime DataEmissao { get; private set; } = DateTime.MinValue;
        public DateTime DataProcessamento { get; private set; } = DateTime.MinValue;
        public string TipoBanco { get; set; } = string.Empty;

        // Propriedades de navegação publica
        public Sacado Sacado { get; private set; }

        public DadosBeneficiario Beneficiario { get; private set; }

        #endregion Propriedades

        #region Construtores

        public DadosBoleto(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco)
        {
            ValidacaoEntidade(nossoNumero, vencimento, numeroDocumento, valor, dataEmissao, dataProcessamento, tipoBanco);
        }

        #endregion Construtores

        #region Métodos

        private void ValidacaoEntidade(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco)
        {
            if (string.IsNullOrEmpty(nossoNumero))
                throw new ArgumentException($"{nameof(NossoNumero)} inválido: Campo obrigatório.");

            if (string.IsNullOrEmpty(numeroDocumento))
                throw new ArgumentException($"{nameof(NumeroDocumento)} inválido: Campo obrigatório.");

            if (vencimento == DateTime.MinValue)
                throw new ArgumentException($"{nameof(Vencimento)} inválido: Data {vencimento} não esta no formato correto.");

            if (valor <= 10)
                throw new ArgumentException($"{nameof(Valor)} deve ser maior do que R$ 10,00.");

            if (dataEmissao == DateTime.MinValue)
                throw new ArgumentException($"{nameof(DataEmissao)} inválido: Data {dataEmissao} não esta no formato correto.");

            if (dataProcessamento == DateTime.MinValue)
                throw new ArgumentException($"{nameof(DataProcessamento)} inválido: Data {dataProcessamento} não esta no formato correto.");

            if (string.IsNullOrWhiteSpace(tipoBanco))
                throw new ArgumentException($"{nameof(TipoBanco)} inválido, o campo {tipoBanco} é obrigatório.");

            NossoNumero = nossoNumero;
            Vencimento = vencimento;
            NumeroDocumento = numeroDocumento;
            Valor = valor;
            DataEmissao = dataEmissao;
            TipoBanco = tipoBanco;
        }

        #endregion Métodos
    }
}