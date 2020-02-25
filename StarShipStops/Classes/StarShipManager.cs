using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarShipStops.Interfaces;

namespace StarShipStops.Classes
{
    public class StarShipManager : IStarShipManager
    {
        private readonly ISWApiService apiService;
        public StarShipManager()
        {
            apiService = new SWApiService();
        }

        /// <summary>
        /// Gets All Starship and prints how many stops are required to make a trip of given distance. If not possible, prints "Unable to determine"
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public async Task PrintStopsQuantityForEachStarShip(int distance)
        {
            IEnumerable<StarShip> starShips = await apiService.GetAllStarShips();
            starShips = starShips.OrderBy(s => s.Name);

            foreach (StarShip starShip in starShips)
            {
                int stops = starShip.CalculateStops(distance);

                string starShipStopsMessage = starShip.Name + ": " + (stops != -1 ? stops.ToString() : "Unable to determine");
                Console.WriteLine(starShipStopsMessage);
                Console.WriteLine("");
                
            }
        }
    }
}
