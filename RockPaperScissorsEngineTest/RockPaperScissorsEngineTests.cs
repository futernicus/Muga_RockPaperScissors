using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsEngine;

namespace RockPaperScissorsEngineTest
{
    [TestClass]
    public class RockPaperScissorsEngineTests
    {
        [TestMethod]
        [ExpectedException(typeof(ETwoHumanPlayers))]
        public void MaxOneHumanPlayer()
        {
            IGame game = new Game(new HumanPlayer(), new HumanPlayer());
        }

        [TestMethod]
        [ExpectedException(typeof(EUndefinedPlayer))]
        public void BothPlayersMustBeDefined()
        {
            IGame game = new Game(null,null);
        }

        [TestMethod]
        public void PaperBeatsRock()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Paper, Move.Rock);
            Assert.IsTrue(gameResult == GameResult.Player1Wins, "Paper should beat rock");
        }

        [TestMethod]
        public void RockBeatsScissors()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Rock, Move.Scissors);
            Assert.IsTrue(gameResult == GameResult.Player1Wins, "Rock should beat Scissors");
        }

        [TestMethod]
        public void ScissorsBeatsPaper()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Scissors, Move.Paper);
            Assert.IsTrue(gameResult == GameResult.Player1Wins, "Scissors should beat paper");
        }

        [TestMethod]
        public void PaperDrawsPaper()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Paper, Move.Paper);
            Assert.IsTrue(gameResult == GameResult.Draw, "Paper should draw paper");
        }

        [TestMethod]
        public void RockDrawsRock()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Rock, Move.Rock);
            Assert.IsTrue(gameResult == GameResult.Draw, "Rock should draw rock");
        }

        [TestMethod]
        public void ScissorsDrawsScissors()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Scissors, Move.Scissors);
            Assert.IsTrue(gameResult == GameResult.Draw, "Scissors should draw scissors");
        }

        [TestMethod]
        public void RockLosesPaper()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Rock, Move.Paper);
            Assert.IsTrue(gameResult == GameResult.Player2Wins, "Rock should lose to paper");
        }


        [TestMethod]
        public void ScissorsLosesRock()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Scissors, Move.Rock);
            Assert.IsTrue(gameResult == GameResult.Player2Wins, "Scissors should lose to rock");
        }

        [TestMethod]
        public void PaperLosesScissors()
        {
            IGame game = new Game(new ComputerPlayer(), new ComputerPlayer());
            GameResult gameResult = game.DecideWinner(Move.Paper, Move.Scissors);
            Assert.IsTrue(gameResult == GameResult.Player2Wins, "Paper should lose to scissors");
        }

        [TestMethod]
        // Expect a even distribution of moves from a computer player
        public void ComputerGeneratesExpectedMoves()
        {
            // Check computer generates all possible moves, with reasonably equal distribution
            int rockCount = 0, paperCount = 0, scissorsCount = 0;

            int gameCount = 1000;
            for( int gameNumber = 0; gameNumber < gameCount; gameNumber++)
            {
                IPlayer player = new ComputerPlayer();

                switch (player.Move)
                {
                    case Move.Paper:
                        paperCount++;
                        break;
                    case Move.Rock:
                        rockCount++;
                        break;
                    case Move.Scissors:
                        scissorsCount++;
                        break;
                }
            }

            Assert.IsTrue(paperCount > 0, "Computer generation of paper count is zero");
            Assert.IsTrue(rockCount > 0, "Computer generation of rock count is zero");
            Assert.IsTrue(scissorsCount > 0, "Computer generation of scissors count is zero");

            // We expect roughly equal distribution of moves between available choices
            // Testing for at least half of that expected distribution avoids variance causing this test to fail
            int minimalExpectedCountEachMove = gameCount / 6;
           
            Assert.IsTrue(paperCount > minimalExpectedCountEachMove, "Computer generation of paper count is zero");
            Assert.IsTrue(rockCount > minimalExpectedCountEachMove, "Computer generation of rock count is zero");
            Assert.IsTrue(scissorsCount > minimalExpectedCountEachMove, "Computer generation of scissors count is zero");
        }
    }
}
