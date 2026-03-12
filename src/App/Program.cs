using System;
using System.IO;
using System.Threading;
using AutoClips.Config;
using AutoClips.Core;
using AutoClips.Storage;
using AutoClips.Events;

namespace AutoClips.App
{
    class Program
    {
        static void Main()
        {
            ConfigManager manager = new ConfigManager(); // Crear una instancia de ConfigManager
            AppConfig config = manager.Load(); // Cargar la configuración

            while (true)
            {
                Console.WriteLine("\n=== AutoClips ===");
                Console.WriteLine("1 - Registrar juego");
                Console.WriteLine("2 - Ver juegos");
                Console.WriteLine("3 - Definir carpeta clips");
                Console.WriteLine("4 - Detectar juegos abiertos");
                Console.WriteLine("5 - Iniciar GameWatcher");
                Console.WriteLine("6 - Iniciar HotkeyListener (F8)");
                Console.WriteLine("7 - Salir");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddGame(config);
                        manager.Save(config);
                        Pause();
                        break;

                    case "2":
                        ShowGames(config);
                        Pause();
                        break;

                    case "3":
                        SetFolder(config);
                        manager.Save(config);
                        Pause();
                        break;

                    case "4":
                        GameDetector detector = new GameDetector();
                        string detectedGame = detector.DetectGame(config);
                        if (detectedGame != null)
                        {
                            Console.WriteLine($"Juego abierto: {detectedGame}");
                        }
                        else
                        {
                            Console.WriteLine("No hay juegos registrados abiertos.");
                        }
                        Pause();
                        break;

                    case "5":
                        GameWatcher watcher = new GameWatcher();
                        Thread watcherThread = new Thread(() => watcher.Start(config));
                        watcherThread.IsBackground = true;
                        watcherThread.Start();
                        Console.WriteLine("GameWatcher iniciado en segundo plano");
                        Pause();
                        break;

                    case "6":
                        GameDetector detectorForListener = new GameDetector();
                        string gameForListener = detectorForListener.DetectGame(config);
                        if (gameForListener == null)
                        {
                            Console.WriteLine("No hay ningun juego abierto. Abre un juego primero.");
                            Pause();
                            break;
                        }

                        HotkeyListener listener = new HotkeyListener();
                        Thread listenerThread = new Thread(() => listener.Listen());
                        listenerThread.IsBackground = true;
                        listenerThread.Start();
                        Console.WriteLine($"HotkeyListener iniciado para {gameForListener} (presiona F8 para clip)");
                        Pause();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pause();
                        break;
                }
            }
        }

        static void AddGame(AppConfig config)
        {
            Console.Write("Nombre del juego: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("El nombre no puede estar vacio.");
                return;
            }

            Console.Write("Executable (.exe): ");
            string exe = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(exe))
            {
                Console.WriteLine("El executable no puede estar vacio.");
                return;
            }

            if (!exe.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("El archivo debe tener extension .exe");
                return;
            }

            config.Games.Add(new Game(name, exe));
            Console.WriteLine($"Juego '{name}' registrado correctamente.");
        }

        static void ShowGames(AppConfig config)
        {
            if (config.Games.Count == 0)
            {
                Console.WriteLine("No hay juegos registrados.");
                return;
            }

            Console.WriteLine($"\nJuegos registrados ({config.Games.Count}):");
            foreach (var game in config.Games)
            {
                Console.WriteLine($"  - {game.Name} ({game.Executable})");
            }
        }

        static void SetFolder(AppConfig config)
        {
            Console.Write("Ruta carpeta clips: ");
            string folder = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(folder))
            {
                Console.WriteLine("La ruta no puede estar vacia.");
                return;
            }

            if (!Directory.Exists(folder))
            {
                Console.WriteLine("La carpeta no existe. Desea crearla? (S/N): ");
                string response = Console.ReadLine();
                if (response?.Trim().Equals("S", StringComparison.OrdinalIgnoreCase) == true)
                {
                    try
                    {
                        Directory.CreateDirectory(folder);
                        Console.WriteLine("Carpeta creada correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al crear carpeta: {ex.Message}");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            config.ClipsFolder = folder;
            Console.WriteLine("Carpeta de clips configurada.");
        }

        static void Pause()
        {
            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }
}