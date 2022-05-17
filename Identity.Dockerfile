FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR .app
ENV ASPNETCORE_URLS=https://+:10001

EXPOSE 10001

COPY . .
RUN dotnet restore
RUN dotnet publish -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR .
COPY --from=build-env /app/publish .

ENTRYPOINT ["dotnet", "DogeNet.IdentityServer.dll","--server.urls", "https://+:10001"]l