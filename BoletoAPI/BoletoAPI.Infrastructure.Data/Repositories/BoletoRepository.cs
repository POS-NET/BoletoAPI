using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoNetCore;

namespace BoletoAPI.Infrastructure.Data.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private IBanco _iBanco;

        public string RetornarHTML(DadosBoleto dadosBoleto)
        {
            _iBanco = Banco.Instancia(Bancos.Itau);

            #region Dados do beneficiaio

            // Mapeamento de objetos
            _iBanco.Beneficiario.CPFCNPJ = dadosBoleto.Beneficiario.CPFCNPJ;
            _iBanco.Beneficiario.Nome = dadosBoleto.Beneficiario.Nome;

            // Dados bancário da conta do beneficiário
            _iBanco.Beneficiario.ContaBancaria.Agencia = dadosBoleto.Beneficiario.ContaBancaria.Agencia;
            _iBanco.Beneficiario.ContaBancaria.Conta = dadosBoleto.Beneficiario.ContaBancaria.Conta;
            _iBanco.Beneficiario.ContaBancaria.CarteiraPadrao = dadosBoleto.Beneficiario.ContaBancaria.CarteiraPadrao;
            _iBanco.Beneficiario.ContaBancaria.TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples;
            _iBanco.Beneficiario.ContaBancaria.TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro;
            _iBanco.Beneficiario.ContaBancaria.TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa;

            #endregion Dados do beneficiaio

            _iBanco.FormataBeneficiario();
            var boleto = GerarLayoutBoleto(_iBanco, dadosBoleto);
            var boletoBancario = new BoletoBancario();
            boletoBancario.Boleto = boleto;

            return boletoBancario.MontaHtmlEmbedded();
        }

        private Boleto GerarLayoutBoleto(IBanco iBanco, DadosBoleto dadosBoleto)
        {
            var boleto = new Boleto(iBanco)
            {
                Pagador = GerarPagador(dadosBoleto),
                DataEmissao = dadosBoleto.DataEmissao,
                DataProcessamento = dadosBoleto.DataProcessamento,
                DataVencimento = dadosBoleto.Vencimento,
                ValorTitulo = dadosBoleto.Valor,
                NumeroDocumento = dadosBoleto.NumeroDocumento,
                EspecieDocumento = TipoEspecieDocumento.DS,
                ImprimirValoresAuxiliares = true
            };

            boleto.ValidarDados();
            return boleto;
        }

        private static Pagador GerarPagador(DadosBoleto dadosBoleto)
        {
            return new Pagador
            {
                Nome = dadosBoleto.Sacado.Nome,
                CPFCNPJ = dadosBoleto.Sacado.Cpf,

                Endereco = new Endereco
                {
                    LogradouroEndereco = dadosBoleto.Sacado.Endereco.Logradouro,
                    LogradouroNumero = dadosBoleto.Sacado.Endereco.Numero,
                    Bairro = dadosBoleto.Sacado.Endereco.Bairro,
                    Cidade = dadosBoleto.Sacado.Endereco.Cidade,
                    UF = dadosBoleto.Sacado.Endereco.Estado,
                    CEP = dadosBoleto.Sacado.Endereco.CEP
                }
            };
        }
    }
}