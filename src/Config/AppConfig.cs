using System;
using System.Collections.Generic;
using AutoClips.Core;

namespace AutoClips.Config
{
    // Clase para representar la configuración de la aplicación
    public class AppConfig
    {
        public string ClipsFolder { get; set; } // Carpeta donde se guardan los clips
        public List<Game> Games { get; set; } = new List<Game>(); // Lista de juegos configurados
    }
}