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
                coveredWord[i] = '-';
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
            Console.Write("Slumpat ord: " + correctWord);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nHANGMAN" + "\nGissa ordet: ");
            Console.WriteLine(coveredWord);
            Console.WriteLine("Du har 10 unika gissningar (använd bara små bokstäver), antalet försök kvar: " + guessCounter + "\nHitintills testade bokstäver: " + usedCharacters);
            Console.WriteLine("\nDina val:\n1 = testa bokstav\n2 = testa ord\n9 = ge upp");

        }

        private static void ShowCorrectResult(string correctWord, char[] coveredWord)
        {
            Console.Write("\nDet dolda ordet är: ");
            Console.ForegroundColor = ConsoleColor.Red;
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
                    while (guessCounter > 0)
                    {
                        ShowUserInterface(correctWord, coveredWord, guessCounter, usedCharacters);

                        char usersLoopChoise = AskForACharacter("\nAnge ditt val: "); 
                        switch (usersLoopChoise)
                        {
                            case '9':
                                Console.WriteLine("\nDu har valt att ge upp!");
                                System.Threading.Thread.Sleep(800);
                                guessCounter = -99;
                                break;
                            case '1':
                                char charFromUser = AskForACharacter(" Ange en bokstav: ");
                                usedCharacters.Append(charFromUser);



                                int startPos = 0;
                                while (startPos > -1)
                                {
                                    //kolla om bokstav finns
                                    int existsInPos = correctWord.IndexOf(charFromUser, startPos);  //pos5
                                    if (existsInPos > -1) //finns
                                    {
                                        coveredWord[existsInPos] = charFromUser;                    //läggs i pos 5
                                        startPos = existsInPos + 1;
                                        NoOfCharToAssign--;                                         //om hittat bokstav ta bort en från "kvar att hitta"
                                    }
                                    else //bokstav finns inte
                                    {
                                        startPos = -1;
                                    }
                                }

                                if (NoOfCharToAssign == 0) //om alla blanka bokstäver är ifyllda
                                {
                                        Console.WriteLine("Alla tecken Tilldelade.");
                                        for (int i = 0; i < correctWord.Length; i++)
                                        {
                                            coveredWord[i] = correctWord[i];
                                        }
                                        ShowCorrectResult(correctWord, coveredWord);
                                        guessCounter = -99;
                                }
                                guessCounter--;
                                break;




                            case '2':
                                string wordFromUser = AskForAString(" Ange ett ord: ");
                                if (wordFromUser == correctWord) 
                                {
                                    ShowCorrectResult(correctWord, coveredWord);
                                    guessCounter = -99;
                                }
                                else
                                {
                                    Console.Write("Ordet var fel, försök igen.");
                                    guessCounter--;
                                }
                                break;
                        } //switch - users menu choise guess character/guess word/give up
                    } //while guessCounter






                    break;
                } //switch - users menu choise play/exit
            } //while keepRunning
        } //main
    } //program
} //namespace