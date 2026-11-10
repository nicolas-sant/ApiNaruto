# API-Naruto

API REST de listagem de ninjas do universo de Naruto, construída com **Minimal API** em C#.

**Tema:** Naruto
**Objetivo:** expor uma listagem de ninjas com suas informações básicas — nome, clã, aldeia, idade e nível de poder (fictício) — permitindo consultar, cadastrar, atualizar e remover registros via requisições HTTP.

---

## Requisitos

- **.NET 10 SDK** ou superior

Para verificar a versão instalada:

```bash
dotnet --version
```

---

## Como executar

```bash
git clone https://github.com/nicolas-sant/ApiNaruto.git
cd ApiNaruto
dotnet tool install --global dotnet-ef   # só na primeira vez
dotnet ef database update                # cria o ninjas.db com os 10 ninjas iniciais
dotnet run
```

Depois é só abrir `http://localhost:5107` no navegador para usar a interface web, ou chamar os endpoints diretamente.

---

## URL local

A API sobe em:

```
http://localhost:5107
```

Endpoint base usado nos testes:

```
http://localhost:5107/api/ninjas
```

> A porta é definida em `Properties/launchSettings.json`. Se o seu projeto subir em outra porta, ajuste a URL nos testes.

---

## Endpoints

| Método | Rota | Descrição |
| --- | --- | --- |
| `GET` | `/api/ninjas` | Retorna a lista completa de ninjas. |
| `GET` | `/api/ninjas/{id}` | Retorna um ninja específico pelo id. Responde `404` se não existir. |
| `POST` | `/api/ninjas` | Cadastra um novo ninja. O id é gerado automaticamente. Responde `201` com o recurso criado. |
| `PUT` | `/api/ninjas/{id}` | Atualiza todos os dados do ninja informado. Responde `404` se o id não existir. |
| `DELETE` | `/api/ninjas/{id}` | Remove o ninja informado. Responde `204` em caso de sucesso e `404` se o id não existir. |

---

## Exemplos de JSON

### POST `/api/ninjas`

```json
{
  "nome": "Rock Lee",
  "cla": "Lee",
  "aldeia": "Konohagakure",
  "idade": 17,
  "nivelDePoder": 7600
}
```

O campo `id` não é enviado no corpo — a API o gera automaticamente e o devolve na resposta.

### PUT `/api/ninjas/10`

```json
{
  "id": 10,
  "nome": "Killer Bee",
  "cla": "Kumo",
  "aldeia": "Kumogakure",
  "idade": 42,
  "nivelDePoder": 9200
}
```

O `id` que vale é o da rota. Se ele também for enviado no corpo, é simplesmente ignorado pela desserialização.

---

## Persistência

Os dados ficam em um banco **SQLite** (`ninjas.db`), acessado com **Entity Framework Core**:

- `Ninja.cs` é a entidade e `AppDbContext.cs` o contexto do banco.
- A migration `CriarTabelaNinjas` cria a tabela e já insere 10 ninjas iniciais (seed via `HasData`).
- A string de conexão fica em `appsettings.json` (`ConnectionStrings:Padrao`).
- O cadastro e a atualização recebem um DTO de entrada (`NinjaEntradaDto`), então o cliente não controla o `id`.

Os registros continuam salvos depois que a aplicação é encerrada.

---

## Interface web

A pasta `wwwroot` tem uma página (`index.html`) servida pela própria API que lista, cadastra, edita e remove ninjas consumindo os endpoints com `fetch`.

---

## Testando as requisições

A pasta `bruno/Api Ninjas` tem uma coleção do [Bruno](https://www.usebruno.com/) com uma requisição para cada operação: API no ar, listar, buscar por id, cadastrar, atualizar, remover e confirmar a remoção. Abra a pasta no Bruno e execute as requisições em ordem.

---

## Tecnologias

C# · .NET 10 (Minimal API) · Entity Framework Core · SQLite · HTML, CSS e JavaScript · Bruno
