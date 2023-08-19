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
        }
    }
}