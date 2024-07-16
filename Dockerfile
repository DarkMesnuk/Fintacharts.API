FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY Fintacharts.API/*.csproj ./Fintacharts.API/
COPY Fintacharts.API.Application/*.csproj ./Fintacharts.API.Application/
COPY Fintacharts.API.Database/*.csproj ./Fintacharts.API.Database/
COPY Fintacharts.API.Domain/*.csproj ./Fintacharts.API.Domain/
COPY Fintacharts.Api.HTTP.DataProvider/*.csproj ./Fintacharts.Api.HTTP.DataProvider/
COPY Fintacharts.Api.WebSocket.DataProvider/*.csproj  ./Fintacharts.Api.WebSocket.DataProvider/

RUN dotnet restore "Fintacharts.API/Fintacharts.API.csproj"

COPY . .
WORKDIR "/src/Fintacharts.API"
RUN dotnet build "Fintacharts.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Fintacharts.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fintacharts.API.dll"]
