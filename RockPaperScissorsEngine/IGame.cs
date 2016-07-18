namespace RockPaperScissorsEngine
{
    public enum Move { Rock, Paper, Scissors };
    public enum GameResult {  Player1Wins, Player2Wins, Draw };

    // Game is a concrete class which implements the IGame interface
    public interface IGame
    {
        IPlayer Player1 { get; }
        IPlayer Player2 { get; }
        GameResult DecideWinner();
        GameResult DecideWinner(Move player1Move, Move player2Move);
    }
}
