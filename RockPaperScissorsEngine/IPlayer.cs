namespace RockPaperScissorsEngine
{
    public interface IPlayer
    {
        string PlayerName { get; set; }
        Move Move { get; set; }
    }
}
