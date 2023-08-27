using System.Reflection;
using Microsoft.OpenApi.Models;

namespace BoletoAPI.Apresentation.WebAPI;

public static class SwaggerSetup
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "BoletoAPI.WebAPI",

                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Projeto Open Source",
                    Url = new Uri("https://github.com/POS-NET/BoletoAPI")

                },
                Description = "Seja bem-vindo(a) ao nosso projeto open source voltado para boletos na plataforma .NET!" +
                              "Este é um projeto em constante evolução, " +
                "enriquecido pelas contribuições de diversos colaboradores distribuídos por todo o território brasileiro." +
                "Vamos iniciar nossa explanação pela endpoint principal.Trata - se de uma chamada genérica, " +
                "na qual é requisitado o fornecimento de um objeto JSON contendo detalhes que identifiquem o banco alvo da operação." +
                "É de extrema importância garantir que nossa API seja provida de todas as informações necessárias, " +
                "incluindo os dados essenciais para o cálculo do código de barras do boleto, como nosso número, número do documento e campo livre." +

                "Dentro do método `GerarLayoutBoleto`, localizado na camada de infraestrutura do arquivo `BoletoRepository.cs`, o comando `boleto.ValidarDados();` " +
                "encontra - se comentado.Essa medida foi tomada uma vez que, de momento, não dispomos de dados reais provenientes de instituições bancárias para a realização de testes e " +
                "geração do boleto a ser liquidado.Caso você disponha das informações bancárias necessárias, basta remover o comentário dessa linha de código."
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseSwaggerUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("v1/swagger.json", "BoletoAPI.Apresentation.WebAPI");
        });
    }
}
