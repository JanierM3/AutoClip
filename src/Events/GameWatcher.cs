using AutoClips.Config;
using System.Threading;
using System;

namespace AutoClips.Events;

public class GameWatcher
{
    private readonly GameDetector detector = new GameDetector(); // Instancia de GameDetector
    private bool gameRunning = false; // Indica si el juego esta abierto

    public void Start(AppConfig config) // Iniciar GameWatcher
    {
        Console.WriteLine("GameWatcher iniciado..."); // Mostrar mensaje

        while (true)
        {
            bool detected = detector.CheckGames(config); // Verificar si el juego esta abierto

            if (detected && !gameRunning) // Si el juego esta abierto y no esta activo
            {
                Console.WriteLine("Juego detectado. AutoClips activado."); // Activar AutoClips
                gameRunning = true; // Establecer el juego como abierto
            }

            if (!detected && gameRunning) // Si el juego esta cerrado y esta activo
            {
                Console.WriteLine("Juego cerrado. AutoClips desactivado."); // Desactivar AutoClips
                gameRunning = false; // Establecer el juego como cerrado
            }

            Thread.Sleep(5000); // Esperar 5 segundos
        }
    }
}
