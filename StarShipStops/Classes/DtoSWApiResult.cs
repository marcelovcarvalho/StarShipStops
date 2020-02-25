using System.Collections.Generic;

namespace StarShipStops.Classes
{
    public class DtoSWApiResult<T>
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<T> Results { get; set; }
    }
}
