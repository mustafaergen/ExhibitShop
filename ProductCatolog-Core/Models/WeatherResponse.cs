using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.Models
{
    public class WeatherResponse
    {
        public string City { get; set; }
        public double Temp { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
