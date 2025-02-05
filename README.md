## Sobre o Projeto

O projeto consiste em um sistema de gerenciamento de um banco de dados de doação de sangue.

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

### Passo 1: Baixar e Executar o Docker Compose

- Baixe o Docker Desktop nesse link: https://www.docker.com/products/docker-desktop/
- Faça a instalação e crie uma conta (pode vincular com e-mail, desde que relacione um usuário/senha para permitir autenticação via terminal, se necessário);
- Faça logon pelo Docker Desktop;
- Navegue até a raiz do projeto onde está o arquivo `docker-compose.yml`;
- Execute o seguinte comando para subir os serviços:
```bash
docker-compose up -d
```

### Passo 2: Acessar a API

Após a execução do Docker Compose, a API estará rodando nos seguintes endpoints:

- API: http://localhost:5000
- Swagger: http://localhost:5000/swagger

### Passo 3: Autenticação e Uso da API

- A action "Users" (Post) está como "AllowAnonymous", portanto deve ser possível efetuar o cadastro de seu usuário sem autenticação (utilize a permissão "Admin");
- Em seguida, autentique-se pela action "Auth";
- Após a obtenção do token, vá em "Authorize" no Swagger e inclua no campo "bearer [tokenGerado]";
- Pronto, ao executar as actions, já deve estar autorizado.
