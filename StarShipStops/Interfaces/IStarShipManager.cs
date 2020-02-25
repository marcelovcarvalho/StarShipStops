using System.Threading.Tasks;

namespace StarShipStops.Interfaces
{
    public interface IStarShipManager
    {
        Task PrintStopsQuantityForEachStarShip(int distance);
    }
}
