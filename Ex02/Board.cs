using System;
using System.Text;

namespace Ex02
{

    public class Board
    {
        private readonly int lineSize = 9;
        private int numberOfRows; // this does not include the empty row. the print methods would handle that one.
        private string[] guessesArray;
        private string[] feedbackArray;
        private int curSpot;
        private bool winningSequence;

        public Board(int numberOfGuesses)
        {
            numberOfRows = numberOfGuesses;
            guessesArray = new string[numberOfRows];
            feedbackArray = new string[numberOfRows];
            fillEmptyStringArray(guessesArray);
            fillEmptyStringArray(feedbackArray);
            curSpot = 0;
            winningSequence = false;
        }

        private void fillEmptyStringArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++) 
            { 
                arr[i] = "";
            }
        }

        public void AddToBoard(string guess, string feedback)
        {
            guessesArray[curSpot] = guess;
            feedbackArray[curSpot] = feedback;
            if (feedback.Contains("VVVV")) 
            { 
                winningSequence = true;
            }
            curSpot++;
        }
        public bool hasWinningSequence()
        {
            return winningSequence;
        }
        override
        public string ToString()
        {
            StringBuilder boardString = new StringBuilder();
            boardString.Append(SingleEntryToString("Pins:" , "Result:".PadRight(lineSize, ' ')));
            boardString.Append(SingleEntryToString("#".PadRight(lineSize, '#'), "".PadRight(lineSize, ' ')));
            for (int i = 0; i < numberOfRows; i++)
            {
                if (guessesArray[i] != "") 
                { 
                    boardString.Append(SingleEntryToString(guessesArray[i], feedbackArray[i]));
                }
                else
                {
                    boardString.Append(SingleEntryToString("", ""));
                }
            }
            return boardString.ToString();
        }

        private string SingleEntryToString(string guess, string feedback)
        {

            StringBuilder line = new StringBuilder();
            feedback = feedback.PadRight(lineSize, ' ');
            guess = guess.PadRight(lineSize, ' ');
            line.Append("|");
            line.Append(guess);
            line.Append("|");
            line.Append(feedback);
            line.Append("|\n");
            line.Append("|=========|=========|\n");
            return line.ToString();
        }

        public void displayBoard()
        {
            Console.WriteLine(ToString());
        }
    }
}
