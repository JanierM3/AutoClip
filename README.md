# AutoClips

AutoClips es una herramienta de consola escrita en C# para capturar y gestionar clips de vídeo de juegos de forma automática. Actualmente se encuentra en una fase temprana de desarrollo y los componentes de captura y procesamiento están en diseño; lo que existe hoy es un prototipo que permite registrar juegos, detectar cuando están en ejecución y configurar una carpeta de destino.

> ⚙️ **Estado actual:** Menú de consola, registro de juegos, detección automática de juegos, monitoreo de sesiones, hotkey F8, y configuración persistente en JSON.

## Características Actuales

- Registrar juegos con nombre y ruta al ejecutable
- Listar los juegos configurados
- Definir la carpeta donde se guardarán los clips
- Persistencia de la configuración en `config.json`
- Detectar juego automáticamente basado en procesos de Windows
- Monitoreo continuo de juegos (GameWatcher)
- Registro de sesiones de juego (inicio, fin, duración)
- Detección de tecla F8 globalmente
- Ver estadísticas de tiempo total jugado

## Estructura del Proyecto

La estructura de carpetas refleja la arquitectura modular del proyecto:

```
src/
  App/          # Entrada y UI de consola
  Config/       # Clases de configuración
  Core/         # Entidades de dominio (Game, GameSession, HotkeyListener)
  Storage/      # Lógica de persistencia (ConfigManager, SessionStorage)
  Events/       # Sistema de eventos (GameDetector, GameWatcher)
  Capture/      # (planeado) captura de pantalla
  Buffer/       # (planeado) gestión de buffer
  ClipProcessing/ # (planeado) procesamiento de clips
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
dotnet build
```

### Ejecutar

```powershell
dotnet run
```

El programa mostrará un menú interactivo en la consola:

```
=== AutoClips ===
1 - Registrar juego
2 - Ver juegos
3 - Definir carpeta clips
4 - Detectar juegos abiertos
5 - Iniciar GameWatcher
6 - Iniciar HotkeyListener (F8)
7 - Salir
```

### Archivo de Configuración

`config.json` se crea automáticamente y contiene la carpeta de clips y la lista de juegos configurados. El formato es el siguiente:

```json
{
  "ClipsFolder": "C:\\ruta\\a\\clips",
  "Games": [
    { "Name": "Ejemplo", "Executable": "C:\\ruta\\a\\juego.exe" }
  ]
}
```

### Archivo de Sesiones

`sessions.json` se crea automáticamente cuando termina una sesión de juego:

```json
[
  {
    "GameName": "League of Legends",
    "StartTime": "2024-01-15T14:30:00",
    "EndTime": "2024-01-15T15:45:00",
    "Duration": "01:15:00"
  }
]
```

## Pruebas

Aún no hay pruebas automatizadas. El directorio `tests/` está reservado para futuros proyectos de pruebas.

## Contribuir

Consulta la guía en `docs/overview.md` para pasos rápidos sobre cómo colaborar. Usa ramas dedicadas y sigue las convenciones de carpetas y espacios de nombres.

## Licencia

Pendiente de especificar.
