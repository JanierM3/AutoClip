using AutoClips.Config;
using AutoClips.Core;
using System.Threading;
using System;

namespace AutoClips.Events;

public class GameWatcher
{
    private readonly GameDetector detector = new GameDetector(); // Crear una instancia de GameDetector
    private readonly GameSessionManager sessionManager = new GameSessionManager(); // Crear una instancia de GameSessionManager

    public void Start(AppConfig config)
    {
        Console.WriteLine("GameWatcher iniciado");

        while (true)
        {
            var detectedGame = detector.DetectGame(config); // Verificar si el juego esta abierto

            sessionManager.Update(detectedGame); // Actualizar el estado de la sesión

            Thread.Sleep(5000); // Esperar 5 segundos
        }
    }
}
