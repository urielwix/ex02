using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class GameFlow
    {
        private int maxGuesses;
        private int currentGuessCounter;


        public GameFlow()
        {
            currentGuessCounter = 0;
        }

        public void Start()
        {
            currentGuessCounter = 0;
            UIManager.DisplayWelcomeMessage();
            maxGuesses = UIManager.TakeNumberOfGuesses();

            Game gameControls = new Game();
            Board gameBoard = new Board(maxGuesses);
            UIManager.DisplayBoard(gameBoard);

            while (currentGuessCounter < maxGuesses) // maybe <= ?
            {
                string playerGuess = UIManager.TakePlayerGuess();
                if (playerGuess == "Q" || playerGuess == "q")
                {
                    UIManager.DisplayExitMessage();
                    return;
                }

                gameBoard.AddToBoard(playerGuess, gameControls.EvaluateGuess(playerGuess));
                UIManager.DisplayBoard(gameBoard);
                currentGuessCounter++;
                if (gameBoard.hasWinningSequence())
                {
                    if (UIManager.EndGameAndTryAgain(true, steps: currentGuessCounter))
                    {
                        Restart();
                        return;
                    }
                    else 
                    { 
                        return;
                    }
                }
            }
            if (UIManager.EndGameAndTryAgain(false)) 
            { 
                Restart();
            }

        }

        private void Restart()
        {
            currentGuessCounter = 0;
            Start();
        }
    }
}
