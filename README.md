# API Ninjas de Naruto

API RESTful desenvolvida em **C# com .NET 10**, utilizando **Entity Framework Core** e **SQLite** para o gerenciamento dos ninjas do universo de Naruto.

O projeto implementa operações CRUD (*Create, Read, Update e Delete*), permitindo consultar, cadastrar, atualizar e remover ninjas por meio de endpoints HTTP.

## Tecnologias Utilizadas

- **C#** — linguagem de programação.
- **.NET 10** — plataforma de desenvolvimento.
- **ASP.NET Core Minimal APIs** — criação dos endpoints REST.
- **Entity Framework Core** — mapeamento objeto-relacional e acesso aos dados.
- **SQLite** — banco de dados relacional.
- **Bruno** — ferramenta para testes das requisições HTTP.

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Pacotes NuGet do Entity Framework Core e do provedor SQLite configurados no projeto.
- String de conexão `Padrao` configurada no arquivo `appsettings.json`.
- Ferramenta `dotnet-ef` instalada, caso queira gerar ou aplicar migrations:

```bash
dotnet tool install --global dotnet-ef
```

## Como Executar o Projeto

1. Clone o repositório e acesse a pasta raiz do projeto.
2. Verifique se a string de conexão `Padrao` está configurada corretamente no `appsettings.json`.
3. Crie o banco de dados SQLite aplicando as migrations do projeto.
4. Execute a aplicação pelo terminal:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

A aplicação será iniciada na URL informada pelo terminal. Conforme o `launchSettings.json` deste projeto, o endereço local é:

```text
http://localhost:5107
```

> **Observação:** a porta pode variar conforme as configurações de execução do projeto.

Ao abrir essa URL no navegador, a interface web de gerenciamento dos ninjas é carregada a partir da pasta `wwwroot`.

## Estrutura do Projeto

```text
ApiNaruto/
├── Program.cs                  # Endpoints da API (Minimal APIs)
├── Ninja.cs                    # Entidade mapeada pelo EF Core
├── AppDbContext.cs             # Contexto do banco e dados iniciais (seed)
├── Migrations/                 # Migrations geradas pelo EF Core
├── wwwroot/
│   └── index.html              # Interface web que consome a API
├── bruno/
│   └── Api Ninjas/             # Coleção de requisições para teste
├── appsettings.json            # String de conexão `Padrao`
└── ApiNaruto.csproj            # Pacotes do EF Core e do SQLite
```

## Endpoints da API

| Método | Rota | Descrição | Sucesso |
|---|---|---|---|
| `GET` | `/api` | Verifica se a API está online | `200 OK` |
| `GET` | `/api/ninjas` | Lista todos os ninjas cadastrados | `200 OK` |
| `GET` | `/api/ninjas/{id}` | Busca um ninja pelo ID | `200 OK` |
| `POST` | `/api/ninjas` | Cadastra um novo ninja | `201 Created` |
| `PUT` | `/api/ninjas/{id}` | Atualiza um ninja existente | `200 OK` |
| `DELETE` | `/api/ninjas/{id}` | Remove um ninja existente | `204 No Content` |

### Respostas de erro

As operações de busca, atualização e remoção retornam `404 Not Found` quando o ninja solicitado não existe.

O retorno contém uma mensagem informando que o ninja com o ID especificado não foi encontrado.

## Exemplos de Requisições

### 1. Verificar o status da API

**Requisição:**

```http
GET /api
```

**Resposta — `200 OK`:**

```json
{
  "mensagem": "API de Ninjas de Naruto no ar!",
  "status": "Online"
}
```

### 2. Listar ninjas

**Requisição:**

```http
GET /api/ninjas
```

Retorna uma lista com os ninjas cadastrados no banco de dados.

### 3. Buscar ninja por ID

**Requisição:**

```http
GET /api/ninjas/1
```

Retorna os dados do ninja correspondente ao ID informado ou `404 Not Found` caso ele não exista.

**Resposta — `200 OK`:**

```json
{
  "id": 1,
  "nome": "Naruto Uzumaki",
  "cla": "Uzumaki",
  "aldeia": "Konohagakure",
  "idade": 17,
  "nivelDePoder": 9500
}
```

### 4. Cadastrar ninja

**Requisição:**

```http
POST /api/ninjas
Content-Type: application/json
```

**Payload:**

```json
{
  "nome": "Rock Lee",
  "cla": "Lee",
  "aldeia": "Konohagakure",
  "idade": 18,
  "nivelDePoder": 7600
}
```

**Resposta:** `201 Created`, contendo os dados do ninja criado, incluindo o ID gerado pelo banco de dados.

### 5. Atualizar ninja

**Requisição:**

```http
PUT /api/ninjas/11
Content-Type: application/json
```

**Payload:**

```json
{
  "nome": "Rock Lee",
  "cla": "Lee",
  "aldeia": "Konohagakure",
  "idade": 19,
  "nivelDePoder": 8200
}
```

**Resposta:** `200 OK`, contendo os dados atualizados do ninja.

Se o ID não existir, a API retornará `404 Not Found`.

### 6. Remover ninja

**Requisição:**

```http
DELETE /api/ninjas/11
```

**Resposta:** `204 No Content` quando a remoção for concluída com sucesso.

Se o ninja não existir, será retornado `404 Not Found`.

## Testes com Bruno

A coleção `bruno/Api Ninjas` contém as requisições prontas para todos os endpoints.

As requisições usam a variável `{{baseUrl}}`, que deve ser configurada no Bruno com o endereço da API:

```text
http://localhost:5107
```

## Banco de Dados

A aplicação utiliza **SQLite** para armazenar os dados dos ninjas e **Entity Framework Core** para realizar as operações de consulta e persistência.

Diferentemente de uma implementação que mantém os dados apenas em uma lista em memória, as alterações são gravadas no banco por meio de `SaveChangesAsync()`.

Dessa forma, os registros permanecem disponíveis após o encerramento da aplicação.

Os dez ninjas iniciais são cadastrados pelo `HasData` do `AppDbContext`, então quem executar `dotnet ef database update` já recebe o banco populado.
