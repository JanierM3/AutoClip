using System.Text.Json;
using System;
using System.IO;
using System.Collections.Generic;

namespace AutoClips.Core;

public class SessionStats
{
    private const string FileName = "sessions.json";

    public TimeSpan GetTotalPlayTime()
    {
        /*
        - Si el archivo no existe, devuelve un TimeSpan.Zero (0:00:00)
        - Lee todo el archivo como texto
        - Convierte el archivo json a una lista de sesiones
        */
        if (!File.Exists(FileName))
            return TimeSpan.Zero; 

        try
        {
            var json = File.ReadAllText(FileName); 
            var sessions = JsonSerializer.Deserialize<List<GameSession>>(json); 

            /*
            - Por seguridad: si la deserialización falla (archivo corructo), retorna 0
            - Variable para almacenar la duración total
            */
            if (sessions == null)
                return TimeSpan.Zero; 

            TimeSpan total = TimeSpan.Zero;

            /*
            - Inicializa un TimeSpan total en 0
            - Recorre cada sesion y suma su duración
            - Retorna el total acumulado
            */
            foreach (var session in sessions)
            {
                total += session.Duration;
            }
            return total;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error al leer estadisticas de sesiones: {ex.Message}");
            return TimeSpan.Zero;
        }
    }
}