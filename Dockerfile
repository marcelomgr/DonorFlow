# Usa a imagem do SDK do .NET 8 para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo do projeto da API e restaura as dependências
COPY DonorFlow.API/DonorFlow.API.csproj ./DonorFlow.API/
RUN dotnet restore DonorFlow.API/DonorFlow.API.csproj

# Copia o restante do código e publica o projeto
COPY . .
RUN dotnet publish DonorFlow.API/DonorFlow.API.csproj -c Release -o /app/publish

# Usa a imagem do runtime do .NET 8 para executar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Expõe a porta 80 (ou a porta que sua API usa)
EXPOSE 80

# Comando para rodar o aplicativo
ENTRYPOINT ["dotnet", "DonorFlow.API.dll"]