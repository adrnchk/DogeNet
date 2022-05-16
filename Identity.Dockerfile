FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR .app
ENV DOTNET_URLS=https://+:10001

COPY . .
RUN dotnet restore
RUN dotnet publish -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR .
COPY --from=build-env /app/publish .

ENTRYPOINT ["dotnet", "DogeNet.IdentityServer.dll"]