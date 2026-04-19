namespace Labb2_Threads_Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Race.RunRace();

                Console.Clear();
                Console.WriteLine("- Skriv race för att starta ett nytt race.");
                Console.WriteLine("- Tryck enter för att avsluta.");

                string userInput = Console.ReadLine();
                if (userInput.ToLower() != "race")
                {
                    run = false;
                }
            }
        }
    }
}
