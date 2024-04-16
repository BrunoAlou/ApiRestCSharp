# Desafio API C# - Senior|Globaltec

## Desafio 1 - API REST em C#

### Funcionalidades Implementadas:
- Autenticação de usuários com geração de token.
- Consulta de usuários (lista de objetos de usuários).
- Consulta de usuário por código.
- Consulta de usuários por UF.
- Gravação de usuário com validação das informações.
- Atualização de dados de usuário.
- Exclusão de usuário.

### Pontos Relevantes:
- Utilização de ASP.NET Core para construir a API.
- Uso de JWT (JSON Web Tokens) para autenticação e autorização.
- Organização do código em controladores para cada funcionalidade.
- Utilização de classes modelo para representar os dados (exemplo: User).

## Desafio 2 - Consulta SQL

### Estrutura do Banco de Dados:
- Tabelas: ContasAPagar, ContasPagas, Pessoas
- Relacionamento entre as tabelas através de chaves estrangeiras.

### Consulta Requisitada:
- Informações necessárias: número do processo de pagamento, nome do fornecedor, data de vencimento, data de pagamento, valor líquido e identificador se é conta a pagar ou paga.
- Consulta envolve as tabelas ContasAPagar, ContasPagas e Pessoas.
