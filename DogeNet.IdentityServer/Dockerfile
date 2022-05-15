FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /identity

COPY . .

RUN dotnet restore --disable-parallel

RUN dotnet publish -c Debug -o /identity --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /identity
COPY --from=build-env /identity .

EXPOSE 10001

ENTRYPOINT ["dotnet", "DogeNet.IdentityServer.dll"]