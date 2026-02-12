# 🚗 Veículos API — Teste Técnico (.NET 8)

API REST para cadastro e consulta de veículos com autenticação JWT construída utilizando Clean Architecture + CQRS + boas práticas REST.

O foco do projeto é demonstrar organização, separação de responsabilidades e clareza arquitetural — não apenas funcionamento.

---

# 🎯 Objetivo

Demonstrar domínio em:

- ASP.NET Core Web API
- Arquitetura em camadas
- CQRS com MediatR
- Autenticação JWT
- FluentValidation
- EF Core InMemory
- Tratamento correto de status HTTP

---

# 🧱 Arquitetura

O sistema segue uma variação de **Clean Architecture com CQRS**:


HTTP Request
↓
Controllers
↓
MediatR (Command/Query)
↓
Handlers (Use Cases)
↓
Services (Regras de negócio)
↓
Repositories (Domínio)
↓
EF Core InMemory


Separação clara de responsabilidades:

| Camada | Responsabilidade |
|------|------|
WebApi | Transporte HTTP |
Application | Casos de uso |
Domain | Modelo do negócio |
Infra | Persistência e autenticação |

---

# 📂 Estrutura do Projeto

| Pasta | Responsabilidade |
|------|------|
| `Veiculos.WebApi` | Controllers e configurações da API |
| `Veiculos.Application` | Commands, Queries e Services (casos de uso) |
| `Veiculos.Domain` | Entidades e interfaces do domínio |
| `Veiculos.Infra` | Persistência EF Core, JWT e Seed |



---

# 🔁 Fluxos CQRS

## Escrita (Commands)

Controller → Command → Handler → Service → Repository → Database


## Leitura (Queries)

Controller → Query → Handler → ReadService → Database


Read Model separado do Write Model.

---

# 🔐 Autenticação

- JWT Bearer Token
- Login retorna token
- Endpoints de veículos protegidos
- Middleware trata 401 automaticamente

---

# 🧪 Validações

Implementadas com **FluentValidation + PipelineBehavior**

| Situação | Retorno |
|------|------|
DTO inválido | 400 |
Login inválido | 401 |
Sem token | 401 |
Recurso inexistente | 404 |
Erro inesperado | 500 |

---

# 🌱 Seed automático

Ao iniciar a aplicação, dados são criados automaticamente em memória.

## Usuário padrão

login: admin
senha: 123456


## Veículos cadastrados
- Corolla Cross XRE
- Civic Touring
- Onix Premier
- T-Cross Highline
- Ranger Limited

> O banco é InMemory — reiniciar a API recria os dados.

---

# 🛠️ Tecnologias Utilizadas

| Tecnologia | Uso |
|------|------|
.NET 8 | Plataforma |
ASP.NET Core | API REST |
Entity Framework Core InMemory | Persistência |
MediatR | CQRS |
FluentValidation | Validação |
JWT Bearer | Autenticação |
Swagger | Documentação |

---

# ▶️ Como Rodar a Aplicação

## Pré-requisitos
- .NET 8 SDK instalado

---

## Passo a passo

| Etapa | Comando |
|------|------|
Clonar repositório | `git clone <url>` |
Entrar na pasta | `cd Veiculos` |
Restaurar pacotes | `dotnet restore` |
Compilar | `dotnet build` |
Executar API | `dotnet run --project Veiculos.WebApi` |

---

## Acessar Swagger

http://localhost:xxxx/swagger


---

# 🔑 Como Testar

## 1) Login

POST /api/auth/login

{
  "login": "admin",
  "senha": "123456"
}

Copie o token retornado.

## 2) Autorizar

Clique no botão **Authorize 🔒** no Swagger e cole o token no formato:


---

## 3) Testar endpoints protegidos

Após autorizar, os endpoints protegidos estarão liberados:

- `/api/veiculos`
- `/api/veiculos/{id}`
- `/api/veiculos` (POST, PUT, DELETE)

Sem token → `401 Unauthorized`

---

# 📡 Endpoints Disponíveis

| Método | Rota | Descrição |
|------|------|------|
POST | /api/auth/login | Autenticar usuário |
POST | /api/usuarios | Criar usuário |
GET | /api/usuarios | Listar usuários |
GET | /api/veiculos | Listar veículos |
GET | /api/veiculos/{id} | Buscar veículo por id |
POST | /api/veiculos | Criar veículo |
PUT | /api/veiculos/{id} | Atualizar veículo |
DELETE | /api/veiculos/{id} | Remover veículo |

---

# 🧠 Decisões Arquiteturais

- Controllers não possuem regra de negócio
- Handlers apenas orquestram o fluxo
- Services concentram regras de domínio
- Repositories apenas persistem dados
- ReadModel separado do WriteModel (CQRS)
- DTOs não expõem entidades do domínio
- Enum retorna valor numérico e descrição
- Middleware centraliza tratamento de erros

---

# 🌿 Estratégia de Branch

O repositório utiliza apenas a branch **master**.

Motivo: projeto de escopo fechado para avaliação técnica, mantendo histórico linear e simples para análise do avaliador.






