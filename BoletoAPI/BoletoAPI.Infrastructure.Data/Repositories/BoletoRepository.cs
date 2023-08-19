using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoNetCore;

namespace BoletoAPI.Infrastructure.Data.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private IBanco _iBanco;

        public BoletoRepository(IBanco iBanco)
        {
            _iBanco = iBanco;
        }

        public string RetornarHTML(DadosBoleto dadosBoleto)
        {
            ObterTipoBanco(dadosBoleto);

            PreencherDadosBeneficiario(dadosBoleto.Beneficiario);
            _iBanco.FormataBeneficiario();

            var boleto = GerarLayoutBoleto(_iBanco, dadosBoleto);
            var boletoBancario = new BoletoBancario { Boleto = boleto };

            return boletoBancario.MontaHtmlEmbedded();
        }

        private void ObterTipoBanco(DadosBoleto dadosBoleto)
        {
            switch (dadosBoleto.TipoBanco)
            {
                case "BancoDoBrasil":
                    _iBanco = Banco.Instancia(Bancos.BancoDoBrasil);
                    break;

                case "BancoDoNordeste":
                    _iBanco = Banco.Instancia(Bancos.BancoDoNordeste);
                    break;

                case "Santander":
                    _iBanco = Banco.Instancia(Bancos.Santander);
                    break;

                case "Banrisul":
                    _iBanco = Banco.Instancia(Bancos.Banrisul);
                    break;

                case "UniprimeNortePR":
                    _iBanco = Banco.Instancia(Bancos.UniprimeNortePR);
                    break;

                case "Cecred":
                    _iBanco = Banco.Instancia(Bancos.Cecred);
                    break;

                case "Caixa":
                    _iBanco = Banco.Instancia(Bancos.Caixa);
                    break;

                case "Bradesco":
                    _iBanco = Banco.Instancia(Bancos.Bradesco);
                    break;

                case "Safra":
                    _iBanco = Banco.Instancia(Bancos.Safra);
                    break;

                case "Sicredi":
                    _iBanco = Banco.Instancia(Bancos.Sicredi);
                    break;

                case "Sicoob":
                    _iBanco = Banco.Instancia(Bancos.Sicoob);
                    break;

                case "CrediSIS":
                    _iBanco = Banco.Instancia(Bancos.CrediSIS);
                    break;

                case "Itau":
                    _iBanco = Banco.Instancia(Bancos.Itau);
                    break;

                default:
                    throw new ArgumentException($"Banco não implementado.");
            }
        }

        private void PreencherDadosBeneficiario(DadosBeneficiario beneficiario)
        {
            _iBanco.Beneficiario.CPFCNPJ = beneficiario.CPFCNPJ;
            _iBanco.Beneficiario.Nome = beneficiario.Nome;
            _iBanco.Beneficiario.ContaBancaria.Agencia = beneficiario.ContaBancaria.Agencia;
            _iBanco.Beneficiario.ContaBancaria.Conta = beneficiario.ContaBancaria.Conta;
            _iBanco.Beneficiario.ContaBancaria.CarteiraPadrao = beneficiario.ContaBancaria.CarteiraPadrao;
            _iBanco.Beneficiario.ContaBancaria.TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples;
            _iBanco.Beneficiario.ContaBancaria.TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro;
            _iBanco.Beneficiario.ContaBancaria.TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa;
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