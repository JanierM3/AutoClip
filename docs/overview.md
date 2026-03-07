# AutoClips Overview

AutoClips is a simple, extensible tool written in C# that is intended to capture and manage video clips of games automatically. The project is still in an early stage; the current implementation is a console-based prototype for registering games and configuring where clips will be stored. Future work will add capture, buffering, processing, notifications and an updater.

## Current Functionality

- **Game registration** – users can add a game by providing a name and the path to its executable.
- **Game listing** – view the list of games that have been configured.
- **Clips folder configuration** – choose the directory where clips will be saved.
- **Persistent configuration** – settings are serialized to `config.json` using `System.Text.Json`.

## Architecture

The project adheres to a modular layout under the `src/` folder.

```
src/
  App/          # Entry point and user interaction (console UI)
  Config/       # Data transfer objects for configuration
  Core/         # Domain entities (e.g. `Game`)
  Storage/      # Persistence logic (e.g. `ConfigManager`)
  Capture/      # (planned) screen‑capture components
  Buffer/       # (planned) in‑memory buffering of video data
  ClipProcessing/ # (planned) processing logic for clips
  Events/       # (planned) eventing system
  Notifications/ # (planned) notification support
  Updater/      # (planned) update mechanism
```

Each namespace mirrors the folder name and contains related classes.  At present only `App`, `Config`, `Core` and `Storage` include code.

### Key types

* `AutoClips.Core.Game` – represents a game to monitor. Contains `Name` and `Executable` properties.
* `AutoClips.Config.AppConfig` – holds the user’s settings (clip folder and list of games).
* `AutoClips.Storage.ConfigManager` – reads/writes the configuration to a JSON file named `config.json`.
* `AutoClips.App.Program` – console UI. Drives a simple menu and delegates to helper methods.

## Building and Running

### Prerequisites

* [.NET 6 SDK](https://dotnet.microsoft.com/download) or later installed on Windows.

### Build

```powershell
# from workspace root
cd src/App
dotnet build
```

### Run

```powershell
# run using the project file
dotnet run --project src/App/AutoClips.App.csproj
```

A console menu will appear with options to add games, view games, set the clips folder, or exit.

## Configuration File

Settings are stored in `config.json` in the working directory of the application. The file is automatically created when the program saves the configuration for the first time.  Example structure:

```json
{
  "ClipsFolder": "C:\\Users\\Siete\\Videos\\Clips",
  "Games": [
    {
      "Name": "League of Legends",
      "Executable": "C:\\Riot Games\\League of Legends\\LeagueClient.exe"
    }
  ]
}
```

## Testing

There are no unit tests yet. The `tests/` directory exists to hold future test projects.

## Roadmap

Planned features include:

- Automatic screen capture when a registered game is running
- In‑memory buffering to avoid recording entire sessions
- Clip processing (trimming, encoding)
- Storage providers for local/remote clips
- Event subsystem for decoupled components
- Notification support (desktop alerts, etc.)
- Self‑updater to keep the application current

## Contributing

1. Fork the repository
2. Add your feature or fix in a new branch
3. Follow the existing folder/namespace conventions
4. Submit a pull request

## License

TBD – add license information when decided.
