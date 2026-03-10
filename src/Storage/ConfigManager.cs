using System;
using System.IO;
using System.Text.Json;
using AutoClips.Config;

namespace AutoClips.Storage
{
    // Clase para gestionar la configuración de la aplicación
    // Se encarga de guardar y cargar la configuración desde un archivo JSON
    public class ConfigManager
    {
        // Ruta del archivo de configuración
        private const string ConfigPath = "config.json";

        // Guarda la configuración en un archivo JSON
        // Recibe un objeto AppConfig y lo serializa a formato JSON
        public void Save(AppConfig config)
        {
            try
            {
                // Serializa el objeto config a JSON con formato legible
                string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                
                // Escribe el JSON en el archivo
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra el mensaje en consola
                Console.WriteLine($"Error al guardar configuración: {ex.Message}");
            }
        }

        // Carga la configuración desde el archivo JSON
        // Retorna un objeto AppConfig con los datos guardados
        public AppConfig Load()
        {
            try
            {
                // Si el archivo no existe, retorna una configuración vacía
                if (!File.Exists(ConfigPath))
                    return new AppConfig();

                // Lee el contenido del archivo JSON
                string json = File.ReadAllText(ConfigPath);
                
                // Convierte el JSON a objeto AppConfig
                // Si la conversión falla, retorna una configuración vacía
                return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
            }
            catch (Exception ex)
            {
                // Si ocurre un error, muestra el mensaje y retorna config vacía
                Console.WriteLine($"Error al cargar configuración: {ex.Message}");
                return new AppConfig();
            }
        }
    }
}
