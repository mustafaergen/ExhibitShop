using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services.Contracts
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(string city);
    }
}
