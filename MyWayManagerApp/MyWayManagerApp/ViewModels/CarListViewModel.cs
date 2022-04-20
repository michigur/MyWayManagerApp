using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayManagerApp.Services;
using MyWayManagerApp.Views;
using MyWayManagerApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyWayManagerApp.ViewModels
{
    class CarListViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public CarListViewModel()
        {
            OnGo();
        }

        public ICommand Go => new Command(OnGo);
        public async void OnGo()
        {
            List<Car> cars = await this.Loadcars((App)App.Current);
        }

        public async Task<List<Car>> Loadcars(App theApp)
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            theApp.Cars = await proxy.GetCarsAsync();
            
            return theApp.Cars;
        }


    }
}
