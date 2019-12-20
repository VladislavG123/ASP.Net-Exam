using EarthquakeSite.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeSite.Services.Interfaces
{
    public interface IEarthquakeService
    {
        Task<List<EarthquakeDTO>> GetEarthquakes(int count);
    }
}
