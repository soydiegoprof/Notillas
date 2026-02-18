# Notillas

Aplicación de notas multiplataforma construida con **.NET MAUI**.

## Descripción

**Notillas** permite crear, editar y eliminar notas de forma sencilla, con una interfaz limpia inspirada en la paleta del icono del proyecto (tonos mostaza y contraste oscuro para buena legibilidad).

## Características

- Crear notas con título y contenido.
- Editar notas existentes.
- Eliminar notas.
- Persistencia local en JSON (`FileSystem.AppDataDirectory`).
- Orden automático por fecha de actualización.
- UI pensada para Android y Windows.

## Estructura del proyecto

- `Notillas/Models`: modelos de dominio.
- `Notillas/Services`: servicios (persistencia de datos).
- `Notillas/ViewModels`: lógica MVVM y comandos.
- `Notillas/Views`: interfaz XAML.
- `Notillas/Resources`: iconos, imágenes y recursos visuales.

## Plataformas objetivo

Definidas en `Notillas/Notillas.csproj`:

- `net10.0-android`
- `net10.0-windows10.0.19041.0`

## Requisitos de entorno

- SDK de .NET con soporte MAUI.
- Workloads MAUI instalados.
- Para Windows: SDK/entorno compatible con Win10 19041+.
- Para Android: herramientas de Android (emulador o dispositivo).

> Nota: aunque la solución se puede abrir como proyecto .NET, **.NET MAUI moderno se desarrolla normalmente con Visual Studio 2022 o superior** (no Visual Studio 2016).

## Ejecución (referencia)

```bash
# Restaurar dependencias
dotnet restore Notillas.sln

# Compilar Android
dotnet build Notillas/Notillas.csproj -f net10.0-android

# Compilar Windows
dotnet build Notillas/Notillas.csproj -f net10.0-windows10.0.19041.0
```

## Estado actual

Base funcional de CRUD de notas con persistencia local y estilo visual inicial.
