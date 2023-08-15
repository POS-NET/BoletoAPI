using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoNetCore;

namespace BoletoAPI.Infrastructure.Data.Repositories
{
    public class BoletoRepository : IBoleto
    {
        private readonly IBanco _iBanco;

        public BoletoRepository(IBanco iBanco)
        {
            _iBanco = iBanco;
        }

        //public Task<string> RetornarHTML(DadosBoleto dadosBoleto)
        //{
        //    #region Dados do beneficiaio

        //    DadosBeneficiario beneficiario = new DadosBeneficiario(dadosBoleto.Beneficiario.Codigo, dadosBoleto.Beneficiario.CodigoDV, dadosBoleto.Beneficiario.CodigoFormatado, dadosBoleto.Beneficiario.CodigoTransmissao, dadosBoleto.Beneficiario.CPFCNPJ, dadosBoleto.Beneficiario.Nome, dadosBoleto.Beneficiario.Observacoes);

        //    // Mapeamento de objetos
        //    _iBanco.Beneficiario.CPFCNPJ = beneficiario.CPFCNPJ;
        //    _iBanco.Beneficiario.Nome = beneficiario.Nome;

        //    // Dados bancário da conta do beneficiário
        //    _iBanco.Beneficiario.ContaBancaria.Agencia = dadosBoleto.Beneficiario.ContaBancaria.Agencia;
        //    _iBanco.Beneficiario.ContaBancaria.Conta = dadosBoleto.Beneficiario.ContaBancaria.Conta;
        //    _iBanco.Beneficiario.ContaBancaria.CarteiraPadrao = dadosBoleto.Beneficiario.ContaBancaria.CarteiraPadrao;
        //    _iBanco.Beneficiario.ContaBancaria.TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples;
        //    _iBanco.Beneficiario.ContaBancaria.TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro;
        //    _iBanco.Beneficiario.ContaBancaria.TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa;

        //    #endregion Dados do beneficiaio

        //    _iBanco.FormataBeneficiario();

        //}
    }
}