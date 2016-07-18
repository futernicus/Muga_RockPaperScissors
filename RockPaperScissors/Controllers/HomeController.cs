using RockPaperScissors.Models;
using RockPaperScissorsEngine;
using System;
using System.Web.Mvc;

namespace RockPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            GameModel gameModel = new GameModel();

            // Set the initial game mode as computer versus computer
            gameModel.Player1Move = PlayerMoveChoices.computer;
            gameModel.Player2Move = PlayerMoveChoices.computer;

            gameModel.GameResult = string.Empty;

            return View(gameModel);
        }

        [HttpPost]
        /// This method is called when the Play button has been pressed
        /// The model is bound to the form so arrives hydrated from the UI
        /// The responsibility of this method is to use the GameEngine to display the winner and display this
        public ActionResult Index(GameModel gameModel)
        {
            gameModel.GameResult = string.Empty;
            IPlayer player1 = null;
            IPlayer player2 = null;

            string playerChoices = string.Empty;

            // Set Player1
            if ( gameModel.Player1Move == PlayerMoveChoices.computer)
            {
                player1 = new ComputerPlayer();
            }
            else
            {
                player1 = new HumanPlayer();

                switch(gameModel.Player1Move)
                {
                    case PlayerMoveChoices.paper:
                        player1.Move = Move.Paper;
                        break;
                    case PlayerMoveChoices.scissors:
                        player1.Move = Move.Scissors;
                        break;
                    case PlayerMoveChoices.rock:
                        player1.Move = Move.Rock;
                        break;
                }
            }

            // Set Player2
            if (gameModel.Player2Move == PlayerMoveChoices.computer)
            {
                player2 = new ComputerPlayer();
            }
            else
            {
                throw new ApplicationException();
            }

            IGame game = new Game(player1, player2);
            GameResult gameResult = game.DecideWinner();

            string playerChoicesDescription = " (" + player1.Move.ToString() + "/" + player2.Move.ToString() + ")";

            switch(gameResult)
            {
                case GameResult.Draw:
                    gameModel.GameResult = "Draw " + playerChoicesDescription;
                    break;
                case GameResult.Player1Wins:
                    gameModel.GameResult = "Player 1 won " + playerChoicesDescription;
                    break;
                case GameResult.Player2Wins:
                    gameModel.GameResult = "Player 2 won " + playerChoicesDescription;
                    break;
            }

            return View(gameModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Minimal viable Rock,Paper,Scissors game";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "chrisbrooksbank@gmail.com";

            return View();
        }
    }
}