using System;

namespace Hangman
{
    class Program
    {

        private static string GetARandomWord() //returns a random word
        {
            string[] wordList = new string[] {"solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };
            foreach (string value in wordList) 
            { 
                Console.WriteLine(value); 
            }  
            Random randomNo = new Random(); //get a random number
            return wordList[randomNo.Next(0, 9)]; //use random number to pick a word
        }

        private static char AskForACharacter() //(outparametern) RETURN-värdet skrivs FÖRE metodnamnet - return= DOUBLE
        {
            Console.WriteLine("Ange en bokstav: ");
            return Console.ReadKey().KeyChar; //NOTERA!!!!!! - glöm inte punkten som talar om vad som skall retuneras
        }

        private static string CheckWord(string cleanedWord)
        {
            return "jämför ord";
        }


        static void Main(string[] args)
        {

            string correctWord = GetARandomWord(); //get a radom word from list
            Console.WriteLine("Random ord: \n" + correctWord);
            

            char[] coveredWord = new char[correctWord.Length]; //create a array with character
            for (int i=0; i < (correctWord.Length); i++) //fill it with -
            {
                coveredWord[i] = '-';
            }
            Console.WriteLine("Slumpvist valda ordet dolt: "); //visar det dolda ordet 
            Console.WriteLine(coveredWord); //visar det dolda ordet 

            Console.WriteLine(AskForACharacter());

        } //main



    } //program
} //namespace
