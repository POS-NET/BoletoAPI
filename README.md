
# 💸 API Boleto .NET

A API .NET foi desenvolvido utilizando Clean Architecture com clean code.

Essa estrutura de projeto consiste em utilizar uma biblioteca do projeto BoletoNetCore e para conhecer clique aqui.
Basicamente temos uma endpoint que vai se comunicar com essa biblioteca e gerar o layout do boleto de vários bancos.





## 🧪 Teste

O projeto inclui testes unitários para o back-end (.NET).


## 📁 Estrutura do projeto
- #### Apresentation  

  ⭐ Controller: Controladores da API, responsáveis por receber requisições e enviar respostas.

- #### Application

  ⭐ DTOS: Data Transfer Objects usados para passar dados entre camadas.
  
  ⭐ Interfaces: Contratos para os serviços.
         
  ⭐ Mappings: Mapeamento das classes DTOS & Entities.
   
  ⭐ Services: Contém a lógica de negócios de alto nível e chama métodos do repositório.

- #### Domain
   ⭐ Entities: Entidades do domínio.
     
   ⭐ Enums: Enumerações usadas nas entidades e/ou regras de negócio.

   ⭐ Interfaces: Contratos para os repositórios.

   ⭐ Interfaces:

- #### Infrastructure
    ⭐ Repositories: Implementações dos repositórios definidos na camada de Domínio.

## 🤔 FAQ

#### O que preciso para rodar essa API?
R: Essa API foi desenvolvida utilizando o .NET 6 então precisa dessa versão e o Visual Studio 22 instalado na sua máquina.

#### Essa API consome com projeto?
R: Essa api teve uma base do projeto BoletoNetCore e para conhecer acesse o link: https://github.com/BoletoNet/BoletoNetCore

#### Qual o canal de suporte?
R: Esse projeto não tem um canal de suporte, então caso tenha algum problema por favor abra uma discução para virar tratar sobre o problema e se for o caso os administradores irão transforma em uma issue.

#### Por onde devo começar?
R: Dentro do nosso REP analise as issues e comece a contribuir. 😉

#### Qual é o fluxo de desenvolvimento?
R: Em nosso projeto existe dois tipos de branchs a main e a develop
Para que possamos criar alguma melhoria em nosso códgio, vai ser preciso criar uma nova branch se baseando na branch de desenvolvimento com o nome de feature ex:

_feature/nome-da-issue_

Dessa forma conseguimos ter uma rastreabilidade das issues de funcionalidades.
Caso precise ajustar algum bug, será preciso criar no seguinte padrão:

_hotfix/nome-da-issue_

Depois de finalizar crie suas PR para que possamos analisar, lembrando que as pull request devem ser feita olhando para a branch de desenvolvimento.

## ⚖️ Licença

Este projeto é disponibilizado sob a licença MIT License. Essa licença permite o uso, a cópia, a modificação e a distribuição do código-fonte

