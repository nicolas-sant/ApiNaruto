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
cd backend
dotnet new web -o ApiNaruto
cd ApiNaruto
code .
dotnet run
```

Substitua o conteúdo do `Program.cs` gerado pelo código da API antes de rodar `dotnet run`.

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

> **Atenção:** os dados ficam armazenados **somente em memória**, em uma lista declarada no próprio `Program.cs`. Não há banco de dados nem arquivo de persistência.
>
> Tudo que for cadastrado, atualizado ou removido durante a execução é perdido assim que a aplicação é encerrada. A cada `dotnet run` a lista volta aos 10 ninjas iniciais.
