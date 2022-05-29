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
using System.Collections.ObjectModel;

namespace MyWayManagerApp.ViewModels
{
    class ShowCarViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public int CarID { get; set; }
        public int? FleetID { get; set; }
        public string Location { get; set; }
        public int? NumSeats { get; set; }
        public int? CarTypeID { get; set; }
        public int? CarTank { get; set; }
       


    }
}
