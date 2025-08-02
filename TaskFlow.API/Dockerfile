#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["TaskFlow.API/TaskFlow.API.csproj", "TaskFlow.API/"]
#RUN dotnet restore "TaskFlow.API/TaskFlow.API.csproj"
#COPY . .
#WORKDIR "/src/TaskFlow.API"
#RUN dotnet build "TaskFlow.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "TaskFlow.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "TaskFlow.API.dll"]
# Étape de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

COPY TaskFlow.API/TaskFlow.API.csproj TaskFlow.API/
COPY TaskFlow.Application/TaskFlow.Application.csproj TaskFlow.Application/
COPY TaskFlow.Infrastructure/TaskFlow.Infrastructure.csproj TaskFlow.Infrastructure/
COPY TaskFlow.Domain/TaskFlow.Domain.csproj TaskFlow.Domain/

RUN dotnet restore TaskFlow.API/TaskFlow.API.csproj

COPY . .
WORKDIR /src/TaskFlow.API
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Étape finale
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TaskFlow.API.dll"]
