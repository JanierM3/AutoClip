namespace AutoClips.Core
{
    // Clase para representar un juego
    /*
        En esta clase se almacenara el nombre del juego y la ruta del ejecutable
        Por ejemplo: "League of Legends", "C:\\Riot Games\\League of Legends\\LeagueClient.exe"
    */
    public class Game
    {
        // Propiedades
        public string Name { get; set; }
        public string Executable { get; set; }

        public Game(string name, string executable) // Constructor
        {
            // Inicializar las propiedades
            Name = name;
            Executable = executable;
        }
    }
}
