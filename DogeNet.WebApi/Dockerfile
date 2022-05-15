FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /api

COPY . .

RUN dotnet restore --disable-parallel
RUN dotnet publish -c Debug -o /api --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /api
COPY --from=build /api ./

EXPOSE 7001

ENTRYPOINT ["dotnet", "DogeNet.WebApi.dll"]