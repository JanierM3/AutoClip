using System.IO;
using System.Text.Json;
using AutoClips.Config;

namespace AutoClips.Storage
{
    // Clase para gestionar la configuración
    // Cargar la configuración desde el archivo JSON
    // Guardar la configuración en el archivo JSON
    public class ConfigManager
    {
        private string configPath = "config.json";

        // Cargar la configuración desde el archivo JSON
        public void Save(AppConfig config)
        {
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }); // Formatear el JSON con tabulaciones y salto de linhas
            File.WriteAllText(configPath, json); // Guardar el JSON en el archivo
        }

        public AppConfig Load() // Cargar la configuración desde el archivo JSON
        {
            // Si el archivo no existe, crear una nueva configuración
            if (!File.Exists(configPath))
                return new AppConfig();

            string json = File.ReadAllText(configPath); // Leer el contenido del archivo
            return JsonSerializer.Deserialize<AppConfig>(json); // Deserializar el JSON
        }
    }
}
