
# 💸 API Boleto .NET

A concepção da API .NET adotou os preceitos fundamentais da Clean Architecture, aliados à filosofia do clean code.
O cerne deste projeto reside na estreita integração da biblioteca BoletoNetCore. Para um entendimento aprofundado da biblioteca, é possível acessar mais informações através deste [link](https://github.com/BoletoNet/BoletoNetCore). Simplificadamente, a estrutura do projeto é construída em torno de um endpoint central, estabelecendo uma comunicação precisa com a biblioteca mencionada. Tal abordagem possibilita a geração de layouts de boletos customizados, compatíveis com uma ampla gama de instituições bancárias.

![image](https://github.com/POS-NET/BoletoAPI/assets/99252640/7c9e722c-5620-4220-a646-070bd8f96f21)

🔥 Importante

Como funciona a estrutura da API via vídeo: https://www.youtube.com/watch?v=abb0ArKzQuA

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
R: Esta API foi construída utilizando o .NET 6, portanto, é necessário ter essa versão do framework instalada, juntamente com o Visual Studio 2022, em sua máquina.

#### Essa API consome com projeto?
R: Essa API tem sua base fundamentada no projeto BoletoNetCore. Caso queira obter mais informações a respeito, você pode acessar o seguinte link: https://github.com/BoletoNet/BoletoNetCore

#### Qual o canal de suporte?
R: ste projeto não dispõe de um canal de suporte direto. Caso você enfrente algum problema, por favor, inicie uma discussão para tratar da questão. Se necessário, os administradores poderão converter a discussão em um problema oficial (issue) para ser abordado.

#### Por onde devo começar?
R: Dentro do nosso repositório, convidamos você a examinar as issues existentes e começar a contribuir de maneira construtiva. 😉

#### Qual é o fluxo de desenvolvimento?
R: Em nosso projeto, adotamos um modelo de gestão de código que compreende duas principais ramificações: 'main' e 'develop'. Para implementar melhorias em nosso código-base, segue-se um procedimento específico: a criação de uma nova ramificação baseada na branch 'develop', seguindo o padrão nomenclatural:
```
_feature/nome-da-issue_
```

Este padrão assegura uma rastreabilidade clara das issues correspondentes às funcionalidades propostas. No contexto de correção de erros, adotamos uma abordagem semelhante:

```
_hotfix/nome-da-issue_
```

Uma vez que suas contribuições estejam concluídas, solicitamos a criação de Pull Requests (PRs) para que possamos realizar uma avaliação minuciosa. Importante ressaltar que as PRs devem ser direcionadas à branch 'develop', refletindo nosso foco no desenvolvimento contínuo e colaborativo.

## ⚖️ Licença

A presente iniciativa é disponibilizada mediante a licença MIT License, reconhecida por conferir um leque amplo de prerrogativas, englobando a permissão para utilização, replicação, modificação e distribuição do código-fonte com notável flexibilidade.

