using EarthquakeSite.DTOs;
using EarthquakeSite.Models;
using EarthquakeSite.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EarthquakeSite.Services
{
    public class EarthquakeService : IEarthquakeService
    {
        public async Task<List<EarthquakeDTO>> GetEarthquakes(int count)
        {
            var url = @"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=" + count;

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(new Uri(url));

                EarthquakeServiceResponseData responseData = JsonConvert.DeserializeObject<EarthquakeServiceResponseData>(response);

                List<EarthquakeDTO> earthquakes = new List<EarthquakeDTO>();

                foreach (var earthquake in responseData.Features)
                {
                    earthquakes.Add(new EarthquakeDTO
                    {
                        Magnitude = earthquake.Earthquakes.Magnitude,
                        Place = earthquake.Earthquakes.Place,
                        Time = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(earthquake.Earthquakes.Time)).DateTime.ToLocalTime()
                });
                }

                return earthquakes;
            }
        }
    }
}
