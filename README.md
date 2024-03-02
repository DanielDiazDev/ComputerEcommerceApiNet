# API de Computer Ecommerce en .NET 8

Este proyecto es una API para una tienda en línea especializada en productos de computación. Sus funcionalidades principales abarcan la gestión de categorías y productos, incluyendo la búsqueda y listado de estos, así como la administración de la lógica de negocio relacionada.

## Configuración del Proyecto

### Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)

### Pasos para Configurar el Proyecto

1. Clonar este repositorio en tu máquina local.
2. Abrir la solución en Visual Studio 2022 o superior.
3. Configurar la cadena de conexión a la base de datos en `appsettings.json`.
4. Ejecutar el script SQL proporcionado (`sqlData.sql`) para crear la base de datos y las tablas necesarias.
5. Compilar y ejecutar la aplicación.

## Funcionalidades Principales

- **Gestión de Categorías:** Permite agregar, editar y eliminar categorías de productos.
- **Gestión de Productos:** Permite agregar, editar y eliminar productos, así como buscar y listar productos disponibles.
- **Lógica de Negocio:** Implementa la lógica de negocio relacionada con el ecommerce, como cálculos de precios y disponibilidad.

## Tecnologías Utilizadas

- **.NET 8:** Para el desarrollo de la API.
- **Entity Framework Core:** Para el acceso a la base de datos.
- **SQL Server:** Como base de datos para almacenar la información.

## Contribuciones

Si deseas contribuir a este proyecto, ¡no dudes en hacer un *pull request*!
