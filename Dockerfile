#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SharkITTesteTecnico/SharkITTesteTecnico.Api.csproj", "SharkITTesteTecnico/"]
COPY ["Application/SharkITTesteTecnico.Application.csproj", "Application/"]
COPY ["Domain/SharkITTesteTecnico.Domain.csproj", "Domain/"]
COPY ["Infrastructure/SharkITTesteTecnico.Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "SharkITTesteTecnico/SharkITTesteTecnico.Api.csproj"
COPY . .
WORKDIR "/src/SharkITTesteTecnico"
RUN dotnet build "SharkITTesteTecnico.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharkITTesteTecnico.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:8080 dotnet SharkITTesteTecnico.Api.dll
