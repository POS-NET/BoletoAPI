namespace BoletoAPI.Domain.Entities
{
    public sealed class DadosBeneficiario : Base
    {
        #region Propriedades

        public string Codigo { get; private set; } = string.Empty;
        public string CodigoDV { get; private set; } = string.Empty;
        public string CodigoFormatado { get; private set; } = string.Empty;
        public string CodigoTransmissao { get; set; } = string.Empty;
        public string CPFCNPJ { get; private set; } = string.Empty;
        public string Nome { get; private set; } = string.Empty;
        public string Observacoes { get; private set; } = string.Empty;
        public bool MostrarCnpj { get; private set; } = false;

        // Propriedade de navegação
        public ContaBancaria ContaBancaria { get; private set; } 

        #endregion Propriedades

        #region Contrutores

        public DadosBeneficiario(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            ValidacaoEntidade(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
        }

        #endregion Contrutores

        #region Metodos

        private void ValidacaoEntidade(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            if(cpfCnpj != null)
                cpfCnpj.Replace(".", string.Empty).Replace("-", string.Empty);

            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException($"{nameof(Codigo)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(codigoDV))
                throw new ArgumentException($"{nameof(CodigoDV)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(codigoFormatado))
                throw new ArgumentException($"{nameof(CodigoFormatado)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(codigoTransmissao))
                throw new ArgumentException($"{nameof(CodigoTransmissao)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(cpfCnpj) || (cpfCnpj.Length > 14))
                throw new ArgumentException($"{nameof(CPFCNPJ)} inválido: Utilize 11 dígitos para CPF ou 14 para CNPJ.");

            if (string.IsNullOrEmpty(nome) || (nome.Length <= 9 || nome.Length > 100))
                throw new ArgumentException($"O campo {nameof(Nome)} é inválido, precisa ser pelo menos de 10 a 100 caracteres.");

            if (string.IsNullOrWhiteSpace(observacoes))
                throw new ArgumentException($"O campo {nameof(Observacoes)} é inválido, campo obrigatório.");

            Codigo = codigo;
            CodigoDV = codigoDV;
            CodigoFormatado = codigoFormatado;
            CodigoTransmissao = codigoTransmissao;
            CPFCNPJ = cpfCnpj;
            Nome = nome;
            Observacoes = observacoes;
        }

        #endregion Metodos
    }
}