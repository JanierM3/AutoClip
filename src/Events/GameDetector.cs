#nullable enable // Habilitar la anotación nullable
/*
"The annotation for nullable reference types should only be used in code within a '#nullable' annotations context"
Igual esto se puede desabilitar asi #nullable disable y listo solo quitas el ? de string, en si puedes quitar el ? de string y ya
*/

using System.Diagnostics;
using AutoClips.Config;
using System;
using System.IO;

namespace AutoClips.Events;

public class GameDetector
{
    public string? DetectGame(AppConfig config)
    {
        var processes = Process.GetProcesses();

        foreach (var game in config.Games)
        {
            var exeName = Path.GetFileNameWithoutExtension(game.Executable);

            foreach (var process in processes)
            {
                if (process.ProcessName.Equals(exeName, StringComparison.OrdinalIgnoreCase))
                {
                    return game.Name;
                }
            }
        }

        return null;
    }
}
