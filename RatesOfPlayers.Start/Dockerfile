FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER root
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RatesOfPlayers.Start/RatesOfPlayers.Start.csproj", "RatesOfPlayers.Start/"]
COPY ["RatesOfPlayers.Domain/RatesOfPlayers.Domain.csproj", "RatesOfPlayers.Domain/"]
COPY ["RatesOfPlayers.Infrastructure.Storage/RatesOfPlayers.Infrastructure.Storage.csproj", "RatesOfPlayers.Infrastructure.Storage/"]
COPY ["RatesOfPlayers.Application.Abstractions/RatesOfPlayers.Application.Abstractions.csproj", "RatesOfPlayers.Application.Abstractions/"]
COPY ["RatesOfPlayers.Infrastructure.Web/RatesOfPlayers.Infrastructure.Web.csproj", "RatesOfPlayers.Infrastructure.Web/"]
COPY ["RatesOfPlayers.Application.Services/RatesOfPlayers.Application.Services.csproj", "RatesOfPlayers.Application.Services/"]
RUN dotnet restore "RatesOfPlayers.Start/RatesOfPlayers.Start.csproj"
COPY . .
WORKDIR "/src/RatesOfPlayers.Start"
RUN dotnet build "./RatesOfPlayers.Start.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RatesOfPlayers.Start.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RatesOfPlayers.Start.dll"]
