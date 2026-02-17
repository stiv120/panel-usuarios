# Panel Usuarios

Aplicación web en Angular que consulta usuarios desde SQL Server. Arquitectura en capas con .NET 5 (Entidades, Presentación, Servicios, Negocio, Acceso Datos).

## Requisitos

- .NET 5 SDK
- Node.js 20+
- Docker y Docker Compose (opcional)
- SQL Server

## Estructura

```
Presentacion/    → Angular 19 (capa Presentación)
src/Servicios/   → Web API
src/Negocio/     → Lógica de negocio
src/AccesoDatos/ → Entity Framework Core
src/Entidades/   → Modelos
```

## Base de datos

Base **PruebaSD**, tabla **Usuario** (usulD, nombre, apellido). El script está en `database/01-create-database.sql`. Ejecútalo contra tu instancia de SQL Server antes de usar la app.

## Ejecución local

1. Ejecuta el script de base de datos contra LocalDB o SQL Server.

2. Backend:
   ```bash
   dotnet run --project src/Servicios
   ```
   API en http://localhost:5000

3. Frontend:
   ```bash
   cd Presentacion
   npm install
   npm start
   ```
   App en http://localhost:4200

## Ejecución con Docker

```bash
docker compose up -d --build
```

Después de levantar los contenedores, ejecuta el script de base de datos contra localhost:1433 (usuario sa, contraseña YourStrong@Passw0rd).

- App: http://localhost:4200
- API: http://localhost:5000
