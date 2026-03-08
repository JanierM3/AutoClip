using System.Text.Json;
using AutoClips.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoClips.Storage;

public class SessionStorage
{
    private const string FileName = "sessions.json";

    public void SaveSession(GameSession session)
    {
        List<GameSession> sessions;

        if (File.Exists(FileName))
        {
            var json = File.ReadAllText(FileName);
            sessions = JsonSerializer.Deserialize<List<GameSession>>(json) ?? new List<GameSession>();
        }
        else
        {
            sessions = new List<GameSession>();
        }

        sessions.Add(session);

        var newJson = JsonSerializer.Serialize(sessions, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FileName, newJson);
    }
}
