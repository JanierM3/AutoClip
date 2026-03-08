using System.Diagnostics;
using AutoClips.Config;
using System;

namespace AutoClips.Events;

public class GameDetector
{
    public bool CheckGames(AppConfig config) // Verificar si el juego esta abierto
    {
        var processes = Process.GetProcesses(); // Obtener los procesos

        foreach (var game in config.Games) // Recorrer la lista de juegos
        {
            var exeName = System.IO.Path
                .GetFileNameWithoutExtension(game.Executable); // Obtener el nombre del archivo

            foreach (var process in processes) // Recorrer los procesos
            {
                if (process.ProcessName //  Comparar el nombre del proceso con el nombre del ejecutable
                    .Equals(exeName,
                    StringComparison.OrdinalIgnoreCase)) // Ignorar mayúsculas
                {
                    return true; // El juego esta abierto
                }
            }
        }

        return false; // El juego no esta abierto
    }
}
