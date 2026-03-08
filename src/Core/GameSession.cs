using System;

namespace AutoClips.Core
{
    public class GameSession
    {
        public string GameName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}