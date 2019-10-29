using System;

namespace Hangman
{
    class Program
    {

        private static string InitiateGame() //returns a random word
        {
        string[] wordList = new string[] {"solros", "mask", "orm", "finansinspektionen", "kråka", "varulv", "gädda", "rosmarin", "avvikelse", "munk" };
        foreach (string value in wordList) { Console.WriteLine(value); }  
        Random randomNo = new Random();
        //Console.WriteLine(wordList [randomNo.Next(0,9)]);
        string seacretWord = wordList[randomNo.Next(0, 9)];
        //Console.WriteLine(seacretWord);
            return seacretWord;
        }

        private static string ReplaceAChar(string cleanedWord) 
        {
            return "dummy";
        }
        

        static void Main(string[] args)
        {
            string correctWord = InitiateGame();
            string celandedWord = ReplaceAChar(correctWord);



        } //main
    } //program
} //namespace
