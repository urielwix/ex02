using System;
using Ex02.ConsoleUtils;

namespace Ex02
{
    public static class UIManager
    {

        public static int TakeNumberOfGuesses()
        {
            string userInput;
            do {
                Console.WriteLine("Please insert desired number of guesses between 4 and 10");
                userInput = Console.ReadLine();

            } while (!InputValidator.CheckCorrectGuessAmount(userInput));

            return int.Parse(userInput);
        }

        // guess can be Q
        public static string TakePlayerGuess()
        {
            string userInput;
            string errorOutput = "";
            do
            {
                string curMsg = "Please type your next guess <A B C D> or 'Q' to quit";
                Console.WriteLine(errorOutput == "" ? curMsg : errorOutput);
                userInput = Console.ReadLine().ToUpper();
            } while (!InputValidator.CheckCorrectGuess(userInput, out errorOutput));

            return userInput.Trim();
        }

        public static bool EndGameAndTryAgain(bool playerWon, int steps = -1)
        {
            if (playerWon)
            {
                Console.WriteLine($"Good job, you've guessed after {steps} steps!");
            }
            else
            {
                Console.WriteLine("No more guesses alowed. You've lost!");
            }

            string userInput;
            do
            {
                Console.WriteLine("Would you like to try again? Y/N");
                 userInput = Console.ReadLine().ToUpper();
            } while (!InputValidator.ValidateYesNo(userInput));
           

            if (userInput == "Y" || userInput == "y") 
            { 
                return true;
            }
            else
            { 
                return false;   
            }
        }

        public static void DisplayWelcomeMessage()
        {
            Screen.Clear();
            Console.WriteLine("Welcome to the bullseye game!");
        }

        public static void DisplayExitMessage()
        {
            Screen.Clear();
            Console.WriteLine("GoodBye!");
            Console.WriteLine("Press enter to end");
            Console.ReadLine();
        }



        public static void DisplayBoard(Board board)
        {
            Screen.Clear();
            Console.WriteLine(board.ToString());
        }
    }
}
