using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayManagerApp.Services;
using MyWayManagerApp.Views;
using MyWayManagerApp.Models;
//using Android.Content.Res;
using Xamarin.CommunityToolkit.Extensions;
using System.Threading.Tasks;

namespace MyWayManagerApp.ViewModels
{
    class AddCarViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private int fleet;
        public int Fleet
        {
            get { return fleet; }
            set
            {
                fleet = value;
                
                OnPropertyChanged("Fleet");
            }

        }

        private int seats;
        public int Seats
        {
            get { return seats; }
            set
            {
                seats = value;

                OnPropertyChanged("Seats");
            }

        }


        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                number = value;

                OnPropertyChanged("Number");
            }

        }

        private int type;
        public int Type
        {
            get { return type; }
            set
            {
                type = value;

                OnPropertyChanged("Type");
            }

        }

        private int tank;
        public int Tank
        {
            get { return tank; }
            set
            {
                tank = value;

                OnPropertyChanged("Tank");
            }

        }



        private string currentLocation;
        public string CurrentLocation
        {
            get { return currentLocation; }
            set
            {
                currentLocation = value;
                
                OnPropertyChanged("CurrentLocation");
            }

        }



        public ICommand SubmitCommand { protected set; get; }


        public AddCarViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }


        public async void OnSubmit()
        {
            CarType ct = new CarType();
            Fleet f = new Fleet();
            //RoutteCar rc = new RoutteCar();

                MyWayManagerAPIProxy proxy = MyWayManagerAPIProxy.CreateProxy();
            Car u = new Car
            {
                FleetId = Fleet,
                CarCurrentLocation = CurrentLocation,
                CarNumSeats = Seats,
                CarNumber = Number,
                CarTypeId = Type,
                CarTank = Tank,
                CarType = ct,
                Fleet = f
                

            };

            Car isReturned = await proxy.AddCar(u);

                if (isReturned == null)


                {
                    await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Invalid input", "OK");

                }
                else
                {
                    App theApp = (App)Application.Current;
                    Page p = new HomePage();
                    App.Current.MainPage = p;
                }
            
        }
    }
}
