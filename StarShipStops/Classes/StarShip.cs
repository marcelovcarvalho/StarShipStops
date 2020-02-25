using System;

namespace StarShipStops.Classes
{

    public class StarShip
    {
        public string Name { get; set; }
        public string Consumables { get; set; }
        public string MGLT { get; set; }

        public StarShip()
        {

        }

        public StarShip(string consumables, string mglt)
        {
            Consumables = consumables;
            MGLT = mglt;

        }

        /// <summary>
        /// Converts the consumables of a StarShip to Hours
        /// </summary>
        /// <returns>Returns a INT containing the number of hours the consumables will last. Returns -1 if it's not possible to determine.</returns>
        private int GetConsumablesInHours()
        {
            if (string.IsNullOrWhiteSpace(Consumables))
                return -1;

            string[] parts = Consumables.Split(" ");
            if (parts.Length > 2)
                return -1;

            int consumableNumber;
            if (!int.TryParse(parts[0], out consumableNumber))
                return -1;

            if (consumableNumber == 0)
                return 0;

            int hourMultiplier;
            switch (parts[1])
            {
                case "hour":
                case "hours":
                    hourMultiplier = 1;
                    break;
                case "day":
                case "days":
                    hourMultiplier = 24;
                    break;
                case "week":
                case "weeks":
                    hourMultiplier = 24 * 7;
                    break;
                case "month":
                case "months":
                    hourMultiplier = 24 * 30;
                    break;
                case "year":
                case "years":
                    hourMultiplier = 24 * 365;
                    break;
                default:
                    hourMultiplier = 0;
                    break;

            }

            return consumableNumber * hourMultiplier;
        }

        /// <summary>
        /// Calculates how many stops a StarShip needs give a distance.
        /// To Calculate how many stops are required:
        ///     The maximum time the starship can provide of consumables in hours, and
        ///     MGLT, which reprents the starship speed
        ///
        /// </summary>
        /// <param name="distance"></param>
        /// <returns>A int with the number of stops. Returns -1 if it is not possible to determine how many stops are needed.</returns>
        public int CalculateStops(int distance)
        {
            decimal mglt;
            if (!decimal.TryParse(MGLT, out mglt))
            {
                return -1;
            }

            if (mglt <= 0)
                return -1;

            int hoursOfConsumables = GetConsumablesInHours();
            if (hoursOfConsumables <= 0)
                return -1;

            decimal stops = distance / mglt / hoursOfConsumables;
            if (stops % 1 == 0 && stops >= 1) return (int)stops - 1;

            int result = (int)Math.Floor(stops);
            return result;
        }
    }
}
