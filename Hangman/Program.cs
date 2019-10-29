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
        //Console.WriteLine(wordList [randomNo.Next(0,9)]);
        string seacretWord = wordList[randomNo.Next(0, 9)];
        //Console.WriteLine(seacretWord);
            return seacretWord;
        }

        private static string ReplaceAllChar(string textToClean) 
        {

            string Cstring;

            for (int i = 0; i < textToClean.Length; i--)
            {
                //str = str.Replace("quick", "brown"); //byt ut en del texter
                Cstring = Cstring.Replace(char.i,"-");
            }
            return "----";
        }

        private static int AskForInput() //(outparametern) RETURN-värdet skrivs FÖRE metodnamnet - return= DOUBLE
        {
            Console.Write("Ange en bokstav: ");
            return 'a';
        }

        private static string CheckWord (string cleanedWord)
        {
            return "jämför ord";
        }


        static void Main(string[] args)
        {

            string correctWord = GetARandomWord();
            string coveredWord = ReplaceAllChar(correctWord);



            Console.WriteLine(coveredWord);


        } //main
    } //program
} //namespace
