#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DogeNet.WebApi/DogeNet.WebApi.csproj", "DogeNet.WebApi/"]
COPY ["DogeNet.DAL/DogeNet.DAL.csproj", "DogeNet.DAL/"]
COPY ["DogeNet.BLL/DogeNet.BLL.csproj", "DogeNet.BLL/"]
RUN dotnet restore "DogeNet.WebApi/DogeNet.WebApi.csproj"
COPY . .
WORKDIR "/src/DogeNet.WebApi"
RUN dotnet build "DogeNet.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DogeNet.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DogeNet.WebApi.dll"]