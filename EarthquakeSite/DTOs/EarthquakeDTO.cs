using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeSite.DTOs
{
    public class EarthquakeDTO
    {
        public double Magnitude { get; set; }
        public string Place { get; set; }
        public DateTime? Time { get; set; }
    }
}
