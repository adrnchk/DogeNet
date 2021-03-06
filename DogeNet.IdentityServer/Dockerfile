#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DogeNet.IdentityServer/DogeNet.IdentityServer.csproj", "DogeNet.IdentityServer/"]
COPY ["DogeNet.DAL/DogeNet.DAL.csproj", "DogeNet.DAL/"]
COPY ["DogeNet.BLL/DogeNet.BLL.csproj", "DogeNet.BLL/"]
RUN dotnet restore "DogeNet.IdentityServer/DogeNet.IdentityServer.csproj"
COPY . .
WORKDIR "/src/DogeNet.IdentityServer"
RUN dotnet build "DogeNet.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DogeNet.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS finalx
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DogeNet.IdentityServer.dll"]