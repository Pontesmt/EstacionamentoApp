Desenvolvimento de uma API para controle de estacionamento
essa API realiza 3 tipos de ação, controle de entrada e saida de veiculos em um estacionamento,
*Adiciona Veiculo
*calcula o horario de entrada e saida
*remove o veiculo

------------------------------------------------------------------------------------------

-Tecnologias Usadas
* ASP.NET API (microservices)
* Entity Framework (Acesso ao banco de dados)
* JWT (Autenticação)
* Xunit (Desenvolvimento de testes)

-padrões ultilizados
*Arquitetura em N camadas
--Api
--Dominio (Domain)
--Repositorio (InfaStructure)

Documentação ordem de criação de desenvolvimento

- criação do projeto API WEB do ASP.NET Core, Estrutura do sistema desenvolvido em camadas 4,
EstacionamentoApp (Solução)

-EstacionamentoApp.API - ASP.NET
-EstacionamentoApp.Domain - biblioteca de classes
-EstacionamentoApp.Infra.Data - biblioteca de classes
EstacionamentoApp.Tests - Xunit


Após a criação das camadas do sistema crio o primeiro controlador da API com a definição das endpoints 
AdicionarVeiculo e RemoverVeiculo (não implementadas ainda)

------------------------------------------------------------------------------------------

Depois parto para o dominio, a camada do sistema onde eu vou implementar todos os serviços de dominio/regras de
negocio da aplicação.

nesta camada eu tenho 

- As Classes de entidade do projeto (MODELAGEM DE DADOS)
- Dtos (Objetos para transferencia de dados)
- Serviço de dominio (Classes para desenvolvimento das regras de negocio do sistema)
- Validações de dados

Crio as entidades de dominio

Entidade
    VEICULOS
ID - int
Placa - string
EmailDono - string
NomeDono - string
horarioentrada - datetime
horariosaida - datetime


------------------------------------------------------------------------------------------


Agora eu construo a camada para tratamento do banco de dados no EstacionamentoApp.Infra.Data

Criando as pastas Contexts - Mappings e Repositories

eu ultilizo o entityframework, para isso eu instalo suas bibliotecas no gerenciador de pacotes.

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

O projeto EstacionamentoApp.Infra.Data precisa acessar o conteúdo do projeto
EstacionamentoApp.Infra.Domain, para isso preciso adicionar referencia de um
projeto para outro.

Adicionar - referenciar a outro projeto.


-----------------------------------------------------------------------------------------

O padrão que eu ultilizei foi o CODE FIRST, é o padrão ultilizado pelo entity framework para trabalçharmos com banco de dados. De acordo com esse padrão
a gente mapeia cada classe de entidade dentro do projeto, definindo qial é a sua respectiva tabela no banco de dados, nessa forma o entity framework, ele é capaz de
gravar, alterar, excluir e consultar dados nessa tabela sem a escrita de código SQL no projeto.

Alem disso posso usar a ferramenta MIGRATIONS onde o entity framework consegue criar a tabela no banco de dados
caso ela não exista.

---------------------------------------------------------------------------
Assim criei a classe de mapeamento para a entidade veiculos

VeiculoMap.cs

fiz o mapeamento da entidade Veiculo no banco de dados

EX:

builder.Property(v => v.NomeDono)
.HasColumnName("NOME_DONO")
.HasMaxLength(150) 
.IsRequired(); 

-----------------------------------------------------------------------------

agora criarei o banco de dados

exibir - pesquisador de objetos do SQL SERVER - banco de dados - adicionar novo banco de dados.

depois vou nas propiedades do Banco de dados criado, e pego sua connection string - Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EstacionamentoApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

crio uma classe de contexto para que eu possa configurar o entityframework para:

* Conectar ao banco de dados
* adicionar as classes de mapeamento



-Migrations

migrations é uma ferramenta do entity frameqoek que é capaz de criar no BD todas as tabelas mapeadas
no projeto.

