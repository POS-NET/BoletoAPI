using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BoletoAPI.Domain.Interfaces;
using BoletoAPI.Infrastructure.Data.Repositories;
using BoletoAPI.Application.Interfaces;
using BoletoAPI.Application.Services;
using BoletoNetCore;
using BoletoAPI.Application.Mappings;

namespace BoletoAPI.Infrastructure.CossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositórios

            services.AddScoped<IBoletoRepository, BoletoRepository>();

            #endregion Repositórios

            #region Services

            services.AddScoped<IBoletoService, BoletoService>();

            #endregion Services

            #region Configuração do AutoMapper

            services.AddAutoMapper(typeof(DomainParaDTO));

            #endregion Configuração do AutoMapper

            return services;
        }
    }
}