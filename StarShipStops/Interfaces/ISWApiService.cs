using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarShipStops.Classes;

namespace StarShipStops.Interfaces
{
    public interface ISWApiService
    {
        Task<List<StarShip>> GetAllStarShips(int page = 1);

    }
}
