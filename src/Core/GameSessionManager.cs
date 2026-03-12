#nullable enable

using System;
using AutoClips.Storage;

namespace AutoClips.Core;

public class GameSessionManager
{
    private bool sessionActive = false; // Indica si una sesión de juego esta activa
    private DateTime startTime; // Tiempo de inicio de la sesión de juego
    private readonly SessionStorage storage = new SessionStorage(); // Instancia de la clase SessionStorage
    private string? currentGame; // Nombre del juego actual

    public void Update(string? gameName)
    {
        if (gameName != null && !sessionActive)
        {
            sessionActive = true;
            startTime = DateTime.Now; // Guardar el tiempo de inicio de la sesión de juego
            currentGame = gameName;

            Console.WriteLine($"Juego iniciado: {currentGame}");
        }

        if (string.IsNullOrEmpty(gameName) && sessionActive)
        {
            sessionActive = false; // Desactivar la sesión de juego

            var endTime = DateTime.Now; // Guardar el tiempo de fin de la sesión de juego
            var duration = endTime - startTime; // Calcular la duración de la sesión

            Console.WriteLine("Juego cerrado"); //  Mostrar el juego cerrado
            Console.WriteLine($"Duracion sesión: {duration}"); // Mostrar la duración de la sesión

            var session = new GameSession
            {
                GameName = currentGame,
                StartTime = startTime,
                EndTime = endTime,
                Duration = duration
            };
            storage.SaveSession(session);
        }
    }
}