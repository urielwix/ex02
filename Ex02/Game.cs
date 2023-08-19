using System;
using System.Linq;
using System.Text;

namespace Ex02
{

    public class Game
    {
        private char[] generatedCombination;
        private readonly int combinationLength = 4;

        public Game()
        {
            generatedCombination = new char[combinationLength];
            GenerateCombination();
        }

        public string EvaluateGuess(string guess)
        {
            char[] guessAsArray = guess.Replace(" ", "").ToCharArray();
            StringBuilder feedBack = new StringBuilder();
            int curIndex = 0;
            foreach (char curChar in guessAsArray)
            {
                if (generatedCombination.Contains(curChar))
                {
                    if (generatedCombination[curIndex] == curChar) 
                    { 
                        feedBack.Insert(0, "V");
                    }
                    else 
                    { 
                        feedBack.Append("X");
                    }
                }
                curIndex++;
                
            }
            return feedBack.ToString();
        }

        private void GenerateCombination()
        {
            Random rnd = new Random();
            for (int i = 0; i < generatedCombination.Length; i++)
            {
                char randomLetter;
                do 
                { 
                    randomLetter = (char)rnd.Next('A', 'H' + 1);
                }
                while (generatedCombination.Contains(randomLetter));

                generatedCombination[i] = randomLetter;
            }
        }


        public void restart()
        {
            GenerateCombination();
        }
    }
}
