#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EatEasy.Services.API/EatEasy.Services.API.csproj", "EatEasy.Services.API/"]
RUN dotnet restore "EatEasy.Services.API/EatEasy.Services.API.csproj"
COPY . .
WORKDIR "/src/EatEasy.Services.API"
RUN dotnet build "EatEasy.Services.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EatEasy.Services.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EatEasy.Services.API.dll"]