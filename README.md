# 💈 BarberShop

Sistema back-end para gerenciamento de barbearias, desenvolvido em C# com ASP.NET. Este projeto visa facilitar o controle de clientes, agendamentos, horários e serviços oferecidos por uma barbearia.

## 📋 Funcionalidades

- Cadastro e gerenciamento de clientes
- Agendamento de serviços
- Gerenciamento de horários e disponibilidade
- Controle de serviços oferecidos pela barbearia
- Autenticação e autorização de usuários via JWT

## 🛠 Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- PostgreSQL (hospedado no Azure)
- JWT (JSON Web Token) para autenticação
- Swagger para documentação da API

## 📦 Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/)
- Editor de código (ex: Visual Studio ou VS Code)

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/PRbrate/BarberShop.git
   cd BarberShop

2. Configure a string de conexão com o banco de dados PostgreSQL no arquivo appsettings.json:
```bash
   "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=BarberShopDb;Username=seu_usuario;Password=sua_senha"
     }
```
   
3.Execute as migrações do banco de dados:
```bash
   dotnet ef database update
```
4. Inicie o projeto:
```bash
   dotnet run
```
