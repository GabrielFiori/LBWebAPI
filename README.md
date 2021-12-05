


# LBWebAPI

## Pré-requisitos

* Não existem configurações necessárias, apenas baixar e compilar a solução.

## 📫 Informações

* Os Books Possuem ID, Nome e Quantidade.

## 💻 End-Points

* GET     /api/Books -> Retorna todos os Books Cadastrados ( De padrão existem dois ).
* POST    /api/Books/{Id}{Name}{Quantity} -> Cadastrar um Book.
* GET     /api/Books/{id} -> Retorna um Book pelo Id.
* DELETE  /api/Books/{id} -> Remove um Book pelo Id.
* POST    /api/BookUpdate/{Id}{Name}{Quantity} -> Atualiza um Book ( Leva em consideração o ID ).
* GET     /api/Borrow -> Retorna todos os Books Atualmente emprestados.
* POST    /api/Borrow/{id} -> Empresta um Book.
* POST    /api/Return/{id} -> Devolve um Book Emprestado.

## 🚀 Ferramentas/Modelagem/Design Pattern Utilizados.

* DDD - Domain Driven Design
* CQRS - Command Query Responsibility Segregation.
* Mediator (MediaTR). 
* DI - Dependency Injection.
* Swagger.
* AutoMapper.
* FluentValidation.
* InMemoryCache.
