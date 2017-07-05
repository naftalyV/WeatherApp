using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _url = "https://api.darksky.net/forecast/8585a7719c87d730bfb90432ebf08832/{0},{1}";
        public event PropertyChangedEventHandler PropertyChanged;
        private string _mainText;
      //  private readonly List<city> _dataSource;

        public string MainText
        {
            get { return _mainText; }
            set
            {
                _mainText = value;
                OnPropertyChanged("MainText");
            }
        }

        public MainViewModel()
        {
            MainText = "Loading...";

           // _dataSource=new List<city>
            var client = new HttpClient();

            Task.Run(async() =>
            {
                try
                {
                    var result = await client.GetStringAsync(string.Format(_url, "38.9072", "77.0369")); // Get Json string
                    //var model = JsonConvert.DeserializeObject(result); // Turn Json into object
                    var model = JsonConvert.DeserializeObject<RootObject>(result); // Turn Json into specific type
                    MainText = model.currently.temperature.ToString();
                }
                catch(Exception ex)
                {
                    // log excepion
                }
            });            
        }

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}