using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatolog_Core.VMs
{
    public class HomePageVM
    {
        public IEnumerable<Product> FeaturedProducts { get; set; }
        public List<WeatherResponse> Weather { get; set; }
    }
}
