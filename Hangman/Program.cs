using System;
using System.Text;
using System.Threading;

namespace Hangman
{
    class Program
    {
        private static string GetARandomWord(string[] listOfWords) //skapar en array med 10 ord och returnerar ett random word
        {
            Random randomNo = new Random(); //get a random number
            string randomWord = listOfWords[randomNo.Next(0, 9)];
            //Console.WriteLine("Det utvalda ordet är :" + randomWord);
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

        private static char AskForACharacter(string infoToUSer) //metoden skriver ut den text modulen anropas med
        {
            Console.Write(infoToUSer);
            return Console.ReadKey().KeyChar;               //NOTERA!!!!!! - glöm inte punkten som talar om typen/vad som skall retuneras
        }

        private static string AskForAString(string inforToUser)
        {
            Console.Write(inforToUser);
            return Console.ReadLine();
        }


        static void Main(string[] args)
        {
            //initiate definition of data sources
            string[] wordList = new string[] { "solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };

            bool keepRunning = true;
            while (keepRunning)
            {
                //initiate game round depended data
                string correctWord = GetARandomWord(wordList);      //get a radom word from list
                char[] coveredWord = new char[correctWord.Length];  //skapa en char-array med lika många bokstäver om originalordet
                coveredWord = CreateACoveredWord(correctWord);      //kasta in ordet och få tillbaka den streckade varianten
                int NoOfCharToAssign = coveredWord.Length;
                StringBuilder usedCharacters = new StringBuilder();

                char playOrQuit = AskForACharacter("\nVälj valfri tangent för spela HANGMAN eller 9 för att avsluta: ");
                switch (playOrQuit)
                {
                case '9':
                    keepRunning = false;
                    break;
                default :
                    int counter = 10;
                    while (counter > 0)
                    {
                        //lägg ev i egen metod med inparametrar
                        Console.Clear();
                        Console.WriteLine("Slumpat ord: " + correctWord);
                        Console.WriteLine("HANGMAN");
                        Console.Write("Gissa ordet: ");
                        Console.WriteLine(coveredWord);
                        Console.WriteLine("Du har 10 unika gissningar, antalet försök kvar: " + counter);
                        Console.WriteLine("Hitintills testade bokstäver: " + usedCharacters);
                        Console.WriteLine("\nDina val:\n1 = testa bokstav\n2 = testa ord\n9 = ge upp");

                        char usersLoopChoise = AskForACharacter("\nAnge ditt val: "); 
                        switch (usersLoopChoise)
                        {
                            case '9':
                                Console.WriteLine("\nDu har valt att ge upp!");
                                System.Threading.Thread.Sleep(2000);
                                counter = 0;
                                break;
                            case '1':
                                char charFromUser = AskForACharacter(" Ange en bokstav: ");
                                usedCharacters.Append(charFromUser);

                                int startPos = 0;
                                while (startPos > -1 )
                                {
                                    int existsInPos = correctWord.IndexOf(charFromUser, startPos); //om bokstav finns, ta reda på dess placering
                                    if (existsInPos > -1)
                                    {
                                        coveredWord[existsInPos] = charFromUser;
                                        startPos = existsInPos + 1;
                                            NoOfCharToAssign--;
                                    }
                                    else
                                    {
                                        startPos = -1;
                                    }

                                    if (NoOfCharToAssign == 0)
                                    {
                                            for (int i = 0; i < correctWord.Length; i++)
                                            {
                                                coveredWord[i] = correctWord[i];
                                            }
                                            Console.Write("\nCase 1 - Grattis du har gissat rätt ord: ");
                                            Console.WriteLine(coveredWord);
                                            System.Threading.Thread.Sleep(500);
                                            counter = -99;
                                     }
                                }
                                counter--;
                                break;
                            case '2':
                                string wordFromUser = AskForAString(" Ange ett ord: ");
                                if (wordFromUser == correctWord) 
                                {
                                    for (int i=0; i<correctWord.Length; i++)
                                    {
                                        coveredWord[i] = correctWord[i];
                                    }
                                    Console.Write("\nCase 2 - Grattis du har gissat rätt ord: ");
                                    Console.WriteLine(coveredWord);
                                    System.Threading.Thread.Sleep(500);
                                    counter = 0;
                                }
                                else
                                {
                                    Console.WriteLine("Ordet var fel, försök igen");
                                    counter--;
                                }
                                break;
                        } //switch
                    } //while counter
                    break;
                }
            } //while keepRunning
        } //main
    } //program
} //namespace
