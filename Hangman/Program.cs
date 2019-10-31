using System;

namespace Hangman
{
    class Program
    {

        //private static string[] CreateAListOfWords() //finns ingen anledning att skapa en egen metod för detta
        //{
        //    string[] wordList = new string[] { "solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };
        //    Console.WriteLine("Dessa ord har vi i listan:");
        //    foreach (string value in wordList)
        //    {
        //        Console.WriteLine(value);
        //    }
        //        return wordList;
        //} //finns ingen anledning att skapa en egen metod för detta


        private static string GetARandomWord(string[] listOfWords) //skapar en array med 10 ord och returnerar ett random word
        {
            //string[] wordList = new string[] { "solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };
            //Console.WriteLine("Dessa ord har vi i listan:");
            //foreach (string value in wordList)
            //{
            //    Console.WriteLine(value);
            //}

            //bryt eventuellt ut detta i egen metod
            Random randomNo = new Random(); //get a random number
            string randomWord = listOfWords[randomNo.Next(0, 9)];
            //Console.WriteLine("Det utvalda ordet är :" + randomWord);
            return randomWord;  //use random number to pick a word
        }

        private static char[] CreateACoveredWord(string wordToCover)
        {
            char[] coveredWord = new char[wordToCover.Length]; //create a array with character
            for (int i = 0; i < (wordToCover.Length); i++) //fill it with -
            {
                coveredWord[i] = '-';
            }
            Console.Write("Ordet i dold version: "); //visar det dolda ordet 
            Console.WriteLine(coveredWord); //visar det dolda ordet 
            return coveredWord;
        }

        private static void ShowUserChoiseMeny()
        {
            Console.WriteLine("Du har tio unika försök på dig att gissa ordet.");
            Console.WriteLine("Ange 1 för att gissa på bokstav.");
            Console.WriteLine("Ange 2 för att gissa på ord.");
            Console.WriteLine("Ange 9 för att avsluta.\n");
            //return AskForACharacter("Ange 1, 2 eller 9: ");
        }
               
        private static char AskForACharacter(string infoToUSer)   //metoden skriver ut den text modulen anropas med
        {
            Console.Write(infoToUSer);
            return Console.ReadKey().KeyChar;               //NOTERA!!!!!! - glöm inte punkten som talar om typen/vad som skall retuneras
        }

        private static string AskForAString(string inforToUser)
        {
            Console.Write(inforToUser);
            return Console.ReadLine(); 
        }
        
        private static bool CheckAWord(string inputWord)
        {
            Console.Write("\n Ange ord du vill testa: ");
            string wordToTest = Console.ReadLine();
            Console.WriteLine(wordToTest);
            return true;
        }

        static void Main(string[] args)
        {

            string[] wordList = new string[] { "solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };
            
            string correctWord = GetARandomWord(wordList); //get a radom word from list

            char[] coveredWord = new char[correctWord.Length];  //skapa en char-array med lika många bokstäver om originalordet
            coveredWord = CreateACoveredWord(correctWord);      //kasta in ordet och få tillbaka den streckade varianten

            ShowUserChoiseMeny();

            bool uppRunning = true;
            while (uppRunning)
            {

                //ShowUserChoiseMeny();
                char usersLoopChoise = AskForACharacter("\nAnge 1, 2 eller 9: "); //kastar in testen som frågar efter char
                switch (usersLoopChoise)
                {
                    case '9':
                        AskForACharacter("\nDu har valt att avsluta!");
                        uppRunning = false; //deaktiverar yttre loopen
                        break;
                    case '1':
                        char charFromUser = AskForACharacter(" Ange en bokstav: ");
                        Console.Write("Tack, vi testar bokstaven.");
                        //Console.WriteLine(charFromUser);
                        break;
                    case '2':
                        string wordFromUser = AskForAString(" Ange ett ord: ");
                        Console.Write("Tack, vi testar ordet.");
                        //Console.WriteLine(wordFromUser);
                        //bool CheckedWord = CheckAWord(wordFromUser);
                        break;
                } //switch

            } //while

        } //main

    } //program
} //namespace
