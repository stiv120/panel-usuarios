FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["src/Servicios/Servicios.csproj", "Servicios/"]
COPY ["src/Negocio/Negocio.csproj", "Negocio/"]
COPY ["src/AccesoDatos/AccesoDatos.csproj", "AccesoDatos/"]
COPY ["src/Entidades/Entidades.csproj", "Entidades/"]
RUN dotnet restore "Servicios/Servicios.csproj"
COPY src/ .
RUN dotnet build "Servicios/Servicios.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Servicios/Servicios.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Servicios.dll"]
