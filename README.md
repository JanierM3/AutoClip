# AutoClips

AutoClips es una herramienta de consola escrita en C# para capturar y gestionar clips de vídeo de juegos de forma automática.  Actualmente se encuentra en una fase temprana de desarrollo y los componentes de captura y procesamiento están en diseño; lo que existe hoy es un prototipo que permite registrar juegos y configurar una carpeta de destino.

> ⚙️ **Estado actual:** Menú de consola, registro de juegos y configuración persistente en `config.json`.

## Características actuales

- Registrar juegos con nombre y ruta al ejecutable
- Listar los juegos configurados
- Definir la carpeta donde se guardarán los clips
- Persistencia de la configuración en un archivo JSON
- Detectar juego automaticamente basado en procesos de window

## Estructura del proyecto

La estructura de carpetas refleja la arquitectura modular del proyecto:

```
src/
  App/          # Entrada y UI de consola
  Config/       # Clases de configuración
  Core/         # Entidades de dominio (por ejemplo, Game)
  Storage/      # Lógica de persistencia
  Capture/      # (planeado) captura de pantalla
  Buffer/       # (planeado) gestión de buffer
  ClipProcessing/ # (planeado) procesamiento de clips
  Events/       # (planeado) sistema de eventos
  Notifications/ # (planeado) notificaciones
  Updater/      # (planeado) actualizaciones automáticas
```

Los detalles de la arquitectura y los tipos clave se encuentran en la documentación dentro de `docs/overview.md`.

## Documentación

Consulta [docs/overview.md](docs/overview.md) para una visión general del proyecto, instrucciones de compilación y más información sobre cómo contribuir.

## Comenzando

### Requisitos

- .NET SDK 6.0 o superior (compatible con Windows).

### Compilar

```powershell
cd src/App
dotnet build
```

### Ejecutar

```powershell
dotnet run --project src/App/AutoClips.App.csproj
```

El programa mostrará un menú interactivo en la consola.

### Archivo de configuración

`config.json` se crea automáticamente y contiene la carpeta de clips y la lista de juegos configurados. El formato es el siguiente:

```json
{
  "ClipsFolder": "C:\\ruta\\a\\clips",
  "Games": [
    { "Name": "Ejemplo", "Executable": "C:\\ruta\\a\\juego.exe" }
  ]
}
```

## Pruebas

Aún no hay pruebas automatizadas. El directorio `tests/` está reservado para futuros proyectos de pruebas.

## Contribuir

Consulta la guía en `docs/overview.md` para pasos rápidos sobre cómo colaborar. Usa ramas dedicadas y sigue las convenciones de carpetas y espacios de nombres.

## Licencia

Pendiente de especificar.
