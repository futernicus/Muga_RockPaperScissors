using System;

namespace RockPaperScissors.Models
{
    public enum PlayerMoveChoices { computer, rock, paper, scissors }

    [Serializable]
    // This Model class is bound to the Index view
    // It contains properties enabling use of the RockPaperScissorsEngine to decide the game winner
    public class GameModel
    {
        public PlayerMoveChoices Player1Move { get; set; }
        public PlayerMoveChoices Player2Move { get; set; }
        public string GameResult { get; set; }
    }
}