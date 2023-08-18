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
            var gerarHtml = _mapper.Map<DadosBoleto>(dadosBoletoDTO);
            return await _iBoletoRepository.RetornarHTML(gerarHtml);
        }
    }
}