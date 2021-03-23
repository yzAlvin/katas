using System.Runtime.CompilerServices;
using System;

namespace guessing_game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program game = new Program();
            Console.WriteLine("Let's play a guessing game.");

            Random random = new Random();
            int secret = random.Next(1,100);

            int numberOfGuesses = 1;
            int guess = game.PromptGuess();

            while (secret != guess)
            {
                Console.WriteLine($"{secret} is the ans");
                if (secret > guess)
                {
                    Console.WriteLine("Too Small!");
                }
                else
                {
                    Console.WriteLine("Too Large!");
                }
                guess = game.PromptGuess();
                numberOfGuesses += 1;
            }

            Console.WriteLine($"Congratulations! {secret} was the answer.");
            Console.WriteLine($"It took you {numberOfGuesses} guesses.");
        }

        public bool VerifyGuess(string n)
        {
            int guess;
            if (Int32.TryParse(n, out guess))
            {
                if (guess < 1 || guess > 100)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public int PromptGuess()
        {
            Console.WriteLine("Guess a number from 1 to 100!");
            string guess = Console.ReadLine();
            while (!VerifyGuess(guess))
            {
                Console.WriteLine("You must guess a number between 1 and 100.");
                guess = Console.ReadLine();
            }
            int guessAsInt = Int32.Parse(guess);
            return guessAsInt;
        }

        
    }

    
}
