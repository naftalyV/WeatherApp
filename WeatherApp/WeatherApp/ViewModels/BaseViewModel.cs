using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{

    public class BaseViewModel : INotifyPropertyChanged
    {




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            MemberExpression body = expression.Body as MemberExpression;
            var propName = body.Member.Name;
            OnPropertyChanged(propName);
        }
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


    }
}

