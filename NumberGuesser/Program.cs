using System;


namespace NumberGuesser
{
    class Program
    {


        static string intro()
        {
            //setup
            string appName = "Number Guessser";
            string appVer = "1.0.0";
            string appAuth = "me";

            Console.ForegroundColor = ConsoleColor.Green;

            //run
            Console.WriteLine("{0}:  Version {1} By {2}", appName, appVer, appAuth);

            Console.ResetColor();

            //get name
            Console.WriteLine("What is your name? ");
            string input_name = Console.ReadLine();
            Console.WriteLine("Hello {0} and welcome to the number guesser game", input_name);
            return input_name;
        }

        static int gameplay_loop(int points)
        {

            //set number
            Random random = new Random();
            int correct_number = random.Next(1, 10);



            Console.WriteLine("Pick a number between 1 and 10...");

            int guess = 0;



            while (guess != correct_number)
            {
                string str_guess = Console.ReadLine();
                if (!int.TryParse(str_guess, out guess))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ints only please.");
                    Console.ResetColor();
                    continue;
                }
                guess = Int32.Parse(str_guess);

                if (guess != correct_number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG!! guess again..");
                    Console.ResetColor();
                    points -= 1;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("CORRECT!!");
                    Console.ResetColor();
                    points += 1;
                }
            }

            return points;
        }

        static void results(int points, string name)
        {

            Console.WriteLine("Thx for playing {0},", name);
            Console.WriteLine("Your points are: {0}", points);
            Console.WriteLine("Self Destructing in 5 seconds...");
        }
        static void Main(string[] args)
        {
            string name = intro();

            int points = 0;
            Boolean gaming = true;

            while (gaming)
            { 
                points += gameplay_loop(points);

                Console.WriteLine("Play again? [Y/N]...");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    gaming = true;
                }
                else
                {
                    gaming = false;
                }

            }

            results(points, name);


            System.Threading.Thread.Sleep(5000);

        }
    }
}
