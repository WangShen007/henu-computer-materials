namespace ServerConsoleExamples.ch07.Common
{
    internal class Player
    {
        public User? PlayingUser { get; set; } = null;

        /// <summary>是否已经入座</summary>
        public bool Sitdown { get; set; }

        /// <summary>是否已经开始</summary>
        public bool Started { get; set; }
        public Player()
        {
        }
    }
}
