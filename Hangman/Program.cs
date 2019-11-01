using System;
using System.Text;
using System.Threading;

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
            Console.WriteLine("Det utvalda ordet är :" + randomWord);
            return randomWord;  //use random number to pick a word
        }

        public static char[] CreateACoveredWord(string wordToCover)
        {
            char[] coveredWord = new char[wordToCover.Length]; //create a array with character
            for (int i = 0; i < (wordToCover.Length); i++) //fill it with -
            {
                coveredWord[i] = '-';
            }
            //Console.Write("Ordet i dold version: "); //visar det dolda ordet 
            //Console.WriteLine(coveredWord); //visar det dolda ordet 
            return coveredWord;
        }

        //public static void ShowUserChoiseMeny()
        //{
        //    Console.Clear();
        //    Console.WriteLine("HANGMAN");
        //    Console.Write("Gissa ordet: ");
        //    Console.WriteLine(coveredWord);
        //    Console.WriteLine("Du har 10 unika gissningar, antalet försök kvar: " + counter);
        //    Console.WriteLine("Hitintills använda bokstäver: " + usedCharacters);
        //    Console.WriteLine("\nDina val:\n1 = testa bokstav\n2 = testa ord\n9 = ge upp");
        //}

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
            string correctWord = GetARandomWord(wordList);      //get a radom word from list
            char[] coveredWord = new char[correctWord.Length];  //skapa en char-array med lika många bokstäver om originalordet
            coveredWord = CreateACoveredWord(correctWord);      //kasta in ordet och få tillbaka den streckade varianten
            StringBuilder usedCharacters = new StringBuilder();
                
            //ShowUserChoiseMeny();

            int counter = 10;
            //bool uppRunning = true;
            while (counter > 0)
            {
                Console.Clear();
                Console.WriteLine(correctWord);
                Console.WriteLine("HANGMAN");
                Console.Write("Gissa ordet: ");
                Console.WriteLine(coveredWord);
                Console.WriteLine("Du har 10 unika gissningar, antalet försök kvar: " + counter);
                Console.WriteLine("Hitintills testade bokstäver: " + usedCharacters);
                Console.WriteLine("\nDina val:\n1 = testa bokstav\n2 = testa ord\n9 = ge upp");

                //ShowUserChoiseMeny();
                char usersLoopChoise = AskForACharacter("\nAnge ditt val: "); //kastar in testen som frågar efter char
                switch (usersLoopChoise)
                {
                    case '9':
                        AskForACharacter("\nDu har valt att ge upp!");
                        //uppRunning = false; //deaktiverar yttre loopen
                        counter = 0;
                        break;
                    case '1':
                        char charFromUser = AskForACharacter(" Ange en bokstav: ");
                        usedCharacters.Append(charFromUser);
                        int existsInPos = correctWord.IndexOf(charFromUser); //om bokstav finns, ta reda på dess placering
                        if (existsInPos>-1)
                        {
                            coveredWord[existsInPos] = charFromUser;
                            //Console.WriteLine("Placering" + existsInPos);
                            //System.Threading.Thread.Sleep(1000);  
                        }
                        counter--;
                        break;
                    case '2':
                        string wordFromUser = AskForAString(" Ange ett ord: ");
                        if (wordFromUser == correctWord) 
                        {
                            Console.WriteLine("Grattis du har gissat rätt ord");
                            for (int i=0; i<correctWord.Length; i++)
                            {
                                coveredWord[i] = correctWord[i];
                                Console.WriteLine(coveredWord);
                                System.Threading.Thread.Sleep(500);

                                
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ordet var fel, försök igen");
                            counter--;
                        }
                        break;
                } //switch

            } //while

        } //main

    } //program
} //namespace
