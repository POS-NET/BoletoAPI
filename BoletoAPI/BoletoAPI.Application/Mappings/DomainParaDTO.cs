using AutoMapper;
using BoletoAPI.Application.DTOs;
using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Application.Mappings
{
    public class DomainParaDTO : Profile
    {
        public DomainParaDTO()
        {
            #region Dados do boleto

            CreateMap<DadosBoletoDTO, DadosBoleto>();

            CreateMap<DadosBoleto, DadosBoletoDTO>()
                .ForMember(dest => dest.NossoNumero, opt => opt.MapFrom(src => src.NossoNumero))
                .ForMember(dest => dest.Vencimento, opt => opt.MapFrom(src => src.Vencimento))
                .ForMember(dest => dest.NumeroDocumento, opt => opt.MapFrom(src => src.NumeroDocumento))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.DataEmissao, opt => opt.MapFrom(src => src.DataEmissao))
                .ForMember(dest => dest.DataProcessamento, opt => opt.MapFrom(src => src.DataProcessamento))
                .ForMember(dest => dest.TipoBanco, opt => opt.MapFrom(src => src.TipoBanco));

            #endregion Dados do boleto

            #region Beneficiários

            CreateMap<BeneficiarioDTO, DadosBeneficiario>();

            CreateMap<DadosBeneficiario, DadosBeneficiario>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.CodigoDV, opt => opt.MapFrom(src => src.CodigoDV))
                .ForMember(dest => dest.CodigoFormatado, opt => opt.MapFrom(src => src.CodigoFormatado))
                .ForMember(dest => dest.CodigoTransmissao, opt => opt.MapFrom(src => src.CodigoTransmissao))
                .ForMember(dest => dest.CPFCNPJ, opt => opt.MapFrom(src => src.CPFCNPJ))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes));

            #endregion Beneficiários

            #region Conta Bancária

            CreateMap<ContaBancariaDTO, ContaBancaria>();

            CreateMap<ContaBancaria, ContaBancariaDTO>()
                .ForMember(dest => dest.Agencia, opt => opt.MapFrom(src => src.Agencia))
                .ForMember(dest => dest.Conta, opt => opt.MapFrom(src => src.Conta))
                .ForMember(dest => dest.CarteiraPadrao, opt => opt.MapFrom(src => src.CarteiraPadrao));

            #endregion Conta Bancária

            #region Endereço

            CreateMap<EnderecoDTO, DadosEndereco>();

            CreateMap<DadosEndereco, EnderecoDTO>()
               .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.CEP))
               .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
               .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
               .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
               .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
               .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));

            #endregion Endereço

            #region Sacado

            CreateMap<SacadoDTO, Sacado>();
            CreateMap<Sacado, SacadoDTO>()
                  .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                  .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.Cpf));

            #endregion Sacado
        }
    }
}