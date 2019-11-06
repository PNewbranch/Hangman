using System;
using System.Text;
using System.Threading;

namespace Hangman
{
    class Program
    {
        private static string GetARandomWord(string[] listOfWords) //skapar en array med 10 ord och returnerar ett random word
        {
            Random randomNo = new Random();
            string randomWord = listOfWords[randomNo.Next(0, 9)];
            return randomWord;
        }

        public static char[] CreateACoveredWord(string wordToCover)
        {
            char[] coveredWord = new char[wordToCover.Length];
            for (int i = 0; i < (wordToCover.Length); i++)
            {
                coveredWord[i] = '_';
            }
            return coveredWord;
        }

        private static char AskForACharacter(string infoToUSer) //metoden skriver ut den text modulen anropas med
        {
            Console.Write(infoToUSer);
            return Console.ReadKey().KeyChar;
        }

        private static string AskForAString(string inforToUser)
        {
            Console.Write(inforToUser);
            return Console.ReadLine();
        }

        private static void ShowUserInterface(string correctWord, char[] coveredWord, int guessCounter, StringBuilder usedCharacters)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("(För att underlätta test, slumpat ord är: " + correctWord + ")");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nHANGMAN" + "\nGissa ordet: ");
            Console.WriteLine(coveredWord);
            Console.WriteLine("Du har 10 unika gissningar på bokstäver eller ord (använd små bokstäver), försök kvar: " + guessCounter + "\nAnvända tecken: " + usedCharacters);
            Console.WriteLine("\nDina val:\n1 = testa bokstav\n2 = testa ord\n9 = ge upp");

        }

        private static bool CheckIfUsedChar (char charFromUser, StringBuilder usedCharacters) 
        {
            bool used = false;
            for (int i = 0; i < usedCharacters.Length; i++)  ///här är felet troligen
            {
                if (charFromUser == usedCharacters[i])
                {
                    return used = true;
                }
            }
            return used;
        }

        private static void ShowCorrectResult(string correctWord, char[] coveredWord)
        {
            Console.Write("\nDet dolda ordet är: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < correctWord.Length; i++)
            {
                coveredWord[i] = correctWord[i];
                Console.Write(coveredWord[i]);
                System.Threading.Thread.Sleep(200);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nGrattis du har fått fram rätt ord!!! ");
            System.Threading.Thread.Sleep(400);
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
                    int guessCounter = 10;
                    while (guessCounter >= 0)
                    {
                        ShowUserInterface(correctWord, coveredWord, guessCounter, usedCharacters);

                        if (guessCounter == 0) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du har nu använt alla dina chanser varpå rundan avslutats.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        char usersLoopChoise = AskForACharacter("\nAnge ditt val: "); 
                        switch (usersLoopChoise)
                        {
                            case '9':
                                Console.WriteLine("\nDu har valt att ge upp!");
                                System.Threading.Thread.Sleep(800);
                                guessCounter = -99;
                                break;

                            case '1':
                                char charFromUser = AskForACharacter("\nAnge en liten bokstav: ");
                                if (CheckIfUsedChar(charFromUser, usedCharacters) == false) 
                                {
                                    usedCharacters.Append(charFromUser);
                                    int startPos = 0;
                                    while (startPos > -1)
                                    {
                                        int existsInPos = correctWord.IndexOf(charFromUser, startPos);  //kolla om bokstav finns
                                            if (existsInPos > -1)                                       //finns
                                        {
                                            coveredWord[existsInPos] = charFromUser;                    //läggs bokstaven rätt pos
                                            startPos = existsInPos + 1;                                 
                                            NoOfCharToAssign--;
                                        }
                                        else //bokstav finns inte
                                        {
                                                startPos = -99;
                                        }
                                    }

                                    if (NoOfCharToAssign == 0) //om alla blanka bokstäver är ifyllda har spelaren klarat spelet
                                    {
                                        for (int i = 0; i < correctWord.Length; i++)
                                        {
                                            coveredWord[i] = correctWord[i];
                                        }
                                        ShowUserInterface(correctWord, coveredWord, guessCounter, usedCharacters);
                                        ShowCorrectResult(correctWord, coveredWord);
                                        guessCounter = -99;
                                    }
                                    guessCounter--;
                                }
                                break;

                            case '2':
                                string wordFromUser = AskForAString("\nAnge ett ord: ");
                                if (wordFromUser == correctWord) 
                                {
                                    ShowUserInterface(correctWord, coveredWord, guessCounter, usedCharacters);
                                    ShowCorrectResult(correctWord, coveredWord);
                                    guessCounter = -99;
                                }
                                else
                                {
                                    Console.Write("Ordet var fel, försök igen.");
                                    guessCounter--;
                                }
                                break;
                        } //switch - users menu choise 2
                    } //while guessCounter < 10
                    break;
                } //switch - users menu choise 1
            } //while keepRunning
        } //main
    } 
} 