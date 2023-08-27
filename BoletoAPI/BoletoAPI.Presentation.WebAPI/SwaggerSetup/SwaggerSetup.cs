// namespace BoletoAPI.Apresentation.WebAPI;

// public static class SwaggerSetup
// {
//      public static void AddSwagger(this IServiceCollection services)
//  {
//      services.AddSwaggerGen(c =>
//      {
//          c.SwaggerDoc("v1",
//          new OpenApiInfo
//          {
//              Title = "BoletoNetCore.WebAPI",

//              Version = "v1",
//              Contact = new OpenApiContact
//              {
//                  Name = "Comunidade Boleto NETCORE",
//                  Url = new Uri("https://github.com/BoletoNet/BoletoNetCore")

//              },
//              Description = "Bem-vindo(a) à nossa API para consumir o projeto open source BOLETO NET CORE. " +
//               "Este é um projeto em constante crescimento, graças às contribuições de várias pessoas em todo o Brasil.\r\n\r\nOs endpoints da API são separados por banco e é" +
//               " extremamente importante fornecer todas as informações necessárias, incluindo os dados do boleto para o cálculo do " +
//               "código de barras (nosso número, número do documento e campo livre).\r\n\r\nDentro do método GerarBoleto do nosso projeto da API, " +
//               "comentamos o boleto.ValidarDados(); pois essa endpoint é apenas um exemplo de geração do boleto. No entanto, se você quiser testar um pagamento, " +
//               "basta descomentar esse método e fornecer as informações necessárias para a geração do boleto e efetuar o pagamento.",
//          });

//          var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//          var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//          c.IncludeXmlComments(xmlPath);
//      });
//  }
// }
