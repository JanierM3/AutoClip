namespace AutoClips.Core
{
    public class Game
    {
        public string Name { get; set; } = string.Empty;
        public string Executable { get; set; } = string.Empty;

        public Game(string name, string executable)
        {
            Name = name;
            Executable = executable;
        }
    }
}