Cada mapeamento novo de tabela ou de campos de uma tabela podemos gerar uma migration (atualizar o BD)


Para fazermos o primeiro migration do sistema, precisamos colocar o projeto
Estacionamento.Infra.Data procisoriamente como projeto de inicialização

EstacionamentoApp.Infra.Data - Definir como projeto de inicializacao

para executar a migration preciso acessar o terminal de linha de comando

Ferramentas / gerenciador de pacotes do nuget/ console do gerenciador de pacotes

alterar o projeto padrao para o EstacionamentoApp.Infra.Data

primeiro comando a se executar é para criar a primeira migration do projeto

ou seja gerar a primeira construção de tabelas do BD

Add-Migration Initial

as tabelas não foram criadas no banco de dados. O comando anterior sóo gerou as classes no projeto
que irão construir as tabelas.

Update-Database

foi criada 2 tabelas no banco de dados.

com o Script-Migration a gente consegue pedir para o entity framework
gerar o codigo SQL

----------------------------------------------------------------------

Criando uma interface para definir quais métodos serão implementados pelo repositorio de Veiculos

primeiro vamos criar uma interface para entao depois criarmos
 a classe que implementa a interface

regras da interfacw 

*Todos os metodos de uma interface são abstratos(não tem corpo, só assinatura)
*Quando uma classe HERDA uma interface, ela deve implementar (fornecer o corpo) para todos os metodos abstratos da classe


Após implementar a interface e os metodos.

O enity framework é um ORM, object relational mapper, que simplifica a interação entre uma aplicação .NET e um BANCO DE DADOS RELACIONAL(um tipo de banco organizado em tabelas com linhas e coluna, onde as linhas representam registros e as colunas representam
atributos), Dentro do EF, o code firsté uma abordagem onde o desenvolvedor define o modelo de dados como classes C# e permite que o framework gere automaticamente o esquema do banco de dados a partir dessas definições.

Principais caracteristicas do code first
- Foco no código: O modelo de dominio é a fonte primária de definição. O esquema do banco de dados é gerado a partir das classes.
- Flexibilidade: Quando você desenvolve desssa maneira você tem controle total sobre as classes, você pode definir propiedades, tipos e relacionamentos.
- Configuração via Fluent API: Além das anotações, é possível configurar o modelo através de uma API fluente, permitindo maior flexibilidade na configuração de regras.
 
Migrations no Entity framework

As Migrations são uma funcionalidade do EF Code first galera, ele gerencia as mudanças no esquema do banco de dados ao longo do ciclo de vida do desenvolvimento. À medida que o modelo seja de domínio (classes) evolui, as migrations permitem que o banco seja atualizado de forma incremental.

*Principais etapas das Migrations

1 - Criação: cada modificação no modelo de monìnio ( como adição de uma nova propiedade ou entidade) pode ser registrada em uma migration.
2 - Aplicação: As Migrations são aplicadas ao banco de dados para sincronizar o esquema com o modelo de domínio.
3 - controle de versão: O EF mantém um historico das migrations aplicadas, permitindo que o banco seja atualizado ou revertido para versões anteriores.


beneficios:

*Automação: reduz a necessiade de scripts manuais para alterações no banco
*Consistência: Garante que o esquema do banco de dados esteja sempre alinhado com o modelo
*Colaboração: Em equipes de desenvolvimento, as migrationsoermitem que todos trabalhem com o mesmo esquema de vanco de dados.

----------------------------------------------------------------------------------------

Usando o método de arquitetura limpa, eu consigo unir um conjunto de principios de boas praticas.

UMA ESTRUTURA EM CAMADAS SEPARANDO CADA RESPONSABILIDADE DEVE SER FEITA EM QUALQUER CÓDIGO.

Desenvolvimento do dominio da aplicação:

