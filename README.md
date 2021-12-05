# LBWebAPI

1. Não existem configurações necessárias, apenas baixar e compilar a solução.
2. Os Books Possuem ID, Nome e Quantidade.
3. Existe os seguintes End-Points para os Books.
  3.1 GET     /api/Books -> Retorna todos os Books Cadastrados ( De padrão existem dois ).
  3.2 POST    /api/Books/{Id}{Name}{Quantity} -> Cadastrar um Book.
  3.3 GET     /api/Books/{id} -> Retorna um Book pelo Id.
  3.4 DELETE  /api/Books/{id} -> Remove um Book pelo Id.
  3.5 POST    /api/BookUpdate/{Id}{Name}{Quantity} -> Atualiza um Book ( Leva em consideração o ID ).
  3.5 GET     /api/Borrow -> Retorna todos os Books Atualmente emprestados.
  3.6 POST    /api/Borrow/{id} -> Empresta um Book.
  3.7 POST    /api/Return/{id} -> Devolve um Book Emprestado.
4. Ferramentas/Modelagem/Design Pattern Utilizados.
  4.1. DDD - Domain Driven Design
  4.2. CQRS - Command Query Responsibility Segregation.
  4.3. Mediator (MediaTR). 
  4.5. DI - Dependency Injection.
  4.6. Swagger.
  4.7. AutoMapper.
  4.8. FluentValidation.
  4.9. InMemoryCache.
