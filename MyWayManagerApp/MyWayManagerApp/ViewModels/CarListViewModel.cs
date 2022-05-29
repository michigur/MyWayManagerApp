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
       
        

        public async Task<List<Car>> Loadcars(App theApp)
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            theApp.Cars = await proxy.GetCarsAsync();
            
            return theApp.Cars;
        }



        private bool isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                if (this.isRefreshing != value)
                {
                    this.isRefreshing = value;
                    OnPropertyChanged(nameof(IsRefreshing));
                }
            }
        }


        List<Car> clients = new List<Car>();
        public ObservableCollection<Car> MonkeyList { get; }

        public CarListViewModel()
        {
            MonkeyList = new ObservableCollection<Car>();
            OnGo();
            this.isRefreshing = false;
            //CreateMonkeyCollection();
        }

        async void CreateMonkeyCollection()
        {

            foreach (Car m in clients)
            {
                this.MonkeyList.Add(m);
            }
        }


        public ICommand Go => new Command(OnGo);
        public async void OnGo()
        {
            clients = await this.LoadClients((App)App.Current);
            foreach (Car m in clients)
            {
                this.MonkeyList.Add(m);
            }
        }

        private async Task<List<Car>> LoadClients(App theApp)
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            theApp.Cars = await proxy.GetCarsAsync();
            return theApp.Cars;
        }






        //Selection changed 
        public ICommand SelctionChanged => new Command<Object>(OnSelectionChanged);
        public void OnSelectionChanged(Object obj)
        {
            if (obj is Car)
            {
                Car chosenMonkey = (Car)obj;
                Page monkeyPage = new ShowClient();
                ShowCarViewModel monkeyContext = new ShowCarViewModel
                {
                    CarID = chosenMonkey.CarId,
                    FleetID = chosenMonkey.FleetId,
                    Location = chosenMonkey.CarCurrentLocation,
                    NumSeats = chosenMonkey.CarNumSeats,
                    CarTypeID = chosenMonkey.CarTypeId,
                    CarTank = chosenMonkey.CarTank
                    
                };
                monkeyPage.BindingContext = monkeyContext;
                monkeyPage.Title = monkeyContext.CarID.ToString();
                if (NavigateToPageEvent != null)
                    NavigateToPageEvent(monkeyPage);
            }
        }


        //Delete Client
        public ICommand DeleteCommand => new Command<Car>(RemoveMonkey);
        void RemoveMonkey(Car m)
        {
            if (MonkeyList.Contains(m))
            {
                MonkeyList.Remove(m);
            }

        }





        //Refresh collection
        public ICommand RefreshCommand => new Command(RefreshMonkeys);

        async void RefreshMonkeys()
        {
            MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            List<Car> theMonkeys = await proxy.GetCarsAsync();
            this.MonkeyList.Clear();
            foreach (Car m in theMonkeys)
            {
                this.MonkeyList.Add(m);
            }
            this.IsRefreshing = false;
        }





        #region Events
        //Events
        //This event is used to navigate to the monkey page
        public Action<Page> NavigateToPageEvent;
        #endregion

    }
}
