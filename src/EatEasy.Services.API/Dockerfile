#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["src/EatEasy.Services.API/EatEasy.Services.API.csproj", "src/EatEasy.Services.API/"]
COPY ["src/EatEasy.Application/EatEasy.Application.csproj", "src/EatEasy.Application/"]
COPY ["src/EatEasy.Domain/EatEasy.Domain.csproj", "src/EatEasy.Domain/"]
COPY ["src/EatEasy.Domain.Core/EatEasy.Domain.Core.csproj", "src/EatEasy.Domain.Core/"]
COPY ["src/EatEasy.CrossCutting.IoC/EatEasy.CrossCutting.IoC.csproj", "src/EatEasy.CrossCutting.IoC/"]
COPY ["src/EatEasy.CrossCutting.Bus/EatEasy.CrossCutting.Bus.csproj", "src/EatEasy.CrossCutting.Bus/"]
COPY ["src/EatEasy.Infra.Data/EatEasy.Infra.Data.csproj", "src/EatEasy.Infra.Data/"]
COPY ["src/EatEasy.Tests.Domain/EatEasy.Tests.Domain.csproj", "src/EatEasy.Tests.Domain/"]
RUN dotnet restore "src/EatEasy.Services.API/EatEasy.Services.API.csproj"
COPY . .

WORKDIR "/src/src/EatEasy.Services.API"
RUN dotnet build "EatEasy.Services.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EatEasy.Services.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EatEasy.Services.API.dll"]