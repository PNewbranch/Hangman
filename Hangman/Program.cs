using System;

namespace Hangman
{
    class Program
    {

        private static string GetARandomWord() //returns a random word
        {
            string[] wordList = new string[] {"solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };
            foreach (string value in wordList) { Console.WriteLine(value); }  
            Random randomNo = new Random();
            Console.WriteLine(wordList [randomNo.Next(0,9)]);
            string secretWord = wordList[randomNo.Next(0,9)];
            Console.WriteLine(secretWord);
            return secretWord;
        }



        //private static int AskForInput() //(outparametern) RETURN-värdet skrivs FÖRE metodnamnet - return= DOUBLE
        //{
        //    Console.Write("Ange en bokstav: ");
        //    return 'a';
        //}

        //private static string CheckWord (string cleanedWord)
        //{
        //    return "jämför ord";
        //}


        static void Main(string[] args)
        {

            string correctWord = GetARandomWord(); //get a radom word
            Console.WriteLine(correctWord);

            char[] coveredWord = new char[correctWord.Length];  //create a array with character
            for (int i=0; i < (correctWord.Length); i++)        //fill it with -
            {
                coveredWord[i] = '-';
            }
            //coveredWord[0] = 'd';
            Console.WriteLine(coveredWord);


            ////char coveredWord char[];
            ////string coveredWord = ReplaceAllChar(correctWord);

            //Console.WriteLine(coveredWord);

        } //main



    } //program
} //namespace
