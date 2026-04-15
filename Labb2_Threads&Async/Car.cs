using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_Threads_Async
{
    internal class Car
    {
        public string Name { get; set; } 
        public int Speed { get; set; } = 120;
        public double Distance { get; set; } = 0.0;
        public bool Finished { get; set; } = false;
        public double RaceDistance { get; set; } = 2.0;
        public bool SomeOneWon { get; set; } = false;


        public Car(string name)
        {
            Name = name;
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} startar!");
            Console.ResetColor();
            int SecondsCount = 0;
            while (!Finished)
            {
                Thread.Sleep(1000);
                SecondsCount++;
                Distance += Speed / 3600.0;

                if (SecondsCount % 10 == 0)
                {
                    RandomProblem();
                }
                if(Distance >= RaceDistance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} är i mål!!");
                    Console.ResetColor();
                    Finished = true;
                    Console.ReadKey();
                }
            }
        }
        

        public void RandomProblem()
        {
            Random rnd = new Random();
            var randomProblem = rnd.Next(1, 50);

            if (randomProblem == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} fick slut på bensin! Tankar i 15 sekunder...");
                Console.ResetColor();
                Thread.Sleep(15000);
            }
            if (randomProblem > 1 && randomProblem <= 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{Name} behöver byta däck, stannar i 10 sekunder...");
                Console.ResetColor();
                Thread.Sleep(10000);

            }
            if (randomProblem > 3 && randomProblem <= 8)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{Name} fick fågel på vindrutan! Stannar 5 sekunder...");
                Console.ResetColor();
                Thread.Sleep(5000);

            }
            if (randomProblem > 8 && randomProblem <= 18)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{Name} fick motorfel! Hastigheten på {Name} sänks med 1 km/h...");
                Console.ResetColor();
                Speed--;
            }
            if (randomProblem > 18 && randomProblem <= 50)
            {
                Console.WriteLine($"{Name} har kommit {Distance:F2} km och kör i {Speed:F2} km/h");
            } 
        }
    }
}
