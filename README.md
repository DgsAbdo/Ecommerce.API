# Ecommerce.API
Projeto criado para o processo seletivo da empresa Siteware.

# Tecnologias:

## .Net Core 6:
O .NET Core 6 é uma plataforma de desenvolvimento multiplataforma, de alto desempenho e escalabilidade, que oferece suporte ao desenvolvimento de aplicativos web, APIs e aplicativos de desktop. Com recursos avançados, 
como suporte a C# e Razor para desenvolvimento web, suporte expandido para WPF e Windows Forms, alta performance e eficiência de recursos, o .NET Core 6 é uma escolha popular para desenvolvedores que desejam criar 
aplicativos modernos e escaláveis usando o ecossistema .NET.

https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-6

## Entity Framework:
O Entity Framework é um framework de mapeamento objeto-relacional (ORM) para o desenvolvimento de aplicativos .NET. Ele simplifica o acesso e a manipulação de dados em bancos de dados relacionais, 
permitindo que os desenvolvedores interajam com o banco de dados usando objetos e consultas em linguagem de programação, em vez de escrever SQL manualmente. Com recursos como mapeamento de entidades, 
suporte a consultas LINQ, migrações de banco de dados e rastreamento de alterações, o Entity Framework ajuda a acelerar o desenvolvimento de aplicativos, tornando a persistência de dados mais fácil e eficiente.

https://learn.microsoft.com/pt-br/ef/core/

## SQL Server:
O SQL Server é um sistema de gerenciamento de banco de dados relacional (RDBMS) desenvolvido pela Microsoft. Ele fornece uma plataforma confiável e escalável para armazenar, organizar e recuperar dados de forma eficiente. 
O SQL Server suporta a linguagem SQL padrão, permitindo a criação de bancos de dados, tabelas, consultas, procedimentos armazenados e outras funcionalidades relacionadas ao gerenciamento de dados. 

https://learn.microsoft.com/pt-br/sql/tools/overview-sql-tools?view=sql-server-ver16

# Como executar a aplicação:

## Banco de dados:
Alterar e configurar a connection string no atributo 'sqlServer' na pasta 'Ecommerce.API\Ecommerce.API\appsettings.json'.

"sqlServer": "Server={nome do servidor};Database={nome do banco de dados};User={usuario};Password={senha};TrustServerCertificate=True"

### Gerar as tabelas e os relacionamentos:
Comando: dotnet ef database update --startup-project ..\Ecommerce.API\

## Visual Studio Code:
Executar o comando 'dotnet run' no terminal dentro da pasta \Ecommerce.API\Ecommerce.API

## Documentação das requisições da API:
Após executar a aplicação: https://localhost:7293/swagger/index.html
