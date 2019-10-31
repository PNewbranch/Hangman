using System;

namespace Hangman
{
    class Program
    {

        private static string GetARandomWord() //skapar en array med 10 ord och returnerar ett random word
        {
            string[] wordList = new string[] {"solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };
            Console.WriteLine("Dessa ord har vi i listan:");
            foreach (string value in wordList) 
            { 
                Console.WriteLine(value); 
            }  

            //bryt eventuellt ut detta i egen metod
            Random randomNo = new Random(); //get a random number
            return wordList[randomNo.Next(0, 9)]; //use random number to pick a word
        }

        private static char[] CreateACoveredWord(string wordToCover)
        {
            char[] coveredWord = new char[wordToCover.Length]; //create a array with character
            for (int i = 0; i < (wordToCover.Length); i++) //fill it with -
            {
                coveredWord[i] = '-';
            }
            Console.Write("Ordet i dold version blir: "); //visar det dolda ordet 
            Console.WriteLine(coveredWord); //visar det dolda ordet 
            Console.WriteLine();
            return coveredWord;
        }

        private static void ShowUserChoiseMeny()
        {
            Console.WriteLine("Du har tio unika försök på dig att gissa ordet.");
            Console.WriteLine("Ange 1 för att gissa på bokstav.");
            Console.WriteLine("Ange 2 för att gissa på ord.");
            Console.WriteLine("Ange 9 för att avsluta.\n");
            Console.Write("Gör ditt val: ");
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
            Console.WriteLine("\nDet slumpvisa valda ordet: " + correctWord);

            char[] coveredWord = new char[correctWord.Length]; //skapa en kopia av det valda ordet
            coveredWord = CreateACoveredWord(correctWord);     //strecka ut alla bokstäver

            bool uppRunning = true;
            while (uppRunning)
            {
                ShowUserChoiseMeny();
                char usersLoopChoise = Console.ReadKey().KeyChar;
                switch (usersLoopChoise)
                {
                    case '9':
                        //Console.WriteLine("Du har valt att avsluta!");
                        uppRunning = false;
                        break;
                    case '1':
                        Console.WriteLine("Vi testar en bokstav!");
                        break;
                    case '2':
                        Console.WriteLine("Vi testar på ordet!");
                        break;
                } //switch

            } //while

        } //main

    } //program
} //namespace
