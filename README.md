
# PruebaGo - Sistema de Gestión de Tareas

Este es un proyecto Full-Stack desarrollado como prueba técnica, que incluye una API REST y un cliente web con Angular.

## Tecnologías Utilizadas

* **Backend:** .NET 9.0 (C#) con Entity Framework Core.
* **Frontend:** Angular 19 con Tailwind CSS / CSS3.
* **Base de Datos:** PostgreSQL.
* **Contenedores:** Docker para la infraestructura de base de datos.
* **Patrones:** Repository Pattern, Unit of Work y DTOs.

---

##  Requisitos Previos

* [.NET SDK 9.0+](https://dotnet.microsoft.com/download)
* [Node.js LTS](https://nodejs.org/)
* [Angular CLI](https://angular.io/cli)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) 

---

## Instalación y Configuración
Para realizar la instalación local, se tiene que editar el archivo TaskApi/appsettings.json

### 1. Base de Datos (PostgreSQL)

Usando Docker, levanta la base de datos con:
```bash
docker-compose up -d
```
## Backend (API)
Desde la carpeta raíz, navega a la carpeta de la API
```
cd TaskApi
dotnet restore
dotnet ef database update
dotnet run 
```
La API estará corriendo en: http://localhost:5246

## Frontend (Angular)
Desde una  terminal, navega a la carpeta del cliente:
```
cd Frontend/PruebaCliente
npm install
ng serve
```
La aplicación estará disponible en: http://localhost:4200

## Arquitectura 
* Persistencia: Se utiliza PostgreSQL con Npgsql.EnableLegacyTimestampBehavior para el manejo correcto de fechas en .NET.
* Desacoplamiento: El uso de Unit of Work asegura que las transacciones a la base de datos sean consistentes y centralizadas.
* Seguridad: Configuración de políticas de CORS para permitir la comunicación segura entre el dominio del frontend y el backend.
* Frontend: Implementación de servicios para el consumo de la API y manejo de estados para el filtrado de tareas en tiempo real.