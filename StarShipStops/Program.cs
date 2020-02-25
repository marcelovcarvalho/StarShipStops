using System;
using StarShipStops.Classes;
using StarShipStops.Interfaces;

namespace StarShipStops
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            Console.WriteLine("Please input the distance: ");
            string distanceInput = Console.ReadLine();

            int distance;
            if(!int.TryParse(distanceInput, out distance))
            {
                Console.WriteLine("Wrong format. Please input a number next time. Press ENTER to exit.");
                Console.ReadLine();
                return;
            }

            IStarShipManager starShipManager = new StarShipManager();
            await starShipManager.PrintStopsQuantityForEachStarShip(distance);

            Console.WriteLine("\r\n\r\nPress ENTER to exit.");
            Console.ReadLine();

        }

    }
}