Essa camada de dominio ela representa o "core" do sistema, porque dentro desse dominio a gente pode encontrar

-Entidades
-Interfaces
-DTOS
-Validações
-Serviços do dominio

Agora vou fazer as validações das entidades de dominio:
para isso eu vou usar a biblioteca fluent validation

Após fazer a validação dos dados da entidade do Veiculo

são serviços de dominio para entrada e saida de dados

faço a criação dos DTOS
CadastroVeiculoRequestDto - request
CadastroVeiculoResponseDto - Response


Depois das criações dos DTOS, vou criar uma interface para definir os métodos que serão implementados 
plos serviços de dominio: No POO uma interface funciona quase como um contrato, ela vai definir quais metodos deverão ser implementados por 
classes do projeto.

Implementei a interface, criei uma classe que pode fornecer corpo para todos os metodos abstratos da interface.

proximo passo fazer injeção de dependencia.


Injeção de dependencia 

O objetivo dela é fazer com que os objetos de classes ou de interfaces, que podem ser inicializados 
de forma automatica em tempo de execução

Eu estou desenvolvendo a classe de serviço de dominio. Esta classe precisa do repositorio para construir as suas regras de negocio.

para que a classe VeiculoDomainService possa acessar os metodos do repositorio ela ira ultizar a interface criada para o repositorio
IVeiculoRepository

estes conceitos estão linkados com 2 principios do Solid

*ISP - Principio de segregação de interfaces
*DIP - Principio de inversao de dependencia




já que estamos criando interfaces para varias classes do projeto, podemos acessar estas interfaces ao inves de acessar
as classes diretamente.

Quando uma classe de ALTO NIVEL precisa acessar classes de BAIXO NIVEL ela na verdade vai acessar as interfaces

primeiro passo para fazer isso é a classe VeiculoDomainService, ela ira declarar um atributo somente leitura na interface IVeiculoRepository.

O segundo passo é criar um construtor que possa inicializar esse atributo

depois disso eu voltei para o projeto API e adicionar referencia para todos os projetos da solução.

No controlador precisso acessar os métodos do serviço de dominio, porém, respeitando so principios do SOLID eu vou acessar a interface do serviço de dominio
vou acessar a interface do serviço de dominio.

Configurei as injeções de dependencia do projeto.

Exemplo de DIP : Um modulo de alto nivel como uma classe de serviço não deve instanciar diretam,ente um repositorio. Em vez disso, ele deve depender de uma abstração(interface) que define o contrato que o repositorio implementara.


Papel da injeção de dependencia: É um padrão que facilita a imnplementação do DIP. Ela consiste em dornecer dependencias externas(Como services, repositories ou  objects).

-Tipos de injeção de dependencia

1- injeção via construtor:
* As dependencias são fornecidas por meio do construtor da classe
*A mais comum e recomendada para garantir que a dependencia seja obrigatoria e configurada no momento da criação do objeto
2- Injeção via propiedade:
*A dependencia é configurada por meio de uma propiedade publica
*Util para dependencias opcionais opu que podem ser configuradas após a criação do projeto
3. Injeção via Método:
*As dependências são passadas como parâmetros de métodos
específicos.
*Comum em cenários onde as dependências variam entre
chamadas.

Agora irei focar na biblioteca de classe do .NET Xunit

ela é feita exclusivamente para criação e desenvolvimento de testes. Nessa solução fiz um projeto que seu opbjetivo é realizar testes em cada endpoint da minha API ou chamado de teste de integração.


Este projeto deverá executar os endpoints da API para verificar se estao funcionando da maneira correta

IMPORTANTE LEMBRAR
para que o projeto xunit possa executar testes na API, ele precisa adicionar referencia para o projeto da API

para desenvolver um projeto de teste instalei as 3 bibliotecas: MVC.TESTING, Fluent Assertions(para asserções de teste, comparação entre os esperados e os obtidos), BOGUS (gera dados fake)
















