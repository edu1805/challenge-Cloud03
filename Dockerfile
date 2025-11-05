FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2022 AS build
WORKDIR /src

COPY ChallangeMottu.sln ./
COPY ChallangeMottu.Api/ChallangeMottu.Api.csproj ChallangeMottu.Api/
COPY ChallangeMottu.Application/ChallangeMottu.Application.csproj ChallangeMottu.Application/
COPY ChallangeMottu.Domain/ChallangeMottu.Domain.csproj ChallangeMottu.Domain/
COPY ChallangeMottu.Infrastructure/ChallangeMottu.Infrastructure.csproj ChallangeMottu.Infrastructure/

RUN dotnet restore --ignore-failed-sources

COPY . .

RUN dotnet publish ChallangeMottu.Api/ChallangeMottu.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "ChallangeMottu.Api.dll"]
```

## Atualizar .dockerignore
```
**/bin/
**/obj/
**/.vs/
**/.vscode/
**/.git/
**/.gitignore
**/nuget.config
**/NuGet.Config
