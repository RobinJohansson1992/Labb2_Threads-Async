using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_Threads_Async
{
    internal class Car
    {
        public string Name { get; set; }
        public double Speed { get; set; } = 120;
        public double CarDistance { get; set; } = 0.0;
        public bool Finished { get; set; } = false;
        public double RaceDistance { get; set; } = 2.0;
        public static bool Winner { get; set; } = false;

        private Random _rnd = new Random();

        public Car(string name)
        {
            Name = name;
        }

        public void RaceCar()
        {
            Console.WriteLine($"{Name} startar!");
            int SecondsCount = 0;
            while (CarDistance < RaceDistance)
            {
                Thread.Sleep(1000);
                SecondsCount++;
                CarDistance += Speed / 3600.0;

                if (SecondsCount % 10 == 0) 
                {
                    PossibleRandomProblem();
                }
            }
            Finished = true;
            if (!Winner)
            {
                Winner = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} vann racet!! Kom i mål {DateTime.Now.ToString("HH:mm:ss")}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{Name} är i mål! Kom i mål {DateTime.Now.ToString("HH:mm:ss")}");
            }


        }
        public string PrintCarStatus()
        {
            return $"{Name}: {CarDistance:F2} km, {Speed:F2} km/h";
        }

        public void PossibleRandomProblem()
        {
            var random = _rnd.Next(1, 50);

            if (random == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} fick slut på bensin! Tankar i 15 sekunder...");
                Console.ResetColor();
                Thread.Sleep(15000);
            }
            if (random > 1 && random <= 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{Name} behöver byta däck, stannar i 10 sekunder...");
                Console.ResetColor();
                Thread.Sleep(10000);

            }
            if (random > 3 && random <= 8)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{Name} fick fågel på vindrutan! Stannar 5 sekunder...");
                Console.ResetColor();
                Thread.Sleep(5000);

            }
            if (random > 8 && random <= 18)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{Name} fick motorfel! Hastigheten på {Name} sänks med 1 km/h...");
                Console.ResetColor();
                Speed--;
            }
            
        }
    }
}
