# Cadastra-API
Projeto API em .NET para gerenciar cadastro de pessoa jurídica e usuários associados, com funcionalidades para: adicionar, editar, inativar, excluir e consultar registros por filtro. Implementa integração com banco de dados e boas práticas.

## Funcionalidades

- CRUD de pessoa jurídica (Nome Fantasia, Razão Social, CNPJ, Endereço, Sócios, Tipo)
- CRUD de usuários vinculados às empresas
- Validação para evitar usuários com CPF duplicado na mesma empresa
- Consultas por tipo de empresa e perfil de usuário
- Interação via Swagger

## Tecnologias

- .NET 9
- Entity Framework (SQL Server)
- Swagger para testes da API


## Como rodar o projeto

1. Clone o repositório
2. Altere a connetion string de acordo com seu ambiente e banco de dados
3. Rode as migrations com: dotnet ef database update
4. Executar o projeto e ao abrir a URL no navegador, adicione na URL: /swagger.
