using System;

namespace RockPaperScissorsEngine
{
    public class EUndefinedPlayer : ApplicationException { };
    public class ETwoHumanPlayers : ApplicationException { };

    [Serializable]
    // A Game references two players ( IPlayers ), pass these into its constructor
    // At least one of these players must be a ComputerPlayer
    // It also has a method DecideWinner to decide who won the game
    public class Game: IGame
    {
        public IPlayer Player1 { get;}
        public IPlayer Player2 { get;}

        public GameResult DecideWinner()
        {
            return DecideWinner(Player1.Move, Player2.Move);
        }

        public GameResult DecideWinner(Move player1Move, Move player2Move)
        {
            GameResult result = GameResult.Draw;

            if ((player1Move == Move.Paper && player2Move == Move.Rock) ||
                (player1Move == Move.Rock && player2Move == Move.Scissors) ||
                (player1Move == Move.Scissors && player2Move == Move.Paper))
            {
                result = GameResult.Player1Wins;
            }

            if ((player1Move == Move.Rock && player2Move == Move.Paper) ||
               (player1Move == Move.Scissors && player2Move == Move.Rock) ||
               (player1Move == Move.Paper && player2Move == Move.Scissors))
            {
                result = GameResult.Player2Wins;
            }

            return result;
        }

        /// <summary>
        /// Create a game
        /// You pass in two IPlayers
        /// At least one player must be a ComputerPlayer
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public Game(IPlayer player1, IPlayer player2)
        {
            if ((player1 == null) || (player2 == null))
            {
                throw new EUndefinedPlayer();
            }

            if ((player1 is HumanPlayer) && (player2 is HumanPlayer))
            {
                throw new ETwoHumanPlayers();
            }

            Player1 = player1;
            Player2 = player2;

            if ( string.IsNullOrEmpty(Player1.PlayerName))
            {
                Player1.PlayerName = "Player1";
            }

            if (string.IsNullOrEmpty(Player2.PlayerName))
            {
                Player1.PlayerName = "Player2";
            }
        }
    }
}
