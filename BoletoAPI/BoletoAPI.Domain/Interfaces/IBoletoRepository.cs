﻿using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBoletoRepository
    {
        string RetornarHTML(DadosBoleto dadosBoleto);
    }
}