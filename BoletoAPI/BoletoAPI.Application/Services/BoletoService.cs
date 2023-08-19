using AutoMapper;
using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Interfaces;
using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;

namespace BoletoAPI.Application.Services
{
    public class BoletoService : IBoletoService
    {
        private IBoletoRepository _iBoletoRepository;
        private readonly IMapper _mapper;

        public BoletoService(IBoletoRepository iBoletoRepository, IMapper mapper)
        {
            _iBoletoRepository = iBoletoRepository;
            _mapper = mapper;
        }

        public async Task<string> GerarHTMLBoleto(DadosBoletoDTO dadosBoletoDTO)
        {
            var mapearDadosBoleto = _mapper.Map<DadosBoleto>(dadosBoletoDTO);
            var mapearDadosBeneficiario = _mapper.Map<DadosBeneficiario>(dadosBoletoDTO.BeneficiarioDTO);
            var mapearContaBancaria = _mapper.Map<ContaBancaria>(dadosBoletoDTO.BeneficiarioDTO.ContaBancariaDTO);
            var mapearDadosSacado = _mapper.Map<Sacado>(dadosBoletoDTO.SacadoDTO);
            var mapearDadosEndereco = _mapper.Map<DadosEndereco>(dadosBoletoDTO.SacadoDTO.EnderecoDTO);

            return _iBoletoRepository.RetornarHTML(mapearDadosBoleto, mapearDadosBeneficiario, mapearContaBancaria, mapearDadosSacado, mapearDadosEndereco);
        }
    }
}