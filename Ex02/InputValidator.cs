using System;

namespace Ex02
{
    public static class InputValidator
    {
        private static readonly int maxInputSize = 7;


        public static bool ValidateYesNo(string yesno)
        {
            if (yesno.Length != 1) 
            { 
                return false;
            }
            if (yesno == "Y" || yesno == "N")
            { 
                return true;
            }
            return false;
        }
        public static bool CheckCorrectGuessAmount(string amount)
        {
            int amountAsInt;
            if (!int.TryParse(amount, out amountAsInt))
            {
                return false;
            }

            if (amountAsInt < 4 || amountAsInt > 10) 
            { 
                return false;
            }
            return true;
        }

        public static bool CheckCorrectGuess(string guess, out string errorOutput)
        {
            guess = guess.Trim();
            errorOutput = "";

            // trivial
            if(guess.Length > maxInputSize)
            {
                errorOutput = "Incorrect input. too large.";
                return false;
            }
            else if (guess == "Q") 
            { 
                return true;
            }
            else if(guess.Length < maxInputSize)
            {
                errorOutput = "Incorrect input. too small.";
                return false;
            }


            // bad input
            char prevChar = ' ';
            
            foreach(char c in guess)
            {
                if(prevChar == ' ')
                {
                    if ((c >= 'A' && c <= 'H'))
                    {
                        prevChar = c;
                        continue;
                    }
                    else
                    {
                        errorOutput = "Incorrect character '" + c + "' in input. Please insert characters in range A - H saparated by spaces.";
                        return false;
                    }    
                }
                else
                {
                    if(c != ' ')
                    {
                        errorOutput = "Incorrect input. Please insert characters in range A - H saparated by spaces.";
                        return false;
                    }
                }
                prevChar = c;
            }
            return true;
        }
    }
}
