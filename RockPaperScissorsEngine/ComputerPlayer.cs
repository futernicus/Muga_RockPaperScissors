using System;

namespace RockPaperScissorsEngine
{
    [Serializable]
    // ComputerPlayer represents a automatic player of the game
    // When you create one, it decides its move
    // You can create new moves by calling the GetMove method
    public class ComputerPlayer : Player, IPlayer
    {
        static Array values = Enum.GetValues(typeof(Move));

        // If we created a new Random instance repeatedly we wouldnt get a good distribution of moves
        static Random random = new Random();

        public ComputerPlayer()
        {
            this.GetMove();
        }

        /// <summary>
        /// Generate a random game move for a computer player
        /// A better approach would be to analyse the other players moves for patterns
        /// However the specification is for a minimum viable product
        /// </summary>
        /// <returns>Move</returns>
       public Move GetMove()
       {
            Move randomMove;

            // the Random class is not type safe so we lock it here
            lock (random)
            {
                randomMove = (Move)values.GetValue(random.Next(values.Length));
            }

            Move = randomMove;
            return randomMove;
        }

    }
}
