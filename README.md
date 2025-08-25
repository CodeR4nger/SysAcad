# Proyecto SYSACAD

## Descripción

Este proyecto en C# consiste en desarrollar una versión actualizada del sistema **SYSACAD**. Este manejara solicitudes de API para una interfaz web para el sistema academico.

## Funcionalidades

- Manejo de base de datos.
- Procesamiento y validación de registros únicos por identificador.
- Persistencia de cada registro en su tabla correspondiente dentro de la base de datos.
- Generacion de certificados PDF para los alumnos
- Manejo de API para solicitar información requerida por la web.

## Requisitos

### Para ejecutar la aplicación:
- Sistema operativo compatible (Windows o Linux)
- Permisos de ejecución para el archivo (`netsysacad` o `netsysacad.exe`)
- Acceso a una instancia de **PostgreSQL** con la base de datos `DEV_SYSACAD`


### Para compilar o desarrollar:
- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio o cualquier editor compatible con C# (por ejemplo, Visual Studio Code con la extensión de C#)

#### Actualizacion de los modelos de base de datos

```bash
dotnet ef migrations add NombreNuevaMigracion
dotnet ef database update
```

## Ejecución

#### Windows 
Ejecutar el archivo `netsysacad.exe`

#### Linux
1. Asegúrate de que el archivo tenga permisos de ejecución. Si no los tiene, asígnalos con:

   ```bash
   chmod +x netsysacad
    ```
2. Ejecuta el archivo directamente desde la terminal:
   ```bash
   ./netsysacad
    ```
## Desarrollador

Esta aplicación fue desarrollada por:

- Ignacio Bianchi – Desarrollo completo (backend, lógica de negocio, base de datos, documentación)
