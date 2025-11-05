# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-ltsc2022 AS build
WORKDIR /src

# Copiar arquivos da solução
COPY ChallangeMottu.sln ./

# Copiar apenas os arquivos .csproj inicialmente (otimiza a utilização do cache do Docker)
COPY ChallangeMottu.Api/ChallangeMottu.Api.csproj ChallangeMottu.Api/
COPY ChallangeMottu.Application/ChallangeMottu.Application.csproj ChallangeMottu.Application/
COPY ChallangeMottu.Domain/ChallangeMottu.Domain.csproj ChallangeMottu.Domain/
COPY ChallangeMottu.Infrastructure/ChallangeMottu.Infrastructure.csproj ChallangeMottu.Infrastructure/

# Restaurar dependências, sem usar o cache
RUN dotnet nuget locals all --clear && dotnet restore --no-cache

# Agora, copie o restante do código
COPY . .

# Verificar versão do .NET SDK
RUN dotnet --version

# Publicar a API com mais detalhes de log
WORKDIR /src/ChallangeMottu.Api
RUN dotnet publish -c Release -o /app/publish \
    /p:GenerateDocumentationFile=true \
    /p:DocumentationFile=/app/publish/ChallangeMottu.Api.xml \
    --verbosity detailed

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-ltsc2022 AS runtime
WORKDIR /app

# Criar usuário não-root
RUN addgroup --system --gid 1000 appuser && \
    adduser --system --uid 1000 --ingroup appuser --disabled-password appuser

# Copiar publicação
COPY --from=build /app/publish ./

# Configurações da API
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

USER appuser

# Executar a API
CMD ["dotnet", "ChallangeMottu.Api.dll"]
