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
RUN dotnet restore

# Copiar o restante do código
COPY . .

# Limpar diretórios obj/bin para evitar conflitos de permissão
RUN powershell -Command "Get-ChildItem -Path . -Include bin,obj -Recurse -Directory | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue"

# Publicar a API
WORKDIR /src
RUN dotnet publish ChallangeMottu.Api/ChallangeMottu.Api.csproj -c Release -o /app/publish --no-restore /p:GenerateDocumentationFile=true /p:DocumentationFile=/app/publish/ChallangeMottu.Api.xml

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
