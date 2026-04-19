using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_Threads_Async
{
    internal class Race
    {
        public static void RunRace()
        {
            Car.Winner = false;
            Console.Clear();
            Console.WriteLine("3...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("2...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("1...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("- Skriv 'status' + enter när som helst för att se status för bilarna.\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GO!!!");
            Console.ResetColor();

            var cars = new List<Car>
            {
                new Car(name: "Blixten"),
                new Car(name: "Brum"),
                new Car(name: "Alexus")
            };

            foreach (var car in cars)
            {
                new Thread(car.RaceCar).Start();
            }


            while (cars.Any(car => !car.Finished))
            {
                // Console.KeyAvailable to prevent Console.ReadLine from locking the while-loop:
                if (Console.KeyAvailable)
                {
                    string userInput = Console.ReadLine();

                    if (userInput.ToLower() == "status")
                    {
                        foreach (var car in cars)
                        {
                            Console.WriteLine(car.PrintCarStatus());
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Alla bilar är i mål.");
            Console.ResetColor();
            Console.WriteLine("Tryck enter för att fortsätta...");
            Console.ReadKey();
        }
    }
}
