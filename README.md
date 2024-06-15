## Sobre o Projeto

O projeto consiste um sistema de gerenciamento de um banco de dados de doação de sangue.

---

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- UnitOfWork
- Padrão Repository
- Generic Repository (Abstração)
- CQRS
- Arquitetura Limpa
- Fluent Validation
- DTO's
- ValueObject
- Integração com API de CEP
- Autenticação e Autorização com JWT (e Autorização via Swagger)

---

## Passo a Passo para Executar o Projeto

### Pré-requisitos

- Docker instalado na máquina
- .NET SDK instalado na máquina

### Passo 1: Baixar e Executar o Docker, e o Contêiner do SQL Server

- Baixe o Docker Desktop nesse link: https://www.docker.com/products/docker-desktop/
- Faça a instalação, crie a conta (pode vincular com e-mail, desde que relacione um usuário/senha para permitir autenticação via powershell, se necessário);
- Faça logon pelo Docker Desktop;
- Execute os comandos abaixo para obter a imagem, e rodar o contêiner (só será possível acessar o contêiner enquanto estiver rodando, pode iniciá-lo por linha de comando ou através do "play" no Docker Desktop):
```bash
docker pull mcr.microsoft.com/mssql/server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Abcd=1234" -p 1433:1433 --name sqlserver_container -d mcr.microsoft.com/mssql/server
```

### Passo 2: Configurar as Credenciais de Acesso ao Banco de Dados

Abra o SQL Server Management Studio (SSMS)
Configure as seguintes credenciais:

- Nome do Servidor: localhost,1433
- Nome de Usuário: sa
- Senha: Abcd=1234

### Passo 3: Baixar o SDK do .NET 8.0

Baixe o SDK através desse link:
https://dotnet.microsoft.com/pt-br/download/dotnet/8.0

### Passo 4: Executar as Migrações do Entity Framework Core

Para isso, navegue até o projeto 'DonorFlow.Infrastructure'
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add FirstMigration -s ../DonorFlow.API -o Persistence/Migrations
dotnet ef database update -s ../DonorFlow.API
```

### Passo 5: Executar a aplicação

- Se necessário, altere o projeto de inicialização para "DonorFlow.API";
- Rode a aplicação;
- A action "Users" (Post) está como "AllowAnonymous", portanto deve ser possível efetuar o cadastro de seu usuário sem autenticação (utilize a pemissão "Admin");
- Em seguida, autentique-se pela action "Auth";
- Após a obtenção do token, vá em "Authorize" no swagger, e inclua no campo "bearer [tokenGerado]";
- Pronto, ao executar as actions, já deve estar autorizado;
