using System.Text.Json;
using AutoClips.Core;
using System.Collections.Generic;
using System.IO;
using System;

namespace AutoClips.Storage;

public class SessionStorage
{
    private const string FileName = "sessions.json";

    public void SaveSession(GameSession session)
    {
        /*
        - Duarda una nueva sesion de juego en el archivo JSON, preservando las existencias.
        */
        List<GameSession> sessions;

        try
        {
            /*
            - Si el archivo existe: Lee el contenido y lo convierte a lista 
            - Usa ?? (null-coalescing): si la deserialización retorna null, crea una lista vacía linea 26
            - Si no existe: Crea una lista vacía
            */
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                sessions = JsonSerializer.Deserialize<List<GameSession>>(json) ?? new List<GameSession>();
            }
            else
            {
                sessions = new List<GameSession>();
            }

            sessions.Add(session); // Agregar la nueva sesion a la lista de memoria

            /*
            - Convierte la lista completa a JSON
            - WriteIndented: true = formato legible (con saltos de línea y sangría)
            */
            var newJson = JsonSerializer.Serialize(sessions, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FileName, newJson); // Sobreescribe el archivo con el JSON actualizado
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error al guardar la sesion: {ex.Message}");
        }
    }
}
