FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR .
ENV ASPNETCORE_URLS=https://+:7001

EXPOSE 7001

COPY . .
RUN dotnet restore
RUN dotnet publish -c Debug -o /out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR .
COPY --from=build-env /out .

ENTRYPOINT ["dotnet", "DogeNet.WebApi.dll", "--server.urls", "https://+:7001"]