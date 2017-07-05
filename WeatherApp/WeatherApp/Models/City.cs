using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    class City
    {
        public City(string cityN,string cityCoor)
        {
            CityName = cityN;
            CityCoordinate = cityCoor;
        }
        public string CityName { get; set; }
        public string CityCoordinate { get; set; }
    }
}
