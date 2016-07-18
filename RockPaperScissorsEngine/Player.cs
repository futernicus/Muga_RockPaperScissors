namespace RockPaperScissorsEngine
{
    /// <summary>
    /// Player is an abstract class
    /// Create a HumanPlayer or a ComputerPlayer instead
    /// </summary>
    public abstract class Player
    {
        public string PlayerName { get; set; }
        public Move Move { get; set; }
    }
}
