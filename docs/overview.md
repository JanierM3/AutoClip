# AutoClips Visión General

AutoClips es una herramienta simple y extensible escrita en C# diseñada para capturar y gestionar clips de video de juegos automáticamente. El proyecto se encuentra en una etapa temprana; la implementación actual es un prototipo basado en consola para registrar juegos y configurar dónde se almacenarán los clips. El trabajo futuro añadirá captura, almacenamiento en búfer, procesamiento, notificaciones y un actualizador.

## Funcionalidad Actual

- **Registro de juegos** – los usuarios pueden agregar un juego proporcionando un nombre y la ruta a su ejecutable.
- **Listado de juegos** – ver la lista de juegos configurados.
- **Configuración de carpeta de clips** – elegir el directorio donde se guardarán los clips.
- **Configuración persistente** – la configuración se guarda en `config.json` usando `System.Text.Json`.
- **Detección automática de juegos** – detecta cuando un juego registrado está en ejecución basado en los procesos de Windows.
- **Monitoreo de sesiones** – registra el tiempo de juego (inicio, fin y duración).
- **Hotkey (F8)** – detecta la tecla F8 globalmente para solicitar un clip.

## Arquitectura

El proyecto sigue un diseño modular bajo la carpeta `src/`.

```
src/
  App/          # Punto de entrada e interacción de usuario (UI de consola)
  Config/       # Objetos de transferencia de datos para configuración
  Core/         # Entidades de dominio (ej. `Game`, `GameSession`)
  Storage/      # Lógica de persistencia (ej. `ConfigManager`, `SessionStorage`)
  Events/       # Sistema de eventos (GameDetector, GameWatcher, HotkeyListener)
  Capture/      # (planificado) componentes de captura de pantalla
  Buffer/       # (planificado) almacenamiento en memoria de datos de video
  ClipProcessing/ # (planificado) lógica de procesamiento de clips
  Notifications/ # (planificado) soporte de notificaciones
  Updater/      # (planificado) mecanismo de actualización
```

Cada namespace refleja el nombre de la carpeta y contiene clases relacionadas. Actualmente solo `App`, `Config`, `Core`, `Storage` y `Events` contienen código.

### Tipos Clave

- `AutoClips.Core.Game` – representa un juego a monitorear. Contiene propiedades `Name` y `Executable`.
- `AutoClips.Core.GameSession` – representa una sesión de juego registrada con inicio, fin y duración.
- `AutoClips.Config.AppConfig` – contiene la configuración del usuario (carpeta de clips y lista de juegos).
- `AutoClips.Storage.ConfigManager` – lee/escribe la configuración en un archivo JSON llamado `config.json`.
- `AutoClips.Storage.SessionStorage` – guarda las sesiones de juego en `sessions.json`.
- `AutoClips.Events.GameDetector` – detecta si un juego registrado está en ejecución.
- `AutoClips.Events.GameWatcher` – monitorea continuamente los juegos en un bucle.
- `AutoClips.Events.HotkeyListener` – detecta la tecla F8 globalmente.
- `AutoClips.Core.SessionStats` – calcula el tiempo total de juego desde `sessions.json`.
- `AutoClips.App.Program` – UI de consola. Controla un menú simple y delega a métodos auxiliares.

## Compilación y Ejecución

### Requisitos Previos

- [.NET SDK 6](https://dotnet.microsoft.com/download) o superior instalado en Windows.

### Compilar

```powershell
# desde la raíz del proyecto
dotnet build
```

### Ejecutar

```powershell
dotnet run
```

Aparecerá un menú de consola con opciones para agregar juegos, ver juegos, establecer la carpeta de clips, detectar juegos, iniciar el monitoreo de juegos, iniciar el listener de F8, o salir.

## Archivos de Configuración

### config.json

La configuración se guarda en `config.json` en el directorio de trabajo de la aplicación. El archivo se crea automáticamente cuando el programa guarda la configuración por primera vez. Ejemplo:

```json
{
  "ClipsFolder": "C:\\Users\\Usuario\\Videos\\Clips",
  "Games": [
    {
      "Name": "League of Legends",
      "Executable": "C:\\Riot Games\\League of Legends\\LeagueClient.exe"
    }
  ]
}
```

### sessions.json

Las sesiones de juego se guardan automáticamente en `sessions.json` cuando un juego se cierra. Ejemplo:

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

Aún no hay pruebas unitarias. El directorio `tests/` existe para futuros proyectos de pruebas.

## Roadmap

Características planeadas:

- Captura automática de pantalla cuando un juego registrado está en ejecución
- Almacenamiento en búfer en memoria para evitar grabar sesiones completas
- Procesamiento de clips (recorte, codificación)
- Proveedores de almacenamiento para clips locales/remotos
- Subsistema de eventos para componentes desacoplados
- Soporte de notificaciones (alertas de escritorio, etc.)
- Auto-actualizador para mantener la aplicación actualizada

## Cómo Contribuir

1. Haz fork del repositorio
2. Agrega tu característica o corrección en una nueva rama
3. Sigue las convenciones existentes de carpetas y namespaces
4. Envía un pull request

## Licencia

Por determinar – agregar información de licencia cuando se decida.
