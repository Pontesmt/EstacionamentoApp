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

As Migrations são












