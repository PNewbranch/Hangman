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

        private static char[] CreateACoveredWord(string wordToCover)
        {
            char[] coveredWord = new char[wordToCover.Length]; //create a array with character
            for (int i = 0; i < (wordToCover.Length); i++) //fill it with -
            {
                coveredWord[i] = 's';
            }
            Console.WriteLine("Slumpvist valda ordet dolt: "); //visar det dolda ordet 
            Console.WriteLine(coveredWord); //visar det dolda ordet 
            return coveredWord;
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

            char[] coveredWord = new char[correctWord.Length];
            coveredWord = CreateACoveredWord(correctWord);

           bool uppRunning = true;
           while (uppRunning)
            {
                Console.WriteLine("Ange 1 för att gissa på bokstav.");
                Console.WriteLine("Ange 2 för att gissa på ord.");
                Console.WriteLine("Ange 9 för att avsluta.");
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
                }

            }





            char characterFromUser = AskForACharacter();
            Console.WriteLine(characterFromUser); 
            
            Console.WriteLine(AskForACharacter());



        } //main



    } //program
} //namespace
