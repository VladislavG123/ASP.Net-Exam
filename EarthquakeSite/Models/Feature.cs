using EarthquakeSite.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeSite.Models
{
    public class Feature
    {
        [JsonProperty("properties")]
        public EarthquakeProperiesData Earthquakes { get; set; }
    }
}
