namespace Labb2_Threads_Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(name: "Blixten");
            Car car2 = new Car(name: "Brum");

            new Thread(car1.Run).Start();
            new Thread(car2.Run).Start();
        }
    }
}
