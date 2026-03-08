using System;
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
                Console.WriteLine("6 - Salir");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddGame(config); // Agregar juego
                        manager.Save(config); // Guardar la configuración
                        break;

                    case "2":
                        ShowGames(config); // Mostrar juegos
                        break;

                    case "3":
                        SetFolder(config); // Definir carpeta
                        manager.Save(config); // Guardar la configuración
                        break;

                    case "4":
                        GameDetector detector = new GameDetector(); // Crear una instancia de GameDetector
                        detector.CheckGames(config); // Comprobar juegos
                        break;

                    case "5":
                        GameWatcher watcher = new GameWatcher(); // Crear una instancia de GameWatcher
                        watcher.Start(config); // Iniciar GameWatcher
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Opcion no valida."); // Mostrar mensaje de error
                        break;
                }
            }
        }

        static void AddGame(AppConfig config) // Agregar juego
        {
            Console.Write("Nombre del juego: ");
            string name = Console.ReadLine();

            Console.Write("Executable (.exe): "); // Ruta del ejecutable
            string exe = Console.ReadLine();

            config.Games.Add(new Game(name, exe)); // Agregar el juego a la configuración
        }

        static void ShowGames(AppConfig config) // Mostrar juegos
        {
            foreach (var game in config.Games) // Recorrer la lista de juegos
            {
                Console.WriteLine($"{game.Name} - {game.Executable}"); // Mostrar el juego
            }
        }

        static void SetFolder(AppConfig config) // Definir carpeta
        {
            Console.Write("Ruta carpeta clips: ");
            config.ClipsFolder = Console.ReadLine(); // Asignar la ruta
        }
    }
}
