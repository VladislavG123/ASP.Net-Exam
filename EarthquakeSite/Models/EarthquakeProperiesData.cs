using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeSite.Models
{
    public class EarthquakeProperiesData
    {
        [JsonProperty("mag")]
        public double Magnitude { get; set; }
        public string Place { get; set; }
        public string Time { get; set; }
    }
}
