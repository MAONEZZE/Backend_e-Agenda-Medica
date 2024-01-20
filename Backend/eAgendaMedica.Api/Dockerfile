#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Preparando a imagem

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Etapa de build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eAgendaMedica.Api/eAgendaMedica.Api.csproj", "eAgendaMedica.Api/"]
COPY ["eAgendaMedica.Testes/eAgendaMedica.Testes.csproj", "eAgendaMedica.Testes/"]
COPY ["eAgendaMedica.Dominio/eAgendaMedica.Dominio.csproj", "eAgendaMedica.Dominio/"]
COPY ["eAgendaMedica.Aplicacao/eAgendaMedica.Aplicacao.csproj", "eAgendaMedica.Aplicacao/"]
COPY ["eAgendaMedica.Infra/eAgendaMedica.Infra.csproj", "eAgendaMedica.Infra/"]
RUN dotnet restore "eAgendaMedica.Api/eAgendaMedica.Api.csproj"
COPY . .
WORKDIR "/src/eAgendaMedica.Api"
RUN dotnet build "eAgendaMedica.Api.csproj" -c Release -o /app/build

#Etapa de publicção

FROM build AS publish
RUN dotnet publish "eAgendaMedica.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eAgendaMedica.Api.dll"]