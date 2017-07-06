using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class MainViewModel :BaseViewModel
    {
        private string _url = "https://api.darksky.net/forecast/8585a7719c87d730bfb90432ebf08832/{0},{1}";
       
        private string _mainText;
        private readonly List<City> _dataSource;

        public string MainText
        {
            get { return _mainText; }
            set
            {
                _mainText = value;
                OnPropertyChanged(()=>MainText);
            }
        }

        public MainViewModel()
        {
            MainText = "Loading...";

            _dataSource = new List<City>
            {
                new City("Tel-Aviv","32.0853,34.7818"),
                new City("New-York","40.7128,74.0059"),
                new City("Paris","48.8566,2.3522")
            };
        }
        private   async Task CitySelectedCommandAction(City city)
            {
 var client = new HttpClient();
            
            {
                try
                {
                    var result = await client.GetStringAsync(string.Format(_url,city.CityCoordinate)); // Get Json string
                    //var model = JsonConvert.DeserializeObject(result); // Turn Json into object
                    var model = JsonConvert.DeserializeObject<RootObject>(result); // Turn Json into specific type
                    MainText = model.currently.temperature.ToString();
                }
                catch(Exception ex)
                {
                    // log excepion
                }
            };            
            }
           

        }

     
    }
}