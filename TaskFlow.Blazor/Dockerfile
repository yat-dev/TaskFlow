#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["TaskFlow.Blazor/TaskFlow.Blazor.csproj", "TaskFlow.Blazor/"]
#RUN dotnet restore "TaskFlow.Blazor/TaskFlow.Blazor.csproj"
#COPY . .
#WORKDIR "/src/TaskFlow.Blazor"
#RUN dotnet build "TaskFlow.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "TaskFlow.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "TaskFlow.Blazor.dll"]
# Étape de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

COPY TaskFlow.Blazor/TaskFlow.Blazor.csproj TaskFlow.Blazor/
COPY TaskFlow.Application/TaskFlow.Application.csproj TaskFlow.Application/
COPY TaskFlow.Infrastructure/TaskFlow.Infrastructure.csproj TaskFlow.Infrastructure/
COPY TaskFlow.Domain/TaskFlow.Domain.csproj TaskFlow.Domain/

RUN dotnet restore TaskFlow.Blazor/TaskFlow.Blazor.csproj

COPY . .
WORKDIR /src/TaskFlow.Blazor
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Étape finale
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TaskFlow.Blazor.dll"]
