# BookCatalog - Documentação do Projeto

## Descrição

O projeto **BookCatalog** foi desenvolvido utilizando o .NET 8 com **Clean Architecture**. A estrutura do projeto está organizada da seguinte forma:

- **src/API**: Contém a implementação da API.
- **src/Domain**: Contém a lógica de negócios e entidades do domínio.
- **src/Infra**: Contém a implementação de infraestrutura, como acesso a dados.

Testes unitários foram desenvolvidos utilizando o framework **NUnit**.

## Execução do Projeto

### Requisitos

- .NET 8 instalado no seu ambiente.

### Passos para executar a API

1. Acesse o diretório da **API**: ..\BookCatalog\src\API 
2. Execute o projeto com o comando: **dotnet run**

### Consumo da API com Postman ou Insomnia
A API pode ser consumida através dos seguintes endpoints:

- **Buscar livros por termo e ordenar por preço**:
  - Método: `GET`
  - Endpoint: `https://localhost:7161/Books?term=Science&sortByPriceAscending=true`

- **Obter informações sobre o envio de um livro específico (ID 1)**:
  - Método: `GET`
  - Endpoint: `https://localhost:7161/Books/1/shipping`
  
### Execução dos Testes Unitários

1. Acesse o diretório de testes unitários: ..\BookCatalog\tests\DomainTests
2. Execute o projeto com o comando: **dotnet test**
