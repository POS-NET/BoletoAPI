using AutoMapper;
using BoletoAPI.Application.DTOs;
using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Application.Mappings
{
    public class DomainParaDTO : Profile
    {
        public DomainParaDTO()
        {
            CreateMap<DadosBoleto, DadosBoletoDTO>().ReverseMap();
        }
    }
}