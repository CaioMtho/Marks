# 📡 Marks

> Um sistema centralizado de gestão de marcações e favoritos na web, indepedente de navegadores.

---

## 🚀 Tecnologias

- ASP.NET Core
- BCrypt.Net
- AutoMapper
- Entity Framework Core
- Swagger (OpenAPI)
- PostgreSQL

---

## 📦 Instalação Local

> Obs: Atualmente se faz necessário um servidor PostgreSQL local para o 
funcionamento da aplicação, modifique as credenciais em appsettings.json
se necessário

```bash
# Clone o repositório
git clone https://github.com/CaioMtho/Marks.git
cd Marks

# Instale as dependências
dotnet restore

# Configure variáveis de ambiente
set Jwt__Key="chave-HmacSha256-valida"

# Execute as migrations
dotnet ef database update --project src/Marks.Infrastructure --startup-project src/Marks.Api

# Execute a API em Marks/src/Marks.Api
dotnet run
```

---

## 📖 Swagger

Uma vez em execução, acesse:

- Swagger UI: [http://localhost:5134/swagger](http://localhost:7252/swagger)

---

## 🔐 Autenticação

Crie um usuário no endpoint api/user/register com o seguinte modelo:

```
{
    "username": {seu-nome},
    "email": {seu-email},
    "password": {sua-senha}
}
```
E então faça uma requisição para api/user/login com o seguinte modelo:

```
{
    "email": {email-criado},
    "password": {senha-criada}
}
```

Use o token JWT retornado nas requisições seguintes.

---

## 📁 Estrutura do Projeto

```
src/
├── Marks.Api/
│   ├── Properties/
│   ├── Controllers/
│   └── Program.cs
│
├── Marks.Application/
│   ├── Dto/
│   │   ├── Bookmark/
│   │   ├── Folder/
│   │   ├── Tag/
│   │   └── User/
│   ├── Interfaces/
│   ├── Services/
│   ├── Models/
│   └── Mappings/
│
├── Marks.Core/
│   └── Entities/
│
└── Marks.Infrastructure/
    ├── Data/
    └── Migrations/
```

---

## 📌 Contribuindo

1. Fork este repositório
2. Crie uma branch
3. Faça suas alterações
4. Abra um Pull Request
---

## 📄 Licença

[MIT](LICENSE)

---

## 🤝 Créditos

Criado por [@CaioMtho](https://github.com/CaioMtho)
