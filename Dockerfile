# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build
WORKDIR /src

# Copiar arquivos da solução e projetos
COPY ChallangeMottu.sln ./
COPY ChallangeMottu.Api/ChallangeMottu.Api.csproj ChallangeMottu.Api/
COPY ChallangeMottu.Application/ChallangeMottu.Application.csproj ChallangeMottu.Application/
COPY ChallangeMottu.Domain/ChallangeMottu.Domain.csproj ChallangeMottu.Domain/
COPY ChallangeMottu.Infrastructure/ChallangeMottu.Infrastructure.csproj ChallangeMottu.Infrastructure/

# Restaurar dependências
RUN dotnet restore --verbosity detailed

# Copiar o restante do código
COPY . .

# Limpar completamente obj e bin
RUN powershell -Command "$ErrorActionPreference = 'SilentlyContinue'; Get-ChildItem -Path . -Include bin,obj -Recurse -Directory | ForEach-Object { Remove-Item $_.FullName -Recurse -Force }"

# Verificar estrutura de diretórios
RUN dir /s /b *.csproj

# Publicar sem gerar documentação primeiro (para isolar o problema)
WORKDIR /src
RUN dotnet publish ChallangeMottu.Api/ChallangeMottu.Api.csproj ^
    -c Release ^
    -o /app/publish ^
    --no-restore ^
    --verbosity detailed

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022 AS runtime
WORKDIR /app

# Copiar a publicação
COPY --from=build /app/publish ./

# Configurações da API
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

# Executar a API
ENTRYPOINT ["dotnet", "ChallangeMottu.Api.dll"]
