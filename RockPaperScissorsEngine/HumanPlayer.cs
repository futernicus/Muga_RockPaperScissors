using System;

namespace RockPaperScissorsEngine
{
    public class ENoGetMoveSubscriber : ApplicationException { };

    [Serializable]
    // HumanPlayer represents a human player of the game
    // it has no requirement to generate its own moves
    public class HumanPlayer : Player, IPlayer
    {
    }
}
