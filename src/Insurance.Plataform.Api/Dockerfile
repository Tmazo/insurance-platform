
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Insurance.Plataform.Api/Insurance.Plataform.Api.csproj", "Insurance.Plataform.Api/"]
COPY ["src/Insurance.Plataform.Infrastructure/Insurance.Plataform.Infrastructure.csproj", "Insurance.Plataform.Infrastructure/"]

RUN dotnet restore "Insurance.Plataform.Api/Insurance.Plataform.Api.csproj"

COPY ./src .

WORKDIR "/src/Insurance.Plataform.Api"
RUN dotnet build "Insurance.Plataform.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Insurance.Plataform.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Insurance.Plataform.Api.dll"]
