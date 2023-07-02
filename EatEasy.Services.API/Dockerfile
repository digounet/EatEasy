#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY *.sln .
COPY ["EatEasy.Services.API/EatEasy.Services.API.csproj", "EatEasy.Services.API/"]
COPY ["EatEasy.Application/EatEasy.Application.csproj", "EatEasy.Application/"]
COPY ["EatEasy.Domain/EatEasy.Domain.csproj", "EatEasy.Domain/"]
COPY ["EatEasy.Domain.Core/EatEasy.Domain.Core.csproj", "EatEasy.Domain.Core/"]
COPY ["EatEasy.CrossCutting.IoC/EatEasy.CrossCutting.IoC.csproj", "EatEasy.CrossCutting.IoC/"]
COPY ["EatEasy.CrossCutting.Bus/EatEasy.CrossCutting.Bus.csproj", "EatEasy.CrossCutting.Bus/"]
COPY ["EatEasy.Infra.Data/EatEasy.Infra.Data.csproj", "EatEasy.Infra.Data/"]
COPY ["EatEasy.Tests.Domain/EatEasy.Tests.Domain.csproj", "EatEasy.Tests.Domain/"]

RUN dotnet restore

COPY . .
WORKDIR "/src/EatEasy.Services.API"
RUN dotnet build "EatEasy.Services.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EatEasy.Services.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EatEasy.Services.API.dll"]