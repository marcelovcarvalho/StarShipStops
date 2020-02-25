using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarShipStops.Interfaces;

namespace StarShipStops.Classes
{
    public class SWApiService : ISWApiService
    {
        private HttpClient httpClient { get; set; }

        public SWApiService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://swapi.co/api/");

        }

        /// <summary>
        /// Get All Starships from API, page by page
        /// </summary>
        /// <param name="page"></param>
        /// <returns>All StarShips from current page to the end</returns>
        public async Task<List<StarShip>> GetAllStarShips(int page = 1)
        {

            DtoSWApiResult<StarShip> dtoResponse = await GetAllStarShipsFromApi(page);
            if (!string.IsNullOrEmpty(dtoResponse.Next))
            {
                List<StarShip> nextPage = await GetAllStarShips(page + 1);
                dtoResponse.Results.AddRange(nextPage);
            }

            return dtoResponse.Results;
        }

        /// <summary>
        /// Go go SWAPI.CO and get the starships from page
        /// </summary>
        /// <param name="page"></param>
        /// <returns>A DTO from SWAPI containing the list of starships</returns>
        private async Task<DtoSWApiResult<StarShip>> GetAllStarShipsFromApi(int page)
        {
            HttpResponseMessage response = await httpClient.GetAsync("starships/?format=json&page=" + page);
            response.EnsureSuccessStatusCode();

            string events = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DtoSWApiResult<StarShip>>(events);
        }
    }
}
