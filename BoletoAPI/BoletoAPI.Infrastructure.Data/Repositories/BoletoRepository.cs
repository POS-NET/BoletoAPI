using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoNetCore;

namespace BoletoAPI.Infrastructure.Data.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private IBanco _iBanco;

        public string RetornarHTML(DadosBoleto dadosBoleto, DadosBeneficiario dadosBeneficiario, Domain.Entities.ContaBancaria contaBancaria, Sacado sacado, DadosEndereco endereco)
        {
            _iBanco = ObterTipoBanco(dadosBoleto);

            _iBanco.Beneficiario = PreencherDadosBeneficiario(dadosBeneficiario, contaBancaria);

            _iBanco.FormataBeneficiario();

            var boleto = GerarLayoutBoleto(_iBanco, dadosBoleto, sacado, endereco);
            var boletoBancario = new BoletoBancario { Boleto = boleto };

            return boletoBancario.MontaHtmlEmbedded();
        }

        private IBanco ObterTipoBanco(DadosBoleto dadosBoleto)
        {
            switch (dadosBoleto.TipoBanco)
            {
                case "BancoDoBrasil":
                    return Banco.Instancia(Bancos.BancoDoBrasil);

                case "BancoDoNordeste":
                    return Banco.Instancia(Bancos.BancoDoNordeste);

                case "Santander":
                    return Banco.Instancia(Bancos.Santander);

                case "Banrisul":
                    return Banco.Instancia(Bancos.Banrisul);

                case "UniprimeNortePR":
                    return Banco.Instancia(Bancos.UniprimeNortePR);

                case "Cecred":
                    return Banco.Instancia(Bancos.Cecred);

                case "Caixa":

                    return Banco.Instancia(Bancos.Caixa);

                case "Bradesco":
                    return Banco.Instancia(Bancos.Bradesco);

                case "Safra":
                    return Banco.Instancia(Bancos.Safra);

                case "Sicredi":
                    return Banco.Instancia(Bancos.Sicredi);

                case "Sicoob":
                    return Banco.Instancia(Bancos.Sicoob);

                case "CrediSIS":
                    Banco.Instancia(Bancos.CrediSIS);
                    return Banco.Instancia(Bancos.CrediSIS);

                case "Itau":
                    return Banco.Instancia(Bancos.Itau);

                default:
                    throw new ArgumentException($"Banco não implementado.");
            }
        }

        private Beneficiario PreencherDadosBeneficiario(DadosBeneficiario beneficiario, Domain.Entities.ContaBancaria contaBancaria)
        {
            Beneficiario beneficiarioLibNetCore = new Beneficiario();

            beneficiarioLibNetCore.CPFCNPJ = beneficiario.CPFCNPJ;
            beneficiarioLibNetCore.Nome = beneficiario.Nome;
            beneficiarioLibNetCore.ContaBancaria.Agencia = contaBancaria.Agencia;
            beneficiarioLibNetCore.ContaBancaria.Conta = contaBancaria.Conta;
            beneficiarioLibNetCore.ContaBancaria.CarteiraPadrao = contaBancaria.CarteiraPadrao;
            beneficiarioLibNetCore.ContaBancaria.TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples;
            beneficiarioLibNetCore.ContaBancaria.TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro;
            beneficiarioLibNetCore.ContaBancaria.TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa;

            return beneficiarioLibNetCore;
        }

        private Boleto GerarLayoutBoleto(IBanco iBanco, DadosBoleto dadosBoleto, Sacado sacado, DadosEndereco endereco)
        {
            var boleto = new Boleto(iBanco)
            {
                Pagador = DadosSacado(sacado, endereco),
                DataEmissao = dadosBoleto.DataEmissao,
                DataProcessamento = dadosBoleto.DataProcessamento,
                DataVencimento = dadosBoleto.Vencimento,
                ValorTitulo = dadosBoleto.Valor,
                NumeroDocumento = dadosBoleto.NumeroDocumento,
                EspecieDocumento = TipoEspecieDocumento.DS,
                ImprimirValoresAuxiliares = true,
            };

            //boleto.ValidarDados(); DADOS DE PRODUÇÃO ESSA LINHA DEVE SER DESCOMENTADA
            return boleto;
        }

        private static Pagador DadosSacado(Sacado sacado, DadosEndereco dadosEndereco)
        {
            return new Pagador
            {
                Nome = sacado.Nome,
                CPFCNPJ = sacado.Cpf,

                Endereco = new Endereco
                {
                    LogradouroEndereco = dadosEndereco.Logradouro,
                    LogradouroNumero = dadosEndereco.Numero,
                    Bairro = dadosEndereco.Bairro,
                    Cidade = dadosEndereco.Cidade,
                    UF = dadosEndereco.Estado,
                    CEP = dadosEndereco.CEP
                }
            };
        }
    }
}