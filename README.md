


# LBWebAPI

## Pré-requisitos

* Não existem configurações necessárias, apenas baixar e compilar a solução.

## 📫 Informações

* Os Books Possuem ID, Nome e Quantidade.

## 💻 End-Points

* GET     /api/books -> Retorna todos os Books Cadastrados ( De padrão existem dois ).
* POST    /api/books/{Id}{Name}{Quantity} -> Cadastra um Book.
* GET     /api/books/{id} -> Retorna um Book pelo Id.
* DELETE  /api/books/{id} -> Remove um Book pelo Id.
* PUT    /api/book/{Id}{Name}{Quantity} -> Atualiza um Book ( Leva em consideração o ID ).
* GET     /api/borrowedbooks -> Retorna todos os Books Atualmente emprestados.
* POST    /api/borrow/book/{id} -> Empresta um Book.
* POST    /api/return/book/{id} -> Devolve um Book Emprestado.

## 🚀 Ferramentas/Modelagem/Design Pattern Utilizados.

* DDD - Domain Driven Design
* CQRS - Command Query Responsibility Segregation.
* Mediator (MediaTR). 
* DI - Dependency Injection.
* Swagger.
* AutoMapper.
* FluentValidation.
* InMemoryCache.
